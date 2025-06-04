#include <stdio.h>
#include <zephyr/kernel.h>
#include <zephyr/drivers/gpio.h>
#include <modem/nrf_modem_lib.h>
#include <modem/lte_lc.h>
#include <zephyr/drivers/uart.h>
#include <zephyr/net/socket.h>
#include <zephyr/posix/sys/time.h>

#define SLEEP_TIME_MS 1000
#define SERVER_IP "185.245.247.248"
#define SERVER_PORT 8080
#define CLIENT_MESSAGE "Hello from nRF9151 Client!"

#define UART_NODE DT_NODELABEL(uart1)
#define LED0_NODE DT_ALIAS(led0)
#define LED1_NODE DT_ALIAS(led1)
#define BUTTON1_NODE DT_ALIAS(sw0)

static const struct gpio_dt_spec led = GPIO_DT_SPEC_GET(LED0_NODE, gpios);
static const struct gpio_dt_spec led2 = GPIO_DT_SPEC_GET(LED1_NODE, gpios);
static const struct gpio_dt_spec button1 = GPIO_DT_SPEC_GET(BUTTON1_NODE, gpios);
static struct gpio_callback button1_cb_data;
static volatile bool button1_pressed = false;
static K_SEM_DEFINE(lte_connected, 0, 1);

void uart_send(const char *msg) {
        const struct device *uart_dev = DEVICE_DT_GET(UART_NODE);
    if (!device_is_ready(uart_dev)) {
        printf("UART device not ready!\n");
        return;
    }
    for (size_t i = 0; msg[i] != '\0'; i++) {
        uart_poll_out(uart_dev, msg[i]);
    }
}

static void lte_handler(const struct lte_lc_evt *const evt) {
	switch(evt->type) {
	        case LTE_LC_EVT_NW_REG_STATUS:
                        if((evt->nw_reg_status != LTE_LC_NW_REG_REGISTERED_HOME) && (evt->nw_reg_status != LTE_LC_NW_REG_REGISTERED_ROAMING)) {
                                break;
                        }
                        printf("Network registration status: %s\n", evt->nw_reg_status == LTE_LC_NW_REG_REGISTERED_HOME ?
                                "Connected - home network" : "Connected - roaming");
                        k_sem_give(&lte_connected);
                        break;
                        
                case LTE_LC_EVT_RRC_UPDATE:
                        printf("RRC mode: %s\n", evt->rrc_mode == LTE_LC_RRC_MODE_CONNECTED ? "Connected" : "Idle");
                        break;
                default:
                        break;
	}
}

static int modem_configure(void) {
	int err;

	printf("Initializing modem library\n");
	err = nrf_modem_lib_init();
	if(err) {
		printf("Failed to initialize the modem library, error: %d\n", err);
		return err;
	}
	
	printf("Connecting to LTE network\n");
	err = lte_lc_connect_async(lte_handler);
	if(err) {
		printf("Error in lte_lc_connect_async, error: %d\n", err);
		return err;
	}
	return 0;
}

static void communicate_with_server(void) {
        int sock;
        struct sockaddr_in server_addr;
        int ret;

        printf("Setting up socket connection...\n");

        // Create a TCP socket
        sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
        if(sock < 0) {
                printf("Failed to create socket, error: %d\n", sock);
                return;
        }

        // Configure server address
        server_addr.sin_family = AF_INET;
        server_addr.sin_port = htons(SERVER_PORT);
        ret = inet_pton(AF_INET, SERVER_IP, &server_addr.sin_addr);
        if(ret <= 0) {
                printf("Invalid server IP address, error: %d\n", ret);
                close(sock);
                return;
        }

        // Connect to the server
        ret = connect(sock, (struct sockaddr *)&server_addr, sizeof(server_addr));
        if(ret < 0) {
                printf("Failed to connect to server, error: %d\n", ret);
                close(sock);
                return;
        }

        printf("Connected to server. Sending message...\n");

        // Send a message to the server
        ret = send(sock, CLIENT_MESSAGE, strlen(CLIENT_MESSAGE), 0);
        if(ret < 0) {
                printf("Failed to send message, error: %d\n", ret);
        }else {
                printf("Message sent successfully.\n");
        }

        // Receive a response from the server with retry mechanism
        char buffer[256];
        int attempts = 5; // Number of retry attempts
        while(attempts-- > 0) {
                struct timeval timeout;
                timeout.tv_sec = 5; // 5 seconds timeout
                timeout.tv_usec = 0;

                // Set the receive timeout option for the socket
                if(setsockopt(sock, SOL_SOCKET, SO_RCVTIMEO, &timeout, sizeof(timeout)) < 0) {
                        printf("Failed to set socket timeout, error: %d\n", errno);
                        break;
                }

                ret = recv(sock, buffer, sizeof(buffer) - 1, 0);
                if(ret < 0) {
                        printf("Failed to receive response, error: %d. Retrying...\n", ret);
                        k_msleep(500); // Wait before retrying
                }else {
                        buffer[ret] = '\0'; // Null-terminate the received string
                        printf("Received response from server: %s\n", buffer);
                        break;
                }
        }
        if(ret < 0) {
                printf("Failed to receive response after retries.\n");
        }

        // Close the socket
        close(sock);
        printf("Socket closed.\n");
}

void button1_pressed_handler(const struct device *dev, struct gpio_callback *cb, uint32_t pins) {
        button1_pressed = true;
}

int main(void) {
        if(!gpio_is_ready_dt(&led)) return 0;
        if(gpio_pin_configure_dt(&led, GPIO_OUTPUT_ACTIVE) < 0) return 0;

        if(!gpio_is_ready_dt(&button1)) return 0;
        if(gpio_pin_configure_dt(&button1, GPIO_INPUT) < 0) return 0;
        if(gpio_pin_interrupt_configure_dt(&button1, GPIO_INT_EDGE_TO_ACTIVE) < 0) return 0;

        gpio_init_callback(&button1_cb_data, button1_pressed_handler, BIT(button1.pin));
        gpio_add_callback(button1.port, &button1_cb_data);

        if(modem_configure()) {
                printf("Failed to configure the modem\n");
                return 0;
        }else {
                printf("Modem configured successfully\n");
                gpio_pin_configure_dt(&led2, GPIO_OUTPUT_ACTIVE);
        }

        uart_send("Hello UART!\n");

        while(true) {
                if(button1_pressed) {
                        button1_pressed = false;
                        communicate_with_server();
                }

                if(gpio_pin_toggle_dt(&led) < 0) return 0;
                k_msleep(SLEEP_TIME_MS);
        }
        return 0;
}
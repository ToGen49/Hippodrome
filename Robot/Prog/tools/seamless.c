#include <stdio.h>
#include "freertos/FreeRTOS.h"
#include "freertos/task.h"
#include "driver/uart.h"
#include "esp_log.h"
#include "string.h"

#define UART0_PORT_NUM 0
#define UART1_PORT_NUM 1
#define BUF_SIZE 1024

void app_main(void) {
    // Configuration des paramètres UART
    const uart_config_t uart0_config = {
        .baud_rate = 115200,
        .data_bits = UART_DATA_8_BITS,
        .parity    = UART_PARITY_DISABLE,
        .stop_bits = UART_STOP_BITS_1,
        .flow_ctrl = UART_HW_FLOWCTRL_DISABLE,
    };

    const uart_config_t uart1_config = {
        .baud_rate = 115200,
        .data_bits = UART_DATA_8_BITS,
        .parity    = UART_PARITY_DISABLE,
        .stop_bits = UART_STOP_BITS_1,
        .flow_ctrl = UART_HW_FLOWCTRL_DISABLE,
    };

    // Installation des drivers UART
    uart_driver_install(UART0_PORT_NUM, BUF_SIZE * 2, 0, 0, NULL, 0);
    uart_driver_install(UART1_PORT_NUM, BUF_SIZE * 2, 0, 0, NULL, 0);
    uart_param_config(UART0_PORT_NUM, &uart0_config);
    uart_param_config(UART1_PORT_NUM, &uart1_config);
    uart_set_pin(UART0_PORT_NUM, UART_PIN_NO_CHANGE, UART_PIN_NO_CHANGE, UART_PIN_NO_CHANGE, UART_PIN_NO_CHANGE);
    uart_set_pin(UART1_PORT_NUM, 17, 18, UART_PIN_NO_CHANGE, UART_PIN_NO_CHANGE);

    // Initialize ESP-IDF logging system
    esp_log_level_set("ESP32S3", ESP_LOG_INFO);
    ESP_LOGI("ESP32S3", "UART application started");

    uint8_t data[BUF_SIZE];
    while(true) {
        // Lire les données de UART0 et les envoyer à UART1
        int len = uart_read_bytes(UART0_PORT_NUM, data, BUF_SIZE, 20 / portTICK_PERIOD_MS);
        if(len > 0) {
            for (int i = 0; i < len; i++) {if (data[i] == 0x0D) {data[i+1] = '\n';}}
            uart_write_bytes(UART1_PORT_NUM, (const char *)data, len);
            // uart_write_bytes(UART0_PORT_NUM, (const char *)data, len); // Echo back to UART0
        }else if(len == -1) {
            ESP_LOGW("ESP32S3", "UART0 read timeout");
        }

        // Lire les données de UART1 et les envoyer à UART0
        len = uart_read_bytes(UART1_PORT_NUM, data, BUF_SIZE, 20 / portTICK_PERIOD_MS);
        if(len > 0) {
            uart_write_bytes(UART0_PORT_NUM, (const char *)data, len);
            // ESP_LOGI("SIM7080G", "Received %d bytes from UART1: %.*s", len, len, data);
        }else if(len == -1) {
            ESP_LOGW("SIM7080G", "UART1 read timeout");
        }

        vTaskDelay(20 / portTICK_PERIOD_MS);
    }
}

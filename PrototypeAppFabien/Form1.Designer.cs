using System;

namespace PrototypeAppFabien
{
    partial class Pageprincipale
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblnomhippodrome = new System.Windows.Forms.Label();
            this.glblPluviometrie = new System.Windows.Forms.Label();
            this.glblTemperatureAir = new System.Windows.Forms.Label();
            this.glblHygrometrie = new System.Windows.Forms.Label();
            this.glblVitesseVent = new System.Windows.Forms.Label();
            this.glblEvapotranspiration = new System.Windows.Forms.Label();
            this.glblDirectionVent = new System.Windows.Forms.Label();
            this.glblDateDernierArrosage = new System.Windows.Forms.Label();
            this.glblDateDernierArrosagePisteDroite = new System.Windows.Forms.Label();
            this.glblDateDernierArrosagePisteCirculaire = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.gtabCondtionMeteo = new System.Windows.Forms.TabPage();
            this.gbtnConfirmationDate = new System.Windows.Forms.Button();
            this.gdtmpDateDeFin = new System.Windows.Forms.DateTimePicker();
            this.gdtmpDateDeDebut = new System.Windows.Forms.DateTimePicker();
            this.glblAjouterDateArrosage = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gtltToolTipGlobal = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.gtabCondtionMeteo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PrototypeAppFabien.Properties.Resources.fond_papier_bleu_foto_blue___125_bd_p_image_51530_grande;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblnomhippodrome
            // 
            this.lblnomhippodrome.AccessibleDescription = "";
            this.lblnomhippodrome.AccessibleName = "";
            this.lblnomhippodrome.AutoSize = true;
            this.lblnomhippodrome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnomhippodrome.Location = new System.Drawing.Point(770, 53);
            this.lblnomhippodrome.Name = "lblnomhippodrome";
            this.lblnomhippodrome.Size = new System.Drawing.Size(474, 37);
            this.lblnomhippodrome.TabIndex = 2;
            this.lblnomhippodrome.Tag = "";
            this.lblnomhippodrome.Text = "Hippodrome Angers-Ecouflant";
            // 
            // glblPluviometrie
            // 
            this.glblPluviometrie.AutoSize = true;
            this.glblPluviometrie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblPluviometrie.Location = new System.Drawing.Point(41, 44);
            this.glblPluviometrie.Name = "glblPluviometrie";
            this.glblPluviometrie.Size = new System.Drawing.Size(298, 31);
            this.glblPluviometrie.TabIndex = 3;
            this.glblPluviometrie.Text = "Pluviométrie : XX.X mm";
            this.gtltToolTipGlobal.SetToolTip(this.glblPluviometrie, "Pluviométrie prélevée la [DATE].\r\n1mm = 1L/m²");
            // 
            // glblTemperatureAir
            // 
            this.glblTemperatureAir.AutoSize = true;
            this.glblTemperatureAir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblTemperatureAir.Location = new System.Drawing.Point(39, 102);
            this.glblTemperatureAir.Name = "glblTemperatureAir";
            this.glblTemperatureAir.Size = new System.Drawing.Size(328, 31);
            this.glblTemperatureAir.TabIndex = 4;
            this.glblTemperatureAir.Text = "Température air : XX.X °C";
            this.gtltToolTipGlobal.SetToolTip(this.glblTemperatureAir, "Température air prélevée le [DATE]");
            // 
            // glblHygrometrie
            // 
            this.glblHygrometrie.AutoSize = true;
            this.glblHygrometrie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblHygrometrie.Location = new System.Drawing.Point(41, 162);
            this.glblHygrometrie.Name = "glblHygrometrie";
            this.glblHygrometrie.Size = new System.Drawing.Size(251, 31);
            this.glblHygrometrie.TabIndex = 5;
            this.glblHygrometrie.Text = "Hygrométrie : XX %";
            this.gtltToolTipGlobal.SetToolTip(this.glblHygrometrie, "Hygrométrie prélevée le [DATE].");
            // 
            // glblVitesseVent
            // 
            this.glblVitesseVent.AutoSize = true;
            this.glblVitesseVent.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblVitesseVent.Location = new System.Drawing.Point(41, 226);
            this.glblVitesseVent.Name = "glblVitesseVent";
            this.glblVitesseVent.Size = new System.Drawing.Size(287, 31);
            this.glblVitesseVent.TabIndex = 6;
            this.glblVitesseVent.Text = "Vitesse vent : XX km/h";
            this.gtltToolTipGlobal.SetToolTip(this.glblVitesseVent, "Vitesse du vent prélevée le [DATE].");
            // 
            // glblEvapotranspiration
            // 
            this.glblEvapotranspiration.AutoSize = true;
            this.glblEvapotranspiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblEvapotranspiration.Location = new System.Drawing.Point(40, 281);
            this.glblEvapotranspiration.Name = "glblEvapotranspiration";
            this.glblEvapotranspiration.Size = new System.Drawing.Size(408, 31);
            this.glblEvapotranspiration.TabIndex = 7;
            this.glblEvapotranspiration.Text = "Evapotranspiration : XX.XX mm/j";
            this.gtltToolTipGlobal.SetToolTip(this.glblEvapotranspiration, "Evapotranspiration calculée avec la formule\r\nde Penman Monteith qui nécéssite :\r\n" +
        "- Température air\r\n- Hygrométrie\r\n- Vitesse vent\r\n- Ensoleillement");
            // 
            // glblDirectionVent
            // 
            this.glblDirectionVent.AutoSize = true;
            this.glblDirectionVent.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblDirectionVent.Location = new System.Drawing.Point(39, 344);
            this.glblDirectionVent.Name = "glblDirectionVent";
            this.glblDirectionVent.Size = new System.Drawing.Size(239, 31);
            this.glblDirectionVent.TabIndex = 13;
            this.glblDirectionVent.Text = "Direction vent : XX";
            this.gtltToolTipGlobal.SetToolTip(this.glblDirectionVent, "Direction du vent mesurée le [DATE]\r\nLa direction utilise les abréviations\r\ndes p" +
        "oints cardinaux");
            // 
            // glblDateDernierArrosage
            // 
            this.glblDateDernierArrosage.AutoSize = true;
            this.glblDateDernierArrosage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblDateDernierArrosage.Location = new System.Drawing.Point(39, 406);
            this.glblDateDernierArrosage.Name = "glblDateDernierArrosage";
            this.glblDateDernierArrosage.Size = new System.Drawing.Size(329, 31);
            this.glblDateDernierArrosage.TabIndex = 15;
            this.glblDateDernierArrosage.Text = "Date de dernier arrosage :";
            this.gtltToolTipGlobal.SetToolTip(this.glblDateDernierArrosage, "Les chmpas suivant sont à propos des derniers arrosages");
            // 
            // glblDateDernierArrosagePisteDroite
            // 
            this.glblDateDernierArrosagePisteDroite.AutoSize = true;
            this.glblDateDernierArrosagePisteDroite.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblDateDernierArrosagePisteDroite.Location = new System.Drawing.Point(82, 449);
            this.glblDateDernierArrosagePisteDroite.Name = "glblDateDernierArrosagePisteDroite";
            this.glblDateDernierArrosagePisteDroite.Size = new System.Drawing.Size(362, 31);
            this.glblDateDernierArrosagePisteDroite.TabIndex = 16;
            this.glblDateDernierArrosagePisteDroite.Text = "Piste droite : [QTT]L, [DATE]";
            this.gtltToolTipGlobal.SetToolTip(this.glblDateDernierArrosagePisteDroite, "Dernier arrosage de la piste droite");
            // 
            // glblDateDernierArrosagePisteCirculaire
            // 
            this.glblDateDernierArrosagePisteCirculaire.AutoSize = true;
            this.glblDateDernierArrosagePisteCirculaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblDateDernierArrosagePisteCirculaire.Location = new System.Drawing.Point(82, 497);
            this.glblDateDernierArrosagePisteCirculaire.Name = "glblDateDernierArrosagePisteCirculaire";
            this.glblDateDernierArrosagePisteCirculaire.Size = new System.Drawing.Size(403, 31);
            this.glblDateDernierArrosagePisteCirculaire.TabIndex = 18;
            this.glblDateDernierArrosagePisteCirculaire.Text = "Piste circulaire : [QTT]L, [DATE]";
            this.gtltToolTipGlobal.SetToolTip(this.glblDateDernierArrosagePisteCirculaire, "Dernier arrosage de la piste circulaire");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.gtabCondtionMeteo);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(1907, 949);
            this.tabControl1.TabIndex = 20;
            // 
            // gtabCondtionMeteo
            // 
            this.gtabCondtionMeteo.BackColor = System.Drawing.SystemColors.Control;
            this.gtabCondtionMeteo.Controls.Add(this.gbtnConfirmationDate);
            this.gtabCondtionMeteo.Controls.Add(this.gdtmpDateDeFin);
            this.gtabCondtionMeteo.Controls.Add(this.gdtmpDateDeDebut);
            this.gtabCondtionMeteo.Controls.Add(this.glblAjouterDateArrosage);
            this.gtabCondtionMeteo.Controls.Add(this.glblPluviometrie);
            this.gtabCondtionMeteo.Controls.Add(this.glblDateDernierArrosagePisteCirculaire);
            this.gtabCondtionMeteo.Controls.Add(this.glblTemperatureAir);
            this.gtabCondtionMeteo.Controls.Add(this.glblDateDernierArrosagePisteDroite);
            this.gtabCondtionMeteo.Controls.Add(this.glblDateDernierArrosage);
            this.gtabCondtionMeteo.Controls.Add(this.glblHygrometrie);
            this.gtabCondtionMeteo.Controls.Add(this.glblDirectionVent);
            this.gtabCondtionMeteo.Controls.Add(this.glblVitesseVent);
            this.gtabCondtionMeteo.Controls.Add(this.glblEvapotranspiration);
            this.gtabCondtionMeteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtabCondtionMeteo.Location = new System.Drawing.Point(4, 44);
            this.gtabCondtionMeteo.Name = "gtabCondtionMeteo";
            this.gtabCondtionMeteo.Padding = new System.Windows.Forms.Padding(3);
            this.gtabCondtionMeteo.Size = new System.Drawing.Size(1899, 901);
            this.gtabCondtionMeteo.TabIndex = 0;
            this.gtabCondtionMeteo.Text = "Condtions météo";
            this.gtabCondtionMeteo.ToolTipText = "Conditions de la météo";
            // 
            // gbtnConfirmationDate
            // 
            this.gbtnConfirmationDate.Location = new System.Drawing.Point(1354, 683);
            this.gbtnConfirmationDate.Name = "gbtnConfirmationDate";
            this.gbtnConfirmationDate.Size = new System.Drawing.Size(235, 38);
            this.gbtnConfirmationDate.TabIndex = 23;
            this.gbtnConfirmationDate.Text = "Confirmer date";
            this.gbtnConfirmationDate.UseVisualStyleBackColor = true;
            this.gbtnConfirmationDate.Click += new System.EventHandler(this.gbtmConfirmationDate_Click);
            // 
            // gdtmpDateDeFin
            // 
            this.gdtmpDateDeFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.gdtmpDateDeFin.Location = new System.Drawing.Point(1040, 683);
            this.gdtmpDateDeFin.MaxDate = new System.DateTime(2025, 3, 26, 0, 0, 0, 0);
            this.gdtmpDateDeFin.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.gdtmpDateDeFin.Name = "gdtmpDateDeFin";
            this.gdtmpDateDeFin.Size = new System.Drawing.Size(160, 38);
            this.gdtmpDateDeFin.TabIndex = 22;
            this.gtltToolTipGlobal.SetToolTip(this.gdtmpDateDeFin, "Date de fin");
            this.gdtmpDateDeFin.Value = new System.DateTime(2025, 3, 26, 0, 0, 0, 0);
            this.gdtmpDateDeFin.ValueChanged += new System.EventHandler(this.gdtmpDateDeFin_ValueChanged);
            // 
            // gdtmpDateDeDebut
            // 
            this.gdtmpDateDeDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.gdtmpDateDeDebut.Location = new System.Drawing.Point(787, 683);
            this.gdtmpDateDeDebut.MaxDate = new System.DateTime(2025, 3, 26, 0, 0, 0, 0);
            this.gdtmpDateDeDebut.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.gdtmpDateDeDebut.Name = "gdtmpDateDeDebut";
            this.gdtmpDateDeDebut.Size = new System.Drawing.Size(160, 38);
            this.gdtmpDateDeDebut.TabIndex = 21;
            this.gtltToolTipGlobal.SetToolTip(this.gdtmpDateDeDebut, "Date de début");
            this.gdtmpDateDeDebut.Value = new System.DateTime(2025, 3, 26, 0, 0, 0, 0);
            // 
            // glblAjouterDateArrosage
            // 
            this.glblAjouterDateArrosage.AutoSize = true;
            this.glblAjouterDateArrosage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.glblAjouterDateArrosage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glblAjouterDateArrosage.ForeColor = System.Drawing.Color.MediumBlue;
            this.glblAjouterDateArrosage.Location = new System.Drawing.Point(82, 545);
            this.glblAjouterDateArrosage.Name = "glblAjouterDateArrosage";
            this.glblAjouterDateArrosage.Size = new System.Drawing.Size(212, 31);
            this.glblAjouterDateArrosage.TabIndex = 20;
            this.glblAjouterDateArrosage.Text = "Ajouter une date";
            this.gtltToolTipGlobal.SetToolTip(this.glblAjouterDateArrosage, "Cliquable\r\nPermet d\'entrer une nouvelle date d\'arrosage\r\n sa piste, ainsi que la " +
        "quantitée d\'eau utilisée");
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1899, 901);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Pageprincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1920, 1061);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblnomhippodrome);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Pageprincipale";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.gtabCondtionMeteo.ResumeLayout(false);
            this.gtabCondtionMeteo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblnomhippodrome;
        private System.Windows.Forms.Label glblPluviometrie;
        private System.Windows.Forms.Label glblTemperatureAir;
        private System.Windows.Forms.Label glblHygrometrie;
        private System.Windows.Forms.Label glblVitesseVent;
        private System.Windows.Forms.Label glblEvapotranspiration;
        private System.Windows.Forms.Label glblDirectionVent;
        private System.Windows.Forms.Label glblDateDernierArrosage;
        private System.Windows.Forms.Label glblDateDernierArrosagePisteDroite;
        private System.Windows.Forms.Label glblDateDernierArrosagePisteCirculaire;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage gtabCondtionMeteo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label glblAjouterDateArrosage;
        private System.Windows.Forms.ToolTip gtltToolTipGlobal;
        private System.Windows.Forms.DateTimePicker gdtmpDateDeDebut;
        private System.Windows.Forms.DateTimePicker gdtmpDateDeFin;
        private System.Windows.Forms.Button gbtnConfirmationDate;
    }
}


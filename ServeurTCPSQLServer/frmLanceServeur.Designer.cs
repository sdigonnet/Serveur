namespace ServeurTCPSQLServer
{
    partial class frmLanceServeur
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
            this.tbx_NumPort = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.tbx_NomHost = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_Arrêter = new System.Windows.Forms.Button();
            this.btn_Demarrer = new System.Windows.Forms.Button();
            this.LBServeur = new System.Windows.Forms.Label();
            this.TBServeur = new System.Windows.Forms.TextBox();
            this.LBBase = new System.Windows.Forms.Label();
            this.TBNomBase = new System.Windows.Forms.TextBox();
            this.TBMotDePasse = new System.Windows.Forms.TextBox();
            this.LBUtilisateur = new System.Windows.Forms.Label();
            this.LBMotDePasse = new System.Windows.Forms.Label();
            this.TBUtilisateur = new System.Windows.Forms.TextBox();
            this.BtnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_NumPort
            // 
            this.tbx_NumPort.Location = new System.Drawing.Point(332, 43);
            this.tbx_NumPort.Name = "tbx_NumPort";
            this.tbx_NumPort.Size = new System.Drawing.Size(93, 20);
            this.tbx_NumPort.TabIndex = 15;
            this.tbx_NumPort.Text = "30150";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(239, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Numéro port :";
            // 
            // tbx_NomHost
            // 
            this.tbx_NomHost.Location = new System.Drawing.Point(332, 12);
            this.tbx_NomHost.Name = "tbx_NomHost";
            this.tbx_NomHost.Size = new System.Drawing.Size(93, 20);
            this.tbx_NomHost.TabIndex = 13;
            this.tbx_NomHost.Text = "127.0.0.1";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(239, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(92, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Adresse serveur : ";
            // 
            // btn_Arrêter
            // 
            this.btn_Arrêter.Location = new System.Drawing.Point(301, 138);
            this.btn_Arrêter.Name = "btn_Arrêter";
            this.btn_Arrêter.Size = new System.Drawing.Size(124, 37);
            this.btn_Arrêter.TabIndex = 11;
            this.btn_Arrêter.Text = "Arrêter";
            this.btn_Arrêter.UseVisualStyleBackColor = true;
            this.btn_Arrêter.Click += new System.EventHandler(this.btn_Arrêter_Click);
            // 
            // btn_Demarrer
            // 
            this.btn_Demarrer.Location = new System.Drawing.Point(90, 138);
            this.btn_Demarrer.Name = "btn_Demarrer";
            this.btn_Demarrer.Size = new System.Drawing.Size(124, 37);
            this.btn_Demarrer.TabIndex = 10;
            this.btn_Demarrer.Text = "Demarrer";
            this.btn_Demarrer.UseVisualStyleBackColor = true;
            this.btn_Demarrer.Click += new System.EventHandler(this.btn_Demarrer_Click);
            // 
            // LBServeur
            // 
            this.LBServeur.AutoSize = true;
            this.LBServeur.Location = new System.Drawing.Point(12, 15);
            this.LBServeur.Name = "LBServeur";
            this.LBServeur.Size = new System.Drawing.Size(44, 13);
            this.LBServeur.TabIndex = 21;
            this.LBServeur.Text = "Serveur";
            // 
            // TBServeur
            // 
            this.TBServeur.Location = new System.Drawing.Point(86, 12);
            this.TBServeur.Name = "TBServeur";
            this.TBServeur.Size = new System.Drawing.Size(128, 20);
            this.TBServeur.TabIndex = 22;
            this.TBServeur.Text = "SYLVAIN\\SQLEXPRESS";
            // 
            // LBBase
            // 
            this.LBBase.AutoSize = true;
            this.LBBase.Location = new System.Drawing.Point(12, 43);
            this.LBBase.Name = "LBBase";
            this.LBBase.Size = new System.Drawing.Size(31, 13);
            this.LBBase.TabIndex = 23;
            this.LBBase.Text = "Base";
            // 
            // TBNomBase
            // 
            this.TBNomBase.Location = new System.Drawing.Point(86, 40);
            this.TBNomBase.Name = "TBNomBase";
            this.TBNomBase.Size = new System.Drawing.Size(128, 20);
            this.TBNomBase.TabIndex = 24;
            this.TBNomBase.Text = "iceda";
            // 
            // TBMotDePasse
            // 
            this.TBMotDePasse.Location = new System.Drawing.Point(86, 96);
            this.TBMotDePasse.Name = "TBMotDePasse";
            this.TBMotDePasse.PasswordChar = '*';
            this.TBMotDePasse.Size = new System.Drawing.Size(128, 20);
            this.TBMotDePasse.TabIndex = 28;
            this.TBMotDePasse.Text = "invite";
            // 
            // LBUtilisateur
            // 
            this.LBUtilisateur.AutoSize = true;
            this.LBUtilisateur.Location = new System.Drawing.Point(12, 70);
            this.LBUtilisateur.Name = "LBUtilisateur";
            this.LBUtilisateur.Size = new System.Drawing.Size(53, 13);
            this.LBUtilisateur.TabIndex = 25;
            this.LBUtilisateur.Text = "Utilisateur";
            // 
            // LBMotDePasse
            // 
            this.LBMotDePasse.AutoSize = true;
            this.LBMotDePasse.Location = new System.Drawing.Point(12, 99);
            this.LBMotDePasse.Name = "LBMotDePasse";
            this.LBMotDePasse.Size = new System.Drawing.Size(71, 13);
            this.LBMotDePasse.TabIndex = 27;
            this.LBMotDePasse.Text = "Mot de passe";
            // 
            // TBUtilisateur
            // 
            this.TBUtilisateur.Location = new System.Drawing.Point(86, 67);
            this.TBUtilisateur.Name = "TBUtilisateur";
            this.TBUtilisateur.Size = new System.Drawing.Size(128, 20);
            this.TBUtilisateur.TabIndex = 26;
            this.TBUtilisateur.Text = "invite";
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(215, 192);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(83, 37);
            this.BtnTest.TabIndex = 29;
            this.BtnTest.Text = "Test";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // frmLanceServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 241);
            this.Controls.Add(this.BtnTest);
            this.Controls.Add(this.LBServeur);
            this.Controls.Add(this.TBServeur);
            this.Controls.Add(this.LBBase);
            this.Controls.Add(this.TBNomBase);
            this.Controls.Add(this.TBMotDePasse);
            this.Controls.Add(this.LBUtilisateur);
            this.Controls.Add(this.LBMotDePasse);
            this.Controls.Add(this.TBUtilisateur);
            this.Controls.Add(this.tbx_NumPort);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.tbx_NomHost);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btn_Arrêter);
            this.Controls.Add(this.btn_Demarrer);
            this.Name = "frmLanceServeur";
            this.Text = "Serveur TCP acces SQLServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tbx_NumPort;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox tbx_NomHost;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btn_Arrêter;
        internal System.Windows.Forms.Button btn_Demarrer;
        private System.Windows.Forms.Label LBServeur;
        private System.Windows.Forms.TextBox TBServeur;
        private System.Windows.Forms.Label LBBase;
        private System.Windows.Forms.TextBox TBNomBase;
        private System.Windows.Forms.TextBox TBMotDePasse;
        private System.Windows.Forms.Label LBUtilisateur;
        private System.Windows.Forms.Label LBMotDePasse;
        private System.Windows.Forms.TextBox TBUtilisateur;
        internal System.Windows.Forms.Button BtnTest;

    }
}


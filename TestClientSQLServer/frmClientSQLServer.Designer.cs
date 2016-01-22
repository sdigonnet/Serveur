namespace TestClientSQLServer
{
    partial class frmClientSQLServer
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
            this.BtnConnecter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnConnecter
            // 
            this.BtnConnecter.Location = new System.Drawing.Point(91, 25);
            this.BtnConnecter.Name = "BtnConnecter";
            this.BtnConnecter.Size = new System.Drawing.Size(75, 23);
            this.BtnConnecter.TabIndex = 0;
            this.BtnConnecter.Text = "Connexion";
            this.BtnConnecter.UseVisualStyleBackColor = true;
            this.BtnConnecter.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Envoi signe de vie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmClientSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnConnecter);
            this.Name = "frmClientSQLServer";
            this.Text = "Client SQL Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnConnecter;
        private System.Windows.Forms.Button button1;
    }
}


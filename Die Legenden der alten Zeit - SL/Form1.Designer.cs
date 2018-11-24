namespace Die_Legenden_der_alten_Zeit___SL
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PlayerControl = new System.Windows.Forms.TabPage();
            this.PlayersChange = new System.Windows.Forms.Button();
            this.PlayersConfirmation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxPlayerProfile = new System.Windows.Forms.PictureBox();
            this.PlayerPlayerList = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SelectPlayerProfile = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.PlayerControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PlayerControl);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1064, 608);
            this.tabControl1.TabIndex = 0;
            // 
            // PlayerControl
            // 
            this.PlayerControl.Controls.Add(this.PlayersChange);
            this.PlayerControl.Controls.Add(this.PlayersConfirmation);
            this.PlayerControl.Controls.Add(this.groupBox1);
            this.PlayerControl.Controls.Add(this.PlayerPlayerList);
            this.PlayerControl.Location = new System.Drawing.Point(4, 22);
            this.PlayerControl.Name = "PlayerControl";
            this.PlayerControl.Padding = new System.Windows.Forms.Padding(3);
            this.PlayerControl.Size = new System.Drawing.Size(1056, 582);
            this.PlayerControl.TabIndex = 0;
            this.PlayerControl.Text = "SCs und NSCs";
            this.PlayerControl.UseVisualStyleBackColor = true;
            // 
            // PlayersChange
            // 
            this.PlayersChange.Location = new System.Drawing.Point(320, 515);
            this.PlayersChange.Name = "PlayersChange";
            this.PlayersChange.Size = new System.Drawing.Size(226, 54);
            this.PlayersChange.TabIndex = 3;
            this.PlayersChange.Text = "Erstellen";
            this.PlayersChange.UseVisualStyleBackColor = true;
            this.PlayersChange.Click += new System.EventHandler(this.PlayersChange_Click);
            // 
            // PlayersConfirmation
            // 
            this.PlayersConfirmation.Location = new System.Drawing.Point(168, 515);
            this.PlayersConfirmation.Name = "PlayersConfirmation";
            this.PlayersConfirmation.Size = new System.Drawing.Size(145, 54);
            this.PlayersConfirmation.TabIndex = 2;
            this.PlayersConfirmation.Text = "Bestätigen?";
            this.PlayersConfirmation.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxPlayerProfile);
            this.groupBox1.Location = new System.Drawing.Point(168, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 241);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Überblick";
            // 
            // pictureBoxPlayerProfile
            // 
            this.pictureBoxPlayerProfile.AccessibleName = "Profilbild";
            this.pictureBoxPlayerProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPlayerProfile.Location = new System.Drawing.Point(7, 20);
            this.pictureBoxPlayerProfile.Name = "pictureBoxPlayerProfile";
            this.pictureBoxPlayerProfile.Size = new System.Drawing.Size(147, 86);
            this.pictureBoxPlayerProfile.TabIndex = 0;
            this.pictureBoxPlayerProfile.TabStop = false;
            this.pictureBoxPlayerProfile.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // PlayerPlayerList
            // 
            this.PlayerPlayerList.FormattingEnabled = true;
            this.PlayerPlayerList.Location = new System.Drawing.Point(7, 7);
            this.PlayerPlayerList.Name = "PlayerPlayerList";
            this.PlayerPlayerList.Size = new System.Drawing.Size(154, 563);
            this.PlayerPlayerList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1056, 582);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SelectPlayerProfile
            // 
            this.SelectPlayerProfile.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 633);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.PlayerControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PlayerControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button PlayersChange;
        private System.Windows.Forms.Button PlayersConfirmation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox PlayerPlayerList;
        private System.Windows.Forms.PictureBox pictureBoxPlayerProfile;
        private System.Windows.Forms.OpenFileDialog SelectPlayerProfile;
    }
}


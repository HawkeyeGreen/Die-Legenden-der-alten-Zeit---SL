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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hauptmenüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.aspectListBox1 = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ressourcesListBox2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ressourcesListBox1 = new System.Windows.Forms.ListBox();
            this.toolTipAspectListBox = new System.Windows.Forms.ToolTip(this.components);
            this.tabPageArtifacts = new System.Windows.Forms.TabPage();
            this.listBoxArtifacts = new System.Windows.Forms.ListBox();
            this.buttonNewArtifact = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPageArtifacts.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hauptmenüToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hauptmenüToolStripMenuItem
            // 
            this.hauptmenüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.hauptmenüToolStripMenuItem.Name = "hauptmenüToolStripMenuItem";
            this.hauptmenüToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.hauptmenüToolStripMenuItem.Text = "Hauptmenü";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.SpeichernToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPageArtifacts);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1434, 572);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.aspectListBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1426, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Aspekte";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // aspectListBox1
            // 
            this.aspectListBox1.FormattingEnabled = true;
            this.aspectListBox1.Location = new System.Drawing.Point(9, 7);
            this.aspectListBox1.Name = "aspectListBox1";
            this.aspectListBox1.Size = new System.Drawing.Size(156, 511);
            this.aspectListBox1.TabIndex = 0;
            this.aspectListBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AspectListBox1_MouseMove);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ressourcesListBox2);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.ressourcesListBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1426, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ressources";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ressourcesListBox2
            // 
            this.ressourcesListBox2.FormattingEnabled = true;
            this.ressourcesListBox2.Location = new System.Drawing.Point(297, 6);
            this.ressourcesListBox2.Name = "ressourcesListBox2";
            this.ressourcesListBox2.Size = new System.Drawing.Size(120, 524);
            this.ressourcesListBox2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(435, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Neues SourceTemplate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Neue Ressource";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ressourcesListBox1
            // 
            this.ressourcesListBox1.FormattingEnabled = true;
            this.ressourcesListBox1.Location = new System.Drawing.Point(9, 7);
            this.ressourcesListBox1.Name = "ressourcesListBox1";
            this.ressourcesListBox1.Size = new System.Drawing.Size(120, 524);
            this.ressourcesListBox1.TabIndex = 0;
            // 
            // tabPageArtifacts
            // 
            this.tabPageArtifacts.Controls.Add(this.buttonNewArtifact);
            this.tabPageArtifacts.Controls.Add(this.listBoxArtifacts);
            this.tabPageArtifacts.Location = new System.Drawing.Point(4, 22);
            this.tabPageArtifacts.Name = "tabPageArtifacts";
            this.tabPageArtifacts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArtifacts.Size = new System.Drawing.Size(1426, 546);
            this.tabPageArtifacts.TabIndex = 2;
            this.tabPageArtifacts.Text = "Artefakte";
            this.tabPageArtifacts.UseVisualStyleBackColor = true;
            // 
            // listBoxArtifacts
            // 
            this.listBoxArtifacts.FormattingEnabled = true;
            this.listBoxArtifacts.Location = new System.Drawing.Point(9, 7);
            this.listBoxArtifacts.Name = "listBoxArtifacts";
            this.listBoxArtifacts.Size = new System.Drawing.Size(120, 524);
            this.listBoxArtifacts.TabIndex = 0;
            // 
            // buttonNewArtifact
            // 
            this.buttonNewArtifact.Location = new System.Drawing.Point(135, 7);
            this.buttonNewArtifact.Name = "buttonNewArtifact";
            this.buttonNewArtifact.Size = new System.Drawing.Size(208, 74);
            this.buttonNewArtifact.TabIndex = 1;
            this.buttonNewArtifact.Text = "Neues hinzufügen ...";
            this.buttonNewArtifact.UseVisualStyleBackColor = true;
            this.buttonNewArtifact.Click += new System.EventHandler(this.ButtonNewArtifact_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SL-Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPageArtifacts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hauptmenüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox aspectListBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolTip toolTipAspectListBox;
        private System.Windows.Forms.ListBox ressourcesListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox ressourcesListBox2;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageArtifacts;
        private System.Windows.Forms.Button buttonNewArtifact;
        private System.Windows.Forms.ListBox listBoxArtifacts;
    }
}


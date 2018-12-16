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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hauptmenüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.standardAttributes = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxStandardAttributes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.workingAreaStandardAttributes = new System.Windows.Forms.GroupBox();
            this.createStandardattribute = new System.Windows.Forms.Button();
            this.askOnce_Standardattributes = new System.Windows.Forms.Button();
            this.saveChanges_Standardattributes = new System.Windows.Forms.Button();
            this.deleteStandardattribute = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.standardAttributeWorkingSpace_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.standardAttributeID = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.standardAttributes.SuspendLayout();
            this.workingAreaStandardAttributes.SuspendLayout();
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
            this.beendenToolStripMenuItem});
            this.hauptmenüToolStripMenuItem.Name = "hauptmenüToolStripMenuItem";
            this.hauptmenüToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.hauptmenüToolStripMenuItem.Text = "Hauptmenü";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.standardAttributes);
            this.MainTabControl.Controls.Add(this.tabPage2);
            this.MainTabControl.Location = new System.Drawing.Point(17, 35);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1875, 950);
            this.MainTabControl.TabIndex = 1;
            // 
            // standardAttributes
            // 
            this.standardAttributes.Controls.Add(this.deleteStandardattribute);
            this.standardAttributes.Controls.Add(this.workingAreaStandardAttributes);
            this.standardAttributes.Controls.Add(this.label1);
            this.standardAttributes.Controls.Add(this.listBoxStandardAttributes);
            this.standardAttributes.Location = new System.Drawing.Point(4, 22);
            this.standardAttributes.Name = "standardAttributes";
            this.standardAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.standardAttributes.Size = new System.Drawing.Size(1867, 924);
            this.standardAttributes.TabIndex = 0;
            this.standardAttributes.Text = "Standardattribute";
            this.standardAttributes.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1867, 974);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxStandardAttributes
            // 
            this.listBoxStandardAttributes.FormattingEnabled = true;
            this.listBoxStandardAttributes.Location = new System.Drawing.Point(3, 30);
            this.listBoxStandardAttributes.Name = "listBoxStandardAttributes";
            this.listBoxStandardAttributes.Size = new System.Drawing.Size(292, 875);
            this.listBoxStandardAttributes.TabIndex = 0;
            this.listBoxStandardAttributes.SelectedIndexChanged += new System.EventHandler(this.listBoxStandardAttributes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Standardattribute";
            // 
            // workingAreaStandardAttributes
            // 
            this.workingAreaStandardAttributes.Controls.Add(this.standardAttributeID);
            this.workingAreaStandardAttributes.Controls.Add(this.label3);
            this.workingAreaStandardAttributes.Controls.Add(this.standardAttributeWorkingSpace_Name);
            this.workingAreaStandardAttributes.Controls.Add(this.label2);
            this.workingAreaStandardAttributes.Controls.Add(this.saveChanges_Standardattributes);
            this.workingAreaStandardAttributes.Controls.Add(this.askOnce_Standardattributes);
            this.workingAreaStandardAttributes.Controls.Add(this.createStandardattribute);
            this.workingAreaStandardAttributes.Location = new System.Drawing.Point(306, 33);
            this.workingAreaStandardAttributes.Name = "workingAreaStandardAttributes";
            this.workingAreaStandardAttributes.Size = new System.Drawing.Size(1555, 875);
            this.workingAreaStandardAttributes.TabIndex = 2;
            this.workingAreaStandardAttributes.TabStop = false;
            this.workingAreaStandardAttributes.Text = "Bearbeite";
            // 
            // createStandardattribute
            // 
            this.createStandardattribute.Enabled = false;
            this.createStandardattribute.Location = new System.Drawing.Point(335, 846);
            this.createStandardattribute.Name = "createStandardattribute";
            this.createStandardattribute.Size = new System.Drawing.Size(75, 23);
            this.createStandardattribute.TabIndex = 0;
            this.createStandardattribute.Text = "Erstellen";
            this.createStandardattribute.UseVisualStyleBackColor = true;
            this.createStandardattribute.Click += new System.EventHandler(this.createStandardattribute_Click);
            // 
            // askOnce_Standardattributes
            // 
            this.askOnce_Standardattributes.Location = new System.Drawing.Point(254, 846);
            this.askOnce_Standardattributes.Name = "askOnce_Standardattributes";
            this.askOnce_Standardattributes.Size = new System.Drawing.Size(75, 23);
            this.askOnce_Standardattributes.TabIndex = 1;
            this.askOnce_Standardattributes.Text = "Bestätigen";
            this.askOnce_Standardattributes.UseVisualStyleBackColor = true;
            this.askOnce_Standardattributes.Click += new System.EventHandler(this.askOnce_Standardattributes_Click);
            // 
            // saveChanges_Standardattributes
            // 
            this.saveChanges_Standardattributes.Enabled = false;
            this.saveChanges_Standardattributes.Location = new System.Drawing.Point(416, 846);
            this.saveChanges_Standardattributes.Name = "saveChanges_Standardattributes";
            this.saveChanges_Standardattributes.Size = new System.Drawing.Size(133, 23);
            this.saveChanges_Standardattributes.TabIndex = 2;
            this.saveChanges_Standardattributes.Text = "Änderungen speichern";
            this.saveChanges_Standardattributes.UseVisualStyleBackColor = true;
            // 
            // deleteStandardattribute
            // 
            this.deleteStandardattribute.Enabled = false;
            this.deleteStandardattribute.Location = new System.Drawing.Point(102, 6);
            this.deleteStandardattribute.Name = "deleteStandardattribute";
            this.deleteStandardattribute.Size = new System.Drawing.Size(110, 21);
            this.deleteStandardattribute.TabIndex = 3;
            this.deleteStandardattribute.Text = "Entferne";
            this.deleteStandardattribute.UseVisualStyleBackColor = true;
            this.deleteStandardattribute.Click += new System.EventHandler(this.deleteStandardattribute_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Attributsschlüssel: ";
            // 
            // standardAttributeWorkingSpace_Name
            // 
            this.standardAttributeWorkingSpace_Name.Location = new System.Drawing.Point(134, 63);
            this.standardAttributeWorkingSpace_Name.Name = "standardAttributeWorkingSpace_Name";
            this.standardAttributeWorkingSpace_Name.Size = new System.Drawing.Size(100, 20);
            this.standardAttributeWorkingSpace_Name.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID:";
            // 
            // standardAttributeID
            // 
            this.standardAttributeID.AutoSize = true;
            this.standardAttributeID.Location = new System.Drawing.Point(134, 33);
            this.standardAttributeID.Name = "standardAttributeID";
            this.standardAttributeID.Size = new System.Drawing.Size(98, 13);
            this.standardAttributeID.TabIndex = 6;
            this.standardAttributeID.Text = "standardAttributeID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.MainTabControl);
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
            this.MainTabControl.ResumeLayout(false);
            this.standardAttributes.ResumeLayout(false);
            this.standardAttributes.PerformLayout();
            this.workingAreaStandardAttributes.ResumeLayout(false);
            this.workingAreaStandardAttributes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hauptmenüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage standardAttributes;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxStandardAttributes;
        private System.Windows.Forms.GroupBox workingAreaStandardAttributes;
        private System.Windows.Forms.Button createStandardattribute;
        private System.Windows.Forms.Button askOnce_Standardattributes;
        private System.Windows.Forms.Button saveChanges_Standardattributes;
        private System.Windows.Forms.Button deleteStandardattribute;
        private System.Windows.Forms.Label standardAttributeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox standardAttributeWorkingSpace_Name;
        private System.Windows.Forms.Label label2;
    }
}


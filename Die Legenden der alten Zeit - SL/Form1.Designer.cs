﻿namespace Die_Legenden_der_alten_Zeit___SL
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
            this.deleteStandardattribute = new System.Windows.Forms.Button();
            this.standardAttributes_AddRef = new System.Windows.Forms.GroupBox();
            this.standardAttributesRefGroup = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.addStandardAttributeReference = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.standardAttributesReferencedKey = new System.Windows.Forms.TextBox();
            this.standardAttributeLinkingSpace_List = new System.Windows.Forms.ListBox();
            this.standardAttributeID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.standardAttributeWorkingSpace_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveChanges_Standardattributes = new System.Windows.Forms.Button();
            this.askOnce_Standardattributes = new System.Windows.Forms.Button();
            this.createStandardattribute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxStandardAttributes = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.standardAttributes.SuspendLayout();
            this.standardAttributes_AddRef.SuspendLayout();
            this.standardAttributesRefGroup.SuspendLayout();
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
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
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
            this.standardAttributes.Controls.Add(this.standardAttributes_AddRef);
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
            // standardAttributes_AddRef
            // 
            this.standardAttributes_AddRef.Controls.Add(this.standardAttributesRefGroup);
            this.standardAttributes_AddRef.Controls.Add(this.standardAttributeID);
            this.standardAttributes_AddRef.Controls.Add(this.label3);
            this.standardAttributes_AddRef.Controls.Add(this.standardAttributeWorkingSpace_Name);
            this.standardAttributes_AddRef.Controls.Add(this.label2);
            this.standardAttributes_AddRef.Controls.Add(this.saveChanges_Standardattributes);
            this.standardAttributes_AddRef.Controls.Add(this.askOnce_Standardattributes);
            this.standardAttributes_AddRef.Controls.Add(this.createStandardattribute);
            this.standardAttributes_AddRef.Location = new System.Drawing.Point(306, 33);
            this.standardAttributes_AddRef.Name = "standardAttributes_AddRef";
            this.standardAttributes_AddRef.Size = new System.Drawing.Size(1555, 875);
            this.standardAttributes_AddRef.TabIndex = 2;
            this.standardAttributes_AddRef.TabStop = false;
            this.standardAttributes_AddRef.Text = "Bearbeite";
            // 
            // standardAttributesRefGroup
            // 
            this.standardAttributesRefGroup.Controls.Add(this.button2);
            this.standardAttributesRefGroup.Controls.Add(this.addStandardAttributeReference);
            this.standardAttributesRefGroup.Controls.Add(this.label4);
            this.standardAttributesRefGroup.Controls.Add(this.standardAttributesReferencedKey);
            this.standardAttributesRefGroup.Controls.Add(this.standardAttributeLinkingSpace_List);
            this.standardAttributesRefGroup.Enabled = false;
            this.standardAttributesRefGroup.Location = new System.Drawing.Point(37, 147);
            this.standardAttributesRefGroup.Name = "standardAttributesRefGroup";
            this.standardAttributesRefGroup.Size = new System.Drawing.Size(589, 400);
            this.standardAttributesRefGroup.TabIndex = 7;
            this.standardAttributesRefGroup.TabStop = false;
            this.standardAttributesRefGroup.Text = "Verknüpfungen";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Entferne";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // addStandardAttributeReference
            // 
            this.addStandardAttributeReference.Location = new System.Drawing.Point(339, 33);
            this.addStandardAttributeReference.Name = "addStandardAttributeReference";
            this.addStandardAttributeReference.Size = new System.Drawing.Size(75, 23);
            this.addStandardAttributeReference.TabIndex = 3;
            this.addStandardAttributeReference.Text = "Hinzufügen";
            this.addStandardAttributeReference.UseVisualStyleBackColor = true;
            this.addStandardAttributeReference.Click += new System.EventHandler(this.addStandardAttributeReference_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Verknüpfe:";
            // 
            // standardAttributesReferencedKey
            // 
            this.standardAttributesReferencedKey.Location = new System.Drawing.Point(233, 35);
            this.standardAttributesReferencedKey.Name = "standardAttributesReferencedKey";
            this.standardAttributesReferencedKey.Size = new System.Drawing.Size(100, 20);
            this.standardAttributesReferencedKey.TabIndex = 1;
            // 
            // standardAttributeLinkingSpace_List
            // 
            this.standardAttributeLinkingSpace_List.FormattingEnabled = true;
            this.standardAttributeLinkingSpace_List.Location = new System.Drawing.Point(6, 50);
            this.standardAttributeLinkingSpace_List.Name = "standardAttributeLinkingSpace_List";
            this.standardAttributeLinkingSpace_List.Size = new System.Drawing.Size(156, 329);
            this.standardAttributeLinkingSpace_List.TabIndex = 0;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID:";
            // 
            // standardAttributeWorkingSpace_Name
            // 
            this.standardAttributeWorkingSpace_Name.Location = new System.Drawing.Point(134, 63);
            this.standardAttributeWorkingSpace_Name.Name = "standardAttributeWorkingSpace_Name";
            this.standardAttributeWorkingSpace_Name.Size = new System.Drawing.Size(100, 20);
            this.standardAttributeWorkingSpace_Name.TabIndex = 4;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Standardattribute";
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1867, 924);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.standardAttributes_AddRef.ResumeLayout(false);
            this.standardAttributes_AddRef.PerformLayout();
            this.standardAttributesRefGroup.ResumeLayout(false);
            this.standardAttributesRefGroup.PerformLayout();
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
        private System.Windows.Forms.GroupBox standardAttributes_AddRef;
        private System.Windows.Forms.Button createStandardattribute;
        private System.Windows.Forms.Button askOnce_Standardattributes;
        private System.Windows.Forms.Button saveChanges_Standardattributes;
        private System.Windows.Forms.Button deleteStandardattribute;
        private System.Windows.Forms.Label standardAttributeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox standardAttributeWorkingSpace_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox standardAttributesRefGroup;
        private System.Windows.Forms.Button addStandardAttributeReference;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox standardAttributesReferencedKey;
        private System.Windows.Forms.ListBox standardAttributeLinkingSpace_List;
        private System.Windows.Forms.Button button2;
    }
}


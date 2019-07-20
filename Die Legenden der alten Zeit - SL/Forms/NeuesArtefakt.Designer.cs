namespace Die_Legenden_der_alten_Zeit___SL.Forms
{
    partial class NeuesArtefakt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.comboBoxTagSelector = new System.Windows.Forms.ComboBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.buttonRemoveTag = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.listBoxStages = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddStage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxStageName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxStageDescr = new System.Windows.Forms.RichTextBox();
            this.buttonRemoveStage = new System.Windows.Forms.Button();
            this.richTextBoxBaseDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCulture = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCultureWorth = new System.Windows.Forms.TextBox();
            this.comboBoxStageSelection = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxWorkNeeded = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(69, 15);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(247, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(69, 58);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(120, 95);
            this.listBoxTags.TabIndex = 2;
            // 
            // comboBoxTagSelector
            // 
            this.comboBoxTagSelector.FormattingEnabled = true;
            this.comboBoxTagSelector.Location = new System.Drawing.Point(195, 58);
            this.comboBoxTagSelector.Name = "comboBoxTagSelector";
            this.comboBoxTagSelector.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTagSelector.TabIndex = 3;
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(195, 85);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(121, 23);
            this.buttonAddTag.TabIndex = 4;
            this.buttonAddTag.Text = "Hinzufügen...";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.ButtonAddTag_Click);
            // 
            // buttonRemoveTag
            // 
            this.buttonRemoveTag.Location = new System.Drawing.Point(196, 129);
            this.buttonRemoveTag.Name = "buttonRemoveTag";
            this.buttonRemoveTag.Size = new System.Drawing.Size(120, 23);
            this.buttonRemoveTag.TabIndex = 5;
            this.buttonRemoveTag.Text = "Auswahl entfernen...";
            this.buttonRemoveTag.UseVisualStyleBackColor = true;
            this.buttonRemoveTag.Click += new System.EventHandler(this.ButtonRemoveTag_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tags:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(1209, 592);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(84, 46);
            this.buttonAccept.TabIndex = 7;
            this.buttonAccept.Text = "Akzeptieren";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(1128, 592);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 46);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Abbrechen";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // listBoxStages
            // 
            this.listBoxStages.FormattingEnabled = true;
            this.listBoxStages.Location = new System.Drawing.Point(424, 71);
            this.listBoxStages.Name = "listBoxStages";
            this.listBoxStages.Size = new System.Drawing.Size(120, 420);
            this.listBoxStages.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxWorkNeeded);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.buttonAddStage);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxStageName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.richTextBoxStageDescr);
            this.groupBox1.Location = new System.Drawing.Point(550, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 518);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stage";
            // 
            // buttonAddStage
            // 
            this.buttonAddStage.Location = new System.Drawing.Point(595, 439);
            this.buttonAddStage.Name = "buttonAddStage";
            this.buttonAddStage.Size = new System.Drawing.Size(102, 53);
            this.buttonAddStage.TabIndex = 4;
            this.buttonAddStage.Text = "Hinzufügen ...";
            this.buttonAddStage.UseVisualStyleBackColor = true;
            this.buttonAddStage.Click += new System.EventHandler(this.ButtonAddStage_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Name:";
            // 
            // textBoxStageName
            // 
            this.textBoxStageName.Location = new System.Drawing.Point(91, 27);
            this.textBoxStageName.Name = "textBoxStageName";
            this.textBoxStageName.Size = new System.Drawing.Size(295, 20);
            this.textBoxStageName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Beschreibung: ";
            // 
            // richTextBoxStageDescr
            // 
            this.richTextBoxStageDescr.Location = new System.Drawing.Point(91, 56);
            this.richTextBoxStageDescr.Name = "richTextBoxStageDescr";
            this.richTextBoxStageDescr.Size = new System.Drawing.Size(295, 377);
            this.richTextBoxStageDescr.TabIndex = 3;
            this.richTextBoxStageDescr.Text = "";
            // 
            // buttonRemoveStage
            // 
            this.buttonRemoveStage.Location = new System.Drawing.Point(424, 497);
            this.buttonRemoveStage.Name = "buttonRemoveStage";
            this.buttonRemoveStage.Size = new System.Drawing.Size(120, 59);
            this.buttonRemoveStage.TabIndex = 12;
            this.buttonRemoveStage.Text = "Entferne ...";
            this.buttonRemoveStage.UseVisualStyleBackColor = true;
            this.buttonRemoveStage.Click += new System.EventHandler(this.ButtonRemoveStage_Click);
            // 
            // richTextBoxBaseDescription
            // 
            this.richTextBoxBaseDescription.Location = new System.Drawing.Point(69, 187);
            this.richTextBoxBaseDescription.Name = "richTextBoxBaseDescription";
            this.richTextBoxBaseDescription.Size = new System.Drawing.Size(247, 153);
            this.richTextBoxBaseDescription.TabIndex = 13;
            this.richTextBoxBaseDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Beschreibung:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Kultur: ";
            // 
            // textBoxCulture
            // 
            this.textBoxCulture.Location = new System.Drawing.Point(69, 366);
            this.textBoxCulture.Name = "textBoxCulture";
            this.textBoxCulture.Size = new System.Drawing.Size(100, 20);
            this.textBoxCulture.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Wert:";
            // 
            // textBoxCultureWorth
            // 
            this.textBoxCultureWorth.Location = new System.Drawing.Point(69, 398);
            this.textBoxCultureWorth.Name = "textBoxCultureWorth";
            this.textBoxCultureWorth.Size = new System.Drawing.Size(100, 20);
            this.textBoxCultureWorth.TabIndex = 18;
            // 
            // comboBoxStageSelection
            // 
            this.comboBoxStageSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStageSelection.FormattingEnabled = true;
            this.comboBoxStageSelection.Location = new System.Drawing.Point(424, 38);
            this.comboBoxStageSelection.Name = "comboBoxStageSelection";
            this.comboBoxStageSelection.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStageSelection.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Arbeit für nächste Stage:";
            // 
            // textBoxWorkNeeded
            // 
            this.textBoxWorkNeeded.Location = new System.Drawing.Point(523, 33);
            this.textBoxWorkNeeded.Name = "textBoxWorkNeeded";
            this.textBoxWorkNeeded.Size = new System.Drawing.Size(100, 20);
            this.textBoxWorkNeeded.TabIndex = 6;
            // 
            // NeuesArtefakt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 650);
            this.Controls.Add(this.comboBoxStageSelection);
            this.Controls.Add(this.textBoxCultureWorth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCulture);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxBaseDescription);
            this.Controls.Add(this.buttonRemoveStage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxStages);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRemoveTag);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.comboBoxTagSelector);
            this.Controls.Add(this.listBoxTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.Name = "NeuesArtefakt";
            this.Text = "Neues Artefakt erstellen ...";
            this.Load += new System.EventHandler(this.NeuesArtefakt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.ComboBox comboBoxTagSelector;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Button buttonRemoveTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListBox listBoxStages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRemoveStage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxStageName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxStageDescr;
        private System.Windows.Forms.RichTextBox richTextBoxBaseDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCulture;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCultureWorth;
        private System.Windows.Forms.Button buttonAddStage;
        private System.Windows.Forms.ComboBox comboBoxStageSelection;
        private System.Windows.Forms.TextBox textBoxWorkNeeded;
        private System.Windows.Forms.Label label8;
    }
}
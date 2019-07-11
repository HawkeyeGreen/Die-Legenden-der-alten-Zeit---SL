using Die_Legenden_der_Alten_Zeit_Lib;
using Die_Legenden_der_Alten_Zeit_Lib.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Die_Legenden_der_alten_Zeit___SL.Forms
{
    public partial class NeueSource : Form
    {
        public NeueSource()
        {
            InitializeComponent();
        }

        private void NeueSource_Load(object sender, EventArgs e)
        {
            Smallest.Text = DepositSizeTranslator.VerySmall_German;
            Small.Text = DepositSizeTranslator.Small_German;
            Medium.Text = DepositSizeTranslator.Medium_German;
            Big.Text = DepositSizeTranslator.Large_German;
            Bigger.Text = DepositSizeTranslator.VeryLarge_German;
        }

        private List<string> GetLines(TextBox text) => text.Text.Split('\n').ToList();

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(GlobalConfiguration.Documents))
            {
                Directory.CreateDirectory(GlobalConfiguration.Documents);
            }

            if (SourceTemplate.DoesTemplateExist(textBoxName.Text))
            {
                DialogResult result = MessageBox.Show("Template scheint schon zu existieren. Eindeutigen Namen wählen oder alte Ressource löschen und erneut versuchen?", "Alte Ressource löschen?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.Delete(SourceTemplate.PATH + textBoxName.Text + ".xml");
                    File.Delete(GlobalConfiguration.Documents + "//SourceTemplates//" + textBoxName.Text + ".rtf");
                    MessageBox.Show("Alte Ressource gelöscht. Bitte erneut versuchen diese zu erstellen.");
                }
            }
            else
            {
                if (!Directory.Exists(GlobalConfiguration.Documents + "//SourceTemplates//"))
                {
                    Directory.CreateDirectory(GlobalConfiguration.Documents + "//SourceTemplates//");
                }
                richTextBoxDescr.SaveFile(GlobalConfiguration.Documents + "//SourceTemplates//" + textBoxName.Text + ".rtf");
                SourceTemplate sourceTemplate = new SourceTemplate()
                {
                    Name = textBoxName.Text,
                    DescriptionPath = "//Content//Documents//SourceTemplates//" + textBoxName.Text + ".rtf",
                    NeededTileAttributes = GetLines(textBoxNeeded),
                    ForbiddenTileAttributes = GetLines(textBoxNeeded)
                };
                sourceTemplate.DepositRanges[DepositSizes.VerySmall] = new int[2] { Convert.ToInt32(textBoxSmallestMin.Text), Convert.ToInt32(textBoxSmallestMax.Text) };
                sourceTemplate.DepositRanges[DepositSizes.Small] = new int[2] {Convert.ToInt32(textBoxSmallMin.Text), Convert.ToInt32(textBoxSmallMax.Text) };
                sourceTemplate.DepositRanges[DepositSizes.Medium] = new int[2] { Convert.ToInt32(textBoxMediumMin.Text), Convert.ToInt32(textBoxMediumMax.Text) };
                sourceTemplate.DepositRanges[DepositSizes.Large] = new int[2] { Convert.ToInt32(textBoxBiggestMin.Text), Convert.ToInt32(textBoxBigMax.Text) };
                sourceTemplate.DepositRanges[DepositSizes.VeryLarge] = new int[2] { Convert.ToInt32(textBoxBiggestMin.Text), Convert.ToInt32(textBoxBiggestMax.Text) };
                SourceTemplate.Save(sourceTemplate);
                Close();
            }
        }
    }
}

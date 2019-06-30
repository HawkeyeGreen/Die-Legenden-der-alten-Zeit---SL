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

namespace Die_Legenden_der_alten_Zeit___SL
{
    public partial class NeueRessource : Form
    {
        public NeueRessource()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(GlobalConfiguration.Documents))
            {
                Directory.CreateDirectory(GlobalConfiguration.Documents);
            }

            if (Ressource.DoesRessourceExist(textBoxName.Text))
            {
                DialogResult result = MessageBox.Show("Ressource scheint schon zu existieren. Eindeutigen Namen wählen oder alte Ressource löschen und erneut versuchen?", "Alte Ressource löschen?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.Delete(Ressource.PATH + textBoxName.Text + ".xml");
                    File.Delete(GlobalConfiguration.Documents + "//Ressources//" + textBoxName.Text + ".rtf");
                    MessageBox.Show("Alte Ressource gelöscht. Bitte erneut versuchen diese zu erstellen.");
                }
            }
            else
            {
                if (!Directory.Exists(GlobalConfiguration.Documents + "//Ressources//"))
                {
                    Directory.CreateDirectory(GlobalConfiguration.Documents + "//Ressources//");
                }
                richTextBoxDescr.SaveFile(GlobalConfiguration.Documents + "//Ressources//" + textBoxName.Text + ".rtf");
                Ressource ressource = new Ressource(textBoxName.Text)
                {
                    DescriptionPath = "//Content//Documents//Ressources//" + textBoxName.Text + ".rtf"
                };
                Ressource.Save(ressource);
                Close();
            }
        }

        private List<string> GetLines(TextBox text) => text.Text.Split('\n').ToList();
    }
}

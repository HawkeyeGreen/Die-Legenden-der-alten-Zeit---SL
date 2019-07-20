using Die_Legenden_der_Alten_Zeit_Lib.Artifacts;
using Die_Legenden_der_Alten_Zeit_Lib.Helper;
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
    public partial class NeuesArtefakt : Form
    {
        private static readonly string tmprtf = AppDomain.CurrentDomain.BaseDirectory + "//tmp//RTFs//";
        private Dictionary<string, int> WorkPerStage = new Dictionary<string, int>();
        public NeuesArtefakt()
        {
            InitializeComponent();
        }

        private void NeuesArtefakt_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(tmprtf))
            {
                Directory.Delete(tmprtf, true);
            }
            Directory.CreateDirectory(tmprtf);
            FillTagSelector();
            comboBoxStageSelection.Items.Add(ArtifactTemplate.SELECTIONMODE_RANDOM);
            comboBoxStageSelection.Items.Add(ArtifactTemplate.SELECTIONMODE_INORDER);
        }

        private void FillTagSelector()
        {
            comboBoxTagSelector.Items.Clear();
            comboBoxTagSelector.Items.AddRange(TagCatalog.GetCatalog().GetArtifactTags().ToArray());
        }

        private void ButtonAddTag_Click(object sender, EventArgs e)
        {
            string tag = comboBoxTagSelector.Text;
            if (!listBoxTags.Items.Contains(tag))
            {
                TagCatalog.GetCatalog().AddArtifactTag(tag);
                TagCatalog.GetCatalog().Save();
                listBoxTags.Items.Add(tag);
                FillTagSelector();
            }
            else
            {
                MessageBox.Show("Tag schon vorhanden.");
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonRemoveTag_Click(object sender, EventArgs e)
        {
            if (listBoxTags.SelectedItem != null)
            {
                int index = listBoxTags.SelectedIndex;
                listBoxTags.ClearSelected();
                listBoxTags.Items.RemoveAt(index);
            }
        }

        private void ButtonAddStage_Click(object sender, EventArgs e)
        {
            string stageName = textBoxStageName.Text;
            int Work = 0;
            bool everythingAlright = true;

            try
            {
                Work = Convert.ToInt32(textBoxWorkNeeded.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Arbeitsaufwand muss eine Zahl sein. \n" + exception.Message);
                everythingAlright = false;
            }

            if (stageName == "")
            {
                MessageBox.Show("Name darf nicht leer sein.");
                everythingAlright = false;
            }
            else if (listBoxStages.Items.Contains(stageName))
            {
                MessageBox.Show("Name der Stage muss für dieses Artefakt einzigartig sein.");
                everythingAlright = false;
            }

            if (richTextBoxStageDescr.Text == "")
            {
                MessageBox.Show("Beschreibung darf nicht leer sein.");
                everythingAlright = false;
            }

            if (everythingAlright)
            {
                listBoxStages.Items.Add(stageName);
                richTextBoxStageDescr.SaveFile(tmprtf + stageName + ".rtf");
                WorkPerStage[stageName] = Work;
            }

        }

        private void ButtonRemoveStage_Click(object sender, EventArgs e)
        {
            if(listBoxStages.SelectedItem != null)
            {
                string selectedStage = listBoxStages.SelectedItem.ToString();
                int i = listBoxStages.SelectedIndex;
                listBoxStages.ClearSelected();
                listBoxStages.Items.RemoveAt(i);
                if(File.Exists(tmprtf + selectedStage + ".rtf"))
                {
                    File.Delete(tmprtf + selectedStage + ".rtf");
                }
                WorkPerStage.Remove(selectedStage);
            }
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            bool everythingAlright = true;
            string name = textBoxName.Text;
            string culture = textBoxCulture.Text;
            int cultureWorth = 0;
            string selectionMode = ArtifactTemplate.SELECTIONMODE_INORDER;
            #region Fehlerbehandlung
            try
            {
                cultureWorth = Convert.ToInt32(textBoxCultureWorth.Text);
            }
            catch(Exception exception)
            {
                MessageBox.Show("Kulturwert muss eine Zahl sein. \n" + exception.Message);
                everythingAlright = false;
            }

            if(richTextBoxBaseDescription.Text == "")
            {
                MessageBox.Show("Beschreibung darf nicht leer sein.");
                everythingAlright = false;
            }

            if(name == "")
            {
                MessageBox.Show("Name darf nicht leer sein.");
                everythingAlright = false;
            }
            else if(ArtifactTemplate.GetArtifactTemplates().Contains(name))
            {
                MessageBox.Show("Name muss einzigartig sein.");
                everythingAlright = false;
            }

            if(culture == "")
            {
                MessageBox.Show("Kultur darf nicht leer sein.");
                everythingAlright = false;
            }

            if(cultureWorth < 0)
            {
                MessageBox.Show("Kulturwert darf nicht kleiner null sein.");
                everythingAlright = false;
            }

            if(comboBoxStageSelection.SelectedItem != null)
            {
                selectionMode = comboBoxStageSelection.SelectedItem.ToString();
            }
            #endregion

            #region Erstellung des Artefakts
            if (everythingAlright)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + GlobalConfiguration.Documents + "//Artifacts//" + name);

                List<string> RTFs = new List<string>();
                List<int> Work = new List<int>();

                foreach(string stage in listBoxStages.Items)
                {
                    RTFs.Add(GlobalConfiguration.Documents + "//Artifacts//" + name + "//" + stage + ".rtf");
                    Work.Add(WorkPerStage[stage]);
                    File.Move(tmprtf + stage + ".rtf" , AppDomain.CurrentDomain.BaseDirectory + GlobalConfiguration.Documents + "//Artifacts//" + name + "//" + stage + ".rtf");
                }
                ArtifactTemplate artifact = new ArtifactTemplate()
                {
                    Name = name,
                    BaseDescriptionRTF = GlobalConfiguration.Documents + "//Artifacts//" + name + ".rtf",
                    RTF = RTFs,
                    Tags = listBoxTags.Items.Cast<string>().ToList(),
                    StageNames = listBoxStages.Items.Cast<string>().ToList(),
                    WorkNeededForNextStage = Work,
                    Culture = culture,
                    CultureWorth = cultureWorth
                };
                ArtifactTemplate.SaveArtifactTemplate(artifact);
                Close();
            }
            #endregion
        }
    }
}

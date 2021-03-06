﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

using Die_Legenden_der_Alten_Zeit_Lib.Nations;

using Zeus.Hermes;
using Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.TileAttributes;
using Die_Legenden_der_Alten_Zeit_Lib.Universe.Aspects;
using Die_Legenden_der_Alten_Zeit_Lib.Ressources;
using Die_Legenden_der_alten_Zeit___SL.Forms;
using Die_Legenden_der_Alten_Zeit_Lib.Helper;
using Die_Legenden_der_Alten_Zeit_Lib.Nations.Settlements;
using Die_Legenden_der_Alten_Zeit_Lib;
using Die_Legenden_der_Alten_Zeit_Lib.Artifacts;

namespace Die_Legenden_der_alten_Zeit___SL
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hermes.DebugLevel = 5;
            UpdateAllFormData();
            TagCatalog.GetCatalog();
        }

        #region UpdateFuntions
        // This method calls all other update-Methods in Order to update the global dataViews
        // It will use intelligent ways to not collide with user-input data etc.
        private void UpdateAllFormData()
        {
            UpdateAspectsTab();
            UpdateRessourcesTab();
        }

        private void UpdateAspectsTab()
        {
            aspectListBox1.ClearSelected();
            aspectListBox1.Items.Clear();
            List<string> names = Aspect.GetAspectNames();
            foreach (string name in names)
            {
                aspectListBox1.Items.Add(name);
            }
        }

        private void UpdateRessourcesTab()
        {
            //ressourcesListBox1
            ressourcesListBox1.ClearSelected();
            ressourcesListBox1.Items.Clear();
            List<string> names = Ressource.GetRessourceNames();
            foreach (string name in names)
            {
                ressourcesListBox1.Items.Add(name);
            }
            ressourcesListBox2.ClearSelected();
            ressourcesListBox2.Items.Clear();
            names = SourceTemplate.GetSourcesTemplates();
            foreach (string name in names)
            {
                ressourcesListBox2.Items.Add(name);
            }
        }

        private void UpdateArtifactTab()
        {
            listBoxArtifacts.ClearSelected();
            listBoxArtifacts.Items.Clear();
            listBoxArtifacts.Items.AddRange(ArtifactTemplate.GetArtifactTemplates().ToArray());
        }
        #endregion


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hermes.getInstance().shutdownHermes();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TagCatalog.GetCatalog().Save();
            this.Close();
        }

        private void AspectListBox1_MouseMove(object sender, MouseEventArgs e)
        {
            string toolTip = "";

            int index = aspectListBox1.IndexFromPoint(e.Location);

            if (index >= 0 && index < aspectListBox1.Items.Count)
            {
                toolTip = Aspect.GetAspect(aspectListBox1.Items[index].ToString()).ToString();
            }

            if (toolTipAspectListBox.GetToolTip(aspectListBox1) != toolTip)
            {
                toolTipAspectListBox.SetToolTip(aspectListBox1, toolTip);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NeueRessource ressource = new NeueRessource();
            ressource.ShowDialog();
            UpdateRessourcesTab();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            NeueSource source = new NeueSource();
            source.ShowDialog();
            UpdateRessourcesTab();
        }

        private void SpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettlementManager.GetInstance().Save();
        }

        private void ButtonNewArtifact_Click(object sender, EventArgs e)
        {
            NeuesArtefakt artefakt = new NeuesArtefakt();
            artefakt.ShowDialog();
            UpdateArtifactTab();
        }
    }
}

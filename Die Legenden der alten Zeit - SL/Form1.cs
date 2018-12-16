using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;
using Die_Legenden_der_Alten_Zeit_Lib.EffectSystem;
using Die_Legenden_der_Alten_Zeit_Lib.CharacterManagement.AttributeSystem;

using Zeus.Hermes;

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
            UpdateAllFormData();
        }

        #region UpdateFuntions
        // This method calls all other update-Methods in Order to update the global dataViews
        // It will use intelligent ways to not collide with user-input data etc.
        private void UpdateAllFormData()
        {
            UpdateStandardAttributesTab();
        }

        private void UpdateStandardAttributesTab()
        {
            DataTableReader tableReader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM StandardAttributes").CreateDataReader();

            if(tableReader.HasRows)
            {
                int selectedIndex = listBoxStandardAttributes.SelectedIndex;

                listBoxStandardAttributes.ClearSelected();
                listBoxStandardAttributes.Items.Clear();

                while(tableReader.Read())
                {
                    listBoxStandardAttributes.Items.Add(tableReader.GetString(tableReader.GetOrdinal("AttributeKey")) + " {" + tableReader.GetValue(tableReader.GetOrdinal("ID")).ToString() + "}" );
                }

                if(selectedIndex < listBoxStandardAttributes.Items.Count)
                {
                    listBoxStandardAttributes.SelectedIndex = selectedIndex;
                }
            }
            else
            {
                listBoxStandardAttributes.ClearSelected();
                listBoxStandardAttributes.Items.Clear();
            }

            standardAttributeID.Text = "";
            standardAttributeWorkingSpace_Name.Text = "";
        }
        #endregion

        #region loadElements
        #endregion


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hermes.getInstance().shutdownHermes();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxStandardAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxStandardAttributes.SelectedItem != null)
            {
                int ID = GetIDFromStandardstring(listBoxStandardAttributes.SelectedItem.ToString());

                StandardAttribute attribute = new StandardAttribute(ID);
                standardAttributeID.Text = attribute.ID.ToString();
                standardAttributeWorkingSpace_Name.Text = attribute.Key;
                deleteStandardattribute.Enabled = true;
            }
        }

        private int GetIDFromStandardstring(string _Item)
        {
            _Item = _Item.Replace("}", "");
            string[] choppedItem = _Item.Split("{".ToCharArray());
            return Convert.ToInt32(choppedItem[1]);
        }

        private void askOnce_Standardattributes_Click(object sender, EventArgs e)
        {
            standardAttributes_WorkingSpace_ButtonToggle();
        }

        private void standardAttributes_WorkingSpace_ButtonToggle()
        {
            if(askOnce_Standardattributes.Enabled)
            {
                createStandardattribute.Enabled = true;
                saveChanges_Standardattributes.Enabled = true;

                askOnce_Standardattributes.Enabled = false;
            }
            else
            {
                createStandardattribute.Enabled = false;
                saveChanges_Standardattributes.Enabled = false;

                askOnce_Standardattributes.Enabled = true;
            }
        }

        private void createStandardattribute_Click(object sender, EventArgs e)
        {
            string Key = Convert.ToString(standardAttributeWorkingSpace_Name.Text);

            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM StandardAttributes WHERE AttributeKey ='" + Key + "';").CreateDataReader();

            if(reader.HasRows)
            {
                MessageBox.Show("Key ist bereits vorhanden! Anderen AttributeKey vergeben.", "My Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            else
            {
                StandardAttribute attribute = new StandardAttribute(Key);
                attribute.SaveStandardAttribute();
                UpdateStandardAttributesTab();
            }

            standardAttributes_WorkingSpace_ButtonToggle();
        }

        private void deleteStandardattribute_Click(object sender, EventArgs e)
        {
            if(listBoxStandardAttributes.SelectedItem != null)
            {
                int ID = GetIDFromStandardstring(listBoxStandardAttributes.SelectedItem.ToString());
                DBManager.GetInstance().ExecuteCommandNonQuery("DELETE FROM StandardAttributes WHERE ID=" + ID.ToString() + ";");
                UpdateStandardAttributesTab();
            }
            else
            {
                MessageBox.Show("Kein gültiges Elemenet ausgewählt!", "My Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }

            deleteStandardattribute.Enabled = false;
        }
    }
}

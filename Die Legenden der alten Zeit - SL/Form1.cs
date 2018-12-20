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
using Die_Legenden_der_Alten_Zeit_Lib.PlayerManagement.NewsSystem;

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
            UpdateNewsTab();
        }

        /// <summary>
        /// Diese Methode kümmert sich um das Updaten des SL-Tabs für die Attribute.
        /// </summary>
        private void UpdateStandardAttributesTab()
        {
            DataTableReader tableReader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM StandardAttributes").CreateDataReader();

            if (tableReader.HasRows)
            {
                int selectedIndex = listBoxStandardAttributes.SelectedIndex;

                listBoxStandardAttributes.ClearSelected();
                listBoxStandardAttributes.Items.Clear();
                standardAttributesRefGroup.Enabled = false;

                while (tableReader.Read())
                {
                    listBoxStandardAttributes.Items.Add(tableReader.GetString(tableReader.GetOrdinal("AttributeKey")) + " {" + tableReader.GetValue(tableReader.GetOrdinal("ID")).ToString() + "}");
                }

                if (selectedIndex < listBoxStandardAttributes.Items.Count)
                {
                    listBoxStandardAttributes.SelectedIndex = selectedIndex;
                    standardAttributesRefGroup.Enabled = true;
                }
            }
            else
            {
                listBoxStandardAttributes.ClearSelected();
                listBoxStandardAttributes.Items.Clear();
                standardAttributeLinkingSpace_List.ClearSelected();
                standardAttributeLinkingSpace_List.Items.Clear();
                standardAttributesRefGroup.Enabled = false;
            }

            standardAttributeID.Text = "";
            standardAttributeWorkingSpace_Name.Text = "";
        }

        /// <summary>
        /// Diese Methode verwaltet das Updaten des News-Tab.
        /// </summary>
        private void UpdateNewsTab()
        {
            List<News> allNews = News.GetAllMainDBNews();
            int index = NewsTab_NewsList.SelectedIndex;
            NewsTab_NewsList.ClearSelected();
            NewsTab_NewsList.Items.Clear();
            foreach (News news in allNews)
            {
                NewsTab_NewsList.Items.Add(news.Name + " {" + news.ID.ToString() + "}");
            }
            if (index < NewsTab_NewsList.Items.Count)
            {
                NewsTab_NewsList.SelectedIndex = index;
            }

            List<string> topics = News.GetAllCurrentTopics();
            NewsTab_Theme.Items.Clear();
            foreach (string topic in topics)
            {
                NewsTab_Theme.Items.Add(topic);
            }

            List<string> places = News.GetAllCurrentPlaceTags();
            NewsTab_Location.Items.Clear();
            foreach (string place in places)
            {
                NewsTab_Location.Items.Add(place);
            }
        }
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
            if (listBoxStandardAttributes.SelectedItem != null)
            {
                int ID = GetIDFromStandardstring(listBoxStandardAttributes.SelectedItem.ToString());

                StandardAttribute attribute = new StandardAttribute(ID);
                standardAttributeID.Text = attribute.ID.ToString();
                standardAttributeWorkingSpace_Name.Text = attribute.Key;
                UpdateStandardAttributeReferences(ID);
                deleteStandardattribute.Enabled = true;
                standardAttributesRefGroup.Enabled = true;
            }
        }

        private void UpdateStandardAttributeReferences(int attID)
        {
            DataTableReader tableReader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM StandardAttributes_References WHERE ID=" + attID.ToString() + ";").CreateDataReader();

            if (tableReader.HasRows)
            {
                int selectedIndex = standardAttributeLinkingSpace_List.SelectedIndex;

                standardAttributeLinkingSpace_List.ClearSelected();
                standardAttributeLinkingSpace_List.Items.Clear();

                while (tableReader.Read())
                {
                    standardAttributeLinkingSpace_List.Items.Add(tableReader.GetString(tableReader.GetOrdinal("ReferencedKey")));
                }

                if (selectedIndex < standardAttributeLinkingSpace_List.Items.Count)
                {
                    standardAttributeLinkingSpace_List.SelectedIndex = selectedIndex;
                }
            }
            else
            {
                standardAttributeLinkingSpace_List.ClearSelected();
                standardAttributeLinkingSpace_List.Items.Clear();
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
            if (askOnce_Standardattributes.Enabled)
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

            if (reader.HasRows)
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
            if (listBoxStandardAttributes.SelectedItem != null)
            {
                int ID = GetIDFromStandardstring(listBoxStandardAttributes.SelectedItem.ToString());
                DBManager.GetInstance().ExecuteCommandNonQuery("DELETE FROM StandardAttributes WHERE ID=" + ID.ToString() + ";");
                DBManager.GetInstance().ExecuteCommandNonQuery("DELETE FROM StandardAttributes_References WHERE ID=" + ID.ToString() + ";");
                UpdateStandardAttributesTab();
            }
            else
            {
                MessageBox.Show("Kein gültiges Element ausgewählt!", "My Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }

            deleteStandardattribute.Enabled = false;
        }

        private void addStandardAttributeReference_Click(object sender, EventArgs e)
        {
            StandardAttribute attribute = GetSelectedStandardAttribute();
            string refKey = standardAttributesReferencedKey.Text;

            if (attribute != null)
            {
                DBManager.GetInstance().ExecuteQuery("INSERT OR REPLACE INTO StandardAttributes_References VALUES(" + attribute.ID.ToString() + ",'" + refKey + "')");
                standardAttributesReferencedKey.Text = "";
                UpdateStandardAttributeReferences(Convert.ToInt32(attribute.ID));
            }
            else
            {
                MessageBox.Show("Fehler! Kein Standardattribute ausgewählt.", "My Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }

        }

        private StandardAttribute GetSelectedStandardAttribute()
        {
            if (listBoxStandardAttributes.SelectedItem != null)
            {
                return new StandardAttribute(GetIDFromStandardstring(listBoxStandardAttributes.SelectedItem.ToString()));
            }
            else
            {
                return null;
            }

        }

        private void NewsTab_NewsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NewsTab_NewsList.SelectedItem != null)
            {
                News news = new News(GetIDFromStandardstring(Convert.ToString(NewsTab_NewsList.SelectedItem)));
                NewsTab_NewsName.Text = news.Name;
                NewsTab_Location.Text = news.PlaceTag;
                NewsTab_Theme.Text = news.Topic;
                NewsTab_Text.LoadFile(AppDomain.CurrentDomain.BaseDirectory + news.RTFPath, RichTextBoxStreamType.RichText);
            }
        }

        private void NewsTab_NewNews_Click(object sender, EventArgs e)
        {
            NewsTab_NewsList.ClearSelected();
            NewsTab_NewsName.Text = "";
            NewsTab_Location.Text = "";
            NewsTab_Theme.Text = "";
            NewsTab_Text.Clear();
        }

        private void NewsTab_SaveNews_Click(object sender, EventArgs e)
        {
            if (NewsTab_NewsList.SelectedItem == null)
            {
                string path = "/Content/Docs/News/" + NewsTab_NewsName.Text + ".rtf";
                News tmp = new News(NewsTab_NewsName.Text, NewsTab_Theme.Text, path, NewsTab_Location.Text);
                NewsTab_Text.SaveFile(AppDomain.CurrentDomain.BaseDirectory + path, RichTextBoxStreamType.RichText);
            }
            UpdateNewsTab();
        }
    }
}

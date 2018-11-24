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

using Die_Legenden_der_alten_Zeit___SL.Sources.DB_Management;
using Die_Legenden_der_alten_Zeit___SL.Sources.EffectSystem;

using Zeus.Hermes;

namespace Die_Legenden_der_alten_Zeit___SL
{
    public partial class Form1 : Form
    {
        private DBManager dbManager;
        private GlobalEffectSystem globalEffectSystem;

        public Form1()
        {
            InitializeComponent();
            dbManager = DBManager.GetInstance();
            globalEffectSystem = GlobalEffectSystem.GetInstance();
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
            UpdatePlayersAndNPCsTab();
        }

        private void UpdatePlayersAndNPCsTab()
        {
            int playerPlayerListIndex = 0;

            if(PlayerPlayerList.SelectedIndex != null)
            {
                playerPlayerListIndex = PlayerPlayerList.SelectedIndex;
            }

            PlayerPlayerList.ClearSelected();
            LoadPlayerTab();
            if(PlayerPlayerList.Items.Count > playerPlayerListIndex)
            {
                PlayerPlayerList.SelectedIndex = playerPlayerListIndex;
            }
            else
            {
                PlayerPlayerList.SelectedIndex = 0;
            }

        }
        #endregion

        #region loadElements
        private void LoadPlayerTab()
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(DBManager.GetInstance().MainConnectionString);
            sQLiteConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT PlayerName FROM Players", sQLiteConnection);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataSet.Reset();
            dataAdapter.Fill(dataSet);
            PlayerPlayerList.DataSource = dataSet.Tables[0];
            PlayerPlayerList.DisplayMember = "PlayerName";
            PlayerPlayerList.ValueMember = "PlayerName";
            sQLiteConnection.Close();
        }
        #endregion

        private void PlayersChange_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            SelectPlayerProfile.Title = "Wähle ein Bild für den Spieler aus";
            SelectPlayerProfile.Filter = "Bilder|*.png; *.jpg; *.jpeg; *.bmp";
            if(SelectPlayerProfile.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPlayerProfile.ImageLocation = SelectPlayerProfile.FileName;
                dbManager.ExecuteCommandNonQuery("UPDATE Players SET ProfilePicturePath='" + SelectPlayerProfile.FileName + "' WHERE PlayerName='Jörn'");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hermes.getInstance().shutdownHermes();
        }
    }
}

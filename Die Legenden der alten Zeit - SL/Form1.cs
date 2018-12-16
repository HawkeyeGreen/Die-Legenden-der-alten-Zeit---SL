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

        }

        #endregion

        #region loadElements
        #endregion


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hermes.getInstance().shutdownHermes();
        }
    }
}

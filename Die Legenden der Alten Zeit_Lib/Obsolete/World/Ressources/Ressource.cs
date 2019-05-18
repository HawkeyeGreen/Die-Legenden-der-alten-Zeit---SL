using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Zeus.Hermes;
using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;

namespace Die_Legenden_der_Alten_Zeit_Lib.World.Ressources
{
    /// <summary>
    /// Ressourcen werden von Ressourcenquellen gewonnen oder von speziellen Gebäuden generiert.
    /// </summary>
    public class Ressource : HermesLoggable
    {
        private int _ID;
        private string name;
        private string imgPath;
        private string descrPath;
        private List<string> tags = new List<string>();

        public long ID => _ID;
        public string Type => "Ressource";
        public string Name
        {
            get => name;
            set => name = value;
        }
        public List<string> Tags => tags;

        public Ressource(int ID)
        {
            Load(ID);
        }

        public Ressource(string Name, string imgPath, string descrPath)
        {

        }

        public void SaveChanges()
        {

        }

        private void Load(int ID)
        {
            DataTableReader reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM Ressources WHERE ID=" + ID.ToString() + ";").CreateDataReader();
            reader.Read();
            if (reader.HasRows)
            {
                _ID = ID;
                name = Convert.ToString(reader.GetValue(reader.GetOrdinal("name")));
                imgPath = Convert.ToString(reader.GetValue(reader.GetOrdinal("img")));
                descrPath = Convert.ToString(reader.GetValue(reader.GetOrdinal("descr")));
                Hermes.getInstance().log(this, "A Ressource-Entry was loaded from the main database and is ready for use. \n Name: " + Name);
                reader.Close();
                reader = DBManager.GetInstance().ExecuteQuery("SELECT * FROM RessourceTags WHERE resID=" + ID.ToString() + ";").CreateDataReader();
                reader.Read();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        tags.Add(Convert.ToString(reader.GetValue(reader.GetOrdinal("tag"))));
                    }
                }
                else
                {
                    Hermes.getInstance().log(this, "The Ressource doesn't have tags!");
                }
                reader.Close();
            }
            else
            {
                Hermes.getInstance().log(this, "It was attempted to load a Ressource with the following ID - but there was no entry! ID: " + ID.ToString());
                Hermes.getInstance().log(this, "The DUMMY-Entry will be used.");
                Load(0); // Lade Dummy
            }
        }
    }
}

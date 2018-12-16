using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Die_Legenden_der_Alten_Zeit_Lib.DB_Management;
using System.Data;
using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.EffectSystem
{
    /* Klasse: GlobalEffectSystem
     * !Stets nur eine Instanz - Singleton!
     * 
     * 
     */
    public class GlobalEffectSystem : HermesLoggable
    {
        public long ID => 1339;
        public string Type => "GlobalEffectSystem";

        private static GlobalEffectSystem currentInstance;

        private DBManager DB = DBManager.GetInstance();

        private int nextID;

        private GlobalEffectSystem()
        {
            Hermes.getInstance().log(this, "GlobalEffectSystem was instanced.");
            DataTableReader reader = DB.ExecuteQuery("SELECT MAX(eID) FROM gEffectTable").CreateDataReader();
            reader.Read();
            nextID = Convert.ToInt32(reader["MAX(eID)"]) + 1;
            reader.Close();
            Hermes.getInstance().log(this, "The next free ID is " + Convert.ToString(nextID));
        }

        public static GlobalEffectSystem GetInstance()
        {
            if(currentInstance == null)
            {
                currentInstance = new GlobalEffectSystem();
            }

            return currentInstance;
        }
    }
}

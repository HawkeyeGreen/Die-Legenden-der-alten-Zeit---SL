using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zeus.Hermes;

namespace Die_Legenden_der_Alten_Zeit_Lib.Nations.StorageMeans
{
    class StorageRequest : HermesLoggable
    {
        private int _ID;

        public long ID => _ID;
        public string Type => "StorageRequest";
    }
}

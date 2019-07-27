using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Helper
{
    /// <summary>
    /// Stellt dar, zu was eine Sache (wie eine Lieferung) gebunden ist.
    /// </summary>
    public enum BoundTo
    {
        // Gebunden an SL-Macht
        SL,
        // Gebunden an eine Nation
        Nation,
        // Gebunden an eine Fraktion
        Faction,
        // Gebunden an eine Seite (Dunkelheit, Licht, Gleichgewicht)
        Side,
        // Gaia, Tiere etc
        Nature,
        // An Nichts als sich selbst
        Free
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.World.Ressources
{
    /// <summary>
    /// Eine Quelle vereint eine Ressource mit ihrer Herkunft.
    /// Die Quelle berechnet jede Runde die Regeneration ihrer Ressourcen sowie die Auswirkung etwaiger Schäden.
    /// Dazu können Arbeiter auf dem Tile GatherRessources aufrufen, wobei das Tile wiederum dann einfach GatherRessources auf der Source aufruft.
    /// </summary>
    class Source
    {
        private int _ID;
        private int RessourceID;
        private (string type, int ID) Bound;
    }
}

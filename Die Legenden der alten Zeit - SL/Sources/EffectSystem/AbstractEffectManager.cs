using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_alten_Zeit___SL.Sources.EffectSystem
{
    /**
     * Klasse: AbstractEffectManager
     * Der EffectManager wird für verschiedene Typen von effektbetreffbaren Dingen abgeleitet.
     * Dabei ist der EffeCtManager zuständig für das Einstellen und Auslesen von Effekten. Er verwendet dafür das
     * GlobalEffeCtManagement, entscheidet aber nicht, ob ein Effekt trifft oder nicht.
     * 
     * Diese Entscheidungen muss der Nutzer des EffectManager treffen. Er handelt mit seinen Zielen aus, ob sie - wovon immer - getroffen werden können.
     * Dann nutzt der EffektWirker seinen EffectManager, um den Effekt via GlobalEffectSystem in den EffectTable der Database zu pushen.
     */
    class AbstractEffectManager
    {

    }
}

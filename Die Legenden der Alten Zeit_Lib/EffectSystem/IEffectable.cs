using Die_Legenden_der_Alten_Zeit_Lib.EffectSystem.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.EffectSystem
{
    /// <summary>
    /// Dieses Interface ermöglicht es dem Ziel Effekte zu übergeben und von anderen zu erhalten 
    /// </summary>
    interface IEffectable
    {
        EffectManager GetEffectManager();
    }
}

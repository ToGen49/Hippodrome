/*

CTemperatureAir.cs

Auteur : Fabien DAVID
Date de création : 21/03/2025, 11:45
Dernière modification : 26/03/2025, 08:36
Justification : Modification du niveau de protection du constructeur

Classe héritant de CInfoMeteo
Elle va agir comme une classe contrôle.
Elle se charge de communiquer avec les objets CAPI et CJsonMeteo.
Cette classe est spécialisée sur la température de l'air

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAppFabien
{
    public class CTemperatureAir : CInfoMeteo
    {
        public CTemperatureAir() : base() { mStrDataType = "TemperatureAir"; }
        ~CTemperatureAir() { }

        public CTemperatureAir(CAPI objCAPI) : base(objCAPI)
        {
            mStrDataType = "TemperatureAir";
        }
    }
}

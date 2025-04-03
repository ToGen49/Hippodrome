/*

CPluviometrie.cs

Auteur : Fabien DAVID
Date de création : 25/03/2025, 11:20
Dernière modification : 26/03/2025, 08:36
Justification : Modification du niveau de protection du constructeur

Classe héritant de CInfoMeteo
Elle va agir comme une classe contrôle.
Elle se charge de communiquer avec les objets CAPI et CJsonMeteo.
Cette classe est spécialisée sur la pluviométrie

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAppFabien
{
    internal class CPluviometrie : CInfoMeteo
    {
        public CPluviometrie() : base() { mStrDataType = "Pluviometrie"; }
        ~CPluviometrie() { }
        public CPluviometrie (CAPI objCAPI) : base(objCAPI) 
        {
            mStrDataType = "Pluviometrie";
        }
    }
}

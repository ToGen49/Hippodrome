/*

CEnsoleillement.cs

Auteur : Fabien DAVID
Date de création : 25/03/2025, 14:43
Dernière modification : 26/03/2025, 08:36
Justification : Modification du niveau de protection du constructeur

Classe héritant de CInfoMeteo
Elle va agir comme une classe contrôle.
Elle se charge de communiquer avec les objets CAPI et CJsonMeteo.
Cette classe est spécialisée sur l'ensoleillement

L'ensoleillement n'a pas besoin d'être affichée sur l'API mais est nécéssaire
pour calculer l'evapotranspiration

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAppFabien
{
    internal class CEnsoleillement : CInfoMeteo
    {
        public CEnsoleillement() : base() { mStrDataType = "Ensoleillement"; }
        ~CEnsoleillement() { }
        public CEnsoleillement(CAPI objCAPI) : base(objCAPI)
        {
            mStrDataType = "Ensoleillement";
        }
    }
}

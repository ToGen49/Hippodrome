/*

CInfoArrosage.cs

Auteur : Fabien DAVID
Date de création : 25/03/2025, 11:11
Dernière modification : 26/03/2025, 08:36
Justification : Modification du niveau de protection du constructeur

Classe CInfoArrosage implémentant ICInfoGenerale
Elle va agir comme une classe contrôle.
Elle se charge de communiquer avec les objets CAPI et CJsonArrosage.
Cette classe est spécialisée sur l'arrosage

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAppFabien
{
    internal class CInfoArrosage //:ICInfoGenerale
    {
        private String mstrDataType;

        public CInfoArrosage() { mstrDataType = "Arrosage"; }
        ~CInfoArrosage () { }

    }
}

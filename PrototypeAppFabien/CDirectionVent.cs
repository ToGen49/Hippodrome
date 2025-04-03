/*

CDirectionVent.cs

Auteur : Fabien DAVID
Date de création : 25/03/2025, 10:54
Dernière modification : 26/03/2025, 08:36
Justification : Modification du niveau de protection du constructeur

Classe héritant de CInfoMeteo implémentant ICInfoGenerale
Elle va agir comme une classe contrôle.
Elle se charge de communiquer avec les objets CAPI et CJsonMeteo.
Cette classe est spécialisée sur la direction du vent

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAppFabien
{
    internal class CDirectionVent : CInfoMeteo
    {
        public CDirectionVent() : base() { mStrDataType = "DirectionVent"; }
        ~CDirectionVent() { }
        public CDirectionVent(CAPI objCAPI) : base(objCAPI)
        {
            mStrDataType = "DirectionVent";
        }

        public String mstrConvertionValRecente()
        {
            /* Méthode qui convertit la valeur du la données la plus récente en une direction lisible
             * La données à 8 valeurs différentes possibles, elle est donc précise à 45°
             */ 

            //On prend la valeur recente en short
            short shtAConvertir = (short)mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur;
            String strConvertit;

            switch (shtAConvertir)
            {
                case 0:
                    strConvertit = "Nord";
                    break;
                case 1:
                    strConvertit = "Nord Est";
                    break;
                case 2:
                    strConvertit = "Est";
                    break;
                case 3:
                    strConvertit = "Sud Est";
                    break;
                case 4:
                    strConvertit = "Sud";
                    break;
                case 5:
                    strConvertit = "Sud Ouest";
                    break;
                case 6:
                    strConvertit = "Ouest";
                    break;
                case 7:
                    strConvertit = "Nord Ouest";
                    break;
                default:
                    strConvertit = "Erreur Valeur";
                    break;
            }

            return strConvertit; 
        }
    }
}

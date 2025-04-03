/*

CAPI.cs

Auteur : Fabien DAVID
Date de création : 24/03/2025, 08:19
Dernière modification : 26/03/2025, 08:36
Justification : Modification du niveau de protection du constructeur

Classe permettant de faire des demandes à l'API
Elle est exploitée par les classes implémentant l'interface ICInfoGenerale

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAppFabien
{
    public class CAPI
    {
        //Déclaration des attributs
        private String mStrAddrAPI;
        private String mStrPortAPI;
        private String mStrQuerry;

        //Déclaration des méthodes
        public CAPI() { }
        CAPI(String strAddrAPI)
        {
            mStrAddrAPI = strAddrAPI;
        }

        ~CAPI() { }

        public int mintfunWriteDdeQuerry(
            String strTargetData,       // La données visée ("TemperatureAir", "Hygrometrie", ...)
            DateTime dtmDateDeDebut,    // Date de la données la plus récente voulue
            DateTime dtmDateDeFin,      // Date de la donnée la plus ancienne voulue
            short shrtFrequence         // Lapse de temps entre chaque données envoyée en heure
                                        // Si l'on doit prendre les données sur une journée (24h) et que fréquence est égale à 4, alors on devrait recevoir 6 données
            )
        {


            return 0;
        }

        public String mStrFunGetmStrAddrAPI()
        { return mStrAddrAPI; }

        public void mVFunSetmstrAddrAPI(String strAddresse)
        {
            mStrAddrAPI = strAddresse;
        }

        public String mStrFunSendGetQuerry()
        {
            //Send

            string filepathexample = @"E:\2eme_année\Spécialité\Projet_Hippodrome\Application\example.json";
            string response = System.IO.File.ReadAllText(filepathexample);
            return response;
        }
    }
}

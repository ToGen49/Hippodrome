/*

CInfoMeteo.cs

Auteur : Fabien DAVID
Date de création : 21/03/2025, 10:49
Dernière modification : 01/04/2025, 16:08
Justification :
Création de la méthode mstrfunSendGetQuerry()
Déplacement de certaines lignes de la méthode mvfunUpdatemlstobjCJsonMeteo(DateTime dtmDateDeDebut, DateTime dtmDateDeFin)
vers la méthode mstrfunSendGetQuerry()

Classe implémentant ICInfoGenerale
Elle va agir comme une classe contrôle.
Elle se charge de communiquer avec les objets CAPI et CJsonMeteo.
La classe en elle même ne peut pas demander des données a un objet CAPI.
Ses héritiés ne seront spécialisés que sur un seul type d'information météorologique et pourront demander des données à un objet CAPI

*/

using PrototypeAppFabien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrototypeAppFabien.Properties;
using System.Text.Json;

namespace PrototypeAppFabien
{
    public class CInfoMeteo : ICInfoGenerale
    {        
        protected String mStrDataType;
        protected CAPI mObjCAPI;
        private List<CJsonMeteo> mLstObjCJsonMeteo;
        private CJsonMeteo mObjCJsonMeteoRecent;

        public CInfoMeteo()
        {
            /* Constructeur de classe par défaut
             * Instanciation de l'attribut mobjCJsonMeteoValeurRecente
             * On y met des valeurs par défaut éronnées qui seront remplacées plus tard
             * 
             * mstrDataType à la valeur "NonDefinit", ce n'est pas une valeur
             * exploitable pour un objet CAPI
            */

            mObjCJsonMeteoRecent = new CJsonMeteo();
            mObjCJsonMeteoRecent.mfltValeur = 0.01F;
            mObjCJsonMeteoRecent.mdtmDate = DateTime.MinValue;
            mStrDataType = "NonDefini";
        }

        public CInfoMeteo(CAPI objCAPI) 
        {
            /* Constructeur de classe avec en paramètre un objet CAPI
             * Instanciation de l'attribut mobjCJsonMeteoValeurRecente
             * On y met des valeurs par défaut éronnées qui seront remplacées plus tard
             * 
             * mstrDataType à la valeur "NonDefinit", ce n'est pas une valeur
             * exploitable pour un objet CAPI
             * 
             * On met en place l'assocaition vers un objet CAPI
            */

            mObjCJsonMeteoRecent = new CJsonMeteo();
            mObjCJsonMeteoRecent.mfltValeur = 0.01F;
            mObjCJsonMeteoRecent.mdtmDate = DateTime.MinValue;

            mStrDataType = "NonDefinit";

            mObjCAPI = objCAPI;
        }

        ~CInfoMeteo(){
            /* Destructeur de classe
             * On supprime l'attribut mlstobjCJsonMeteo
             * On supprime l'attribut mobjCJsonMeteoValeurRecente
             * On supprime l'assocation avec l'objet CAPI
             */

            //La liste CJsonMeteo ne compose plus l'objet
            mLstObjCJsonMeteo = null;
            mObjCJsonMeteoRecent = null;
            mObjCAPI = null;
        }

        //get de l'attribut mstrDataType
        String ICInfoGenerale.mStrGetDataType()
        {
            return mStrDataType; 
        }
        void ICInfoGenerale.mVFunSetAssoCAPI(CAPI objCAPI) 
        {
            mObjCAPI = objCAPI;
        }

        public CAPI mCAPIFunGetmObjCAPI() { return mObjCAPI; }

        public float mFltFunCalculMoyennePeriode(DateTime dtmDateDeDebut,DateTime dtmDateDeFin)
        {
            /* mfltfunCalculMoyennePeriode(DateTime dtmDateDeDebut,DateTime dtmDateDeFin)
             * Méthode permettant de faire une moyenne des valeurs d'une liste de CJSonMeteo
             * Elle fait la moyenne de ces valeurs sur une période de temps
             * La période de temps pour faire la moyenne peut être inférieur 
             * à la période de temps totale de la liste d'objet CJsonMeteo
             */
            float fltMoyenne;
            int i;
            int nbrElementTotal;
            int intlengthmlstobjCJsonMeteo = mLstObjCJsonMeteo.Count;

            fltMoyenne = 0.0F;
            nbrElementTotal = 0;
            i = 0;

            while (i < intlengthmlstobjCJsonMeteo-1 && mLstObjCJsonMeteo[i].mdtmDate > dtmDateDeDebut)
            {
                if(mLstObjCJsonMeteo[i].mdtmDate < dtmDateDeFin)
                {
                    fltMoyenne += mLstObjCJsonMeteo[i].mfltValeur;
                    nbrElementTotal++;
                }
                i++;
            }

            fltMoyenne = fltMoyenne / (float)nbrElementTotal;

            return fltMoyenne;
        }

        //  get de mlstobjCJsonMeteo
        public List<CJsonMeteo> mLstCJsonMeteoFunGetmLstObjCJsonMeteo(){return mLstObjCJsonMeteo; }

        //  set de mlstobjCJsonMeteo, demande en paramètre un string
        public void mvfunsetmlstobjCJsonMeteo(string strDonneesAConvertir)
        {
            mLstObjCJsonMeteo = new List<CJsonMeteo>(JsonSerializer.Deserialize<List<CJsonMeteo>>(strDonneesAConvertir));
            if (
                mLstObjCJsonMeteo[0].mdtmDate >= mObjCJsonMeteoRecent.mdtmDate
                )
            {
                mObjCJsonMeteoRecent = new CJsonMeteo();
                mObjCJsonMeteoRecent = mLstObjCJsonMeteo[0];
            }
            return;
        }

        //  get de mobjCJsonMeteoValeurRecente
        public CJsonMeteo mCJsonMeteoFunGetmObjCJsonMeteoRecent()
        {
            return mObjCJsonMeteoRecent;
        }

        private short mshtCalculFrequence(DateTime dtmDateDeDebut, DateTime dtmDateDeFin)
        {
            short shtFrequence;
            TimeSpan tmsTimespanDateDebutFin;
            // Difference entre la date de début et la date de fin
            tmsTimespanDateDebutFin = dtmDateDeFin.Subtract(dtmDateDeDebut);

            /*
             * On veut une information toute les shtFrequence d'heure
             * Elle peut être plus ou moins élevée selon la période de temps sélectionnée
             * Cette fréquence doit être inférieur ou égale à 12
             * Cette fréquence doit être un multiple de 24
             * 
             * On prend le nombre de jour de la
             * difference entre la date de début et la date de fin sélectionnés
             * Puis on lui fait une division euclidienne par 7
             * On lui rajoute 1
             * Cela nous donne la fréquence
             */
            shtFrequence = (short)((tmsTimespanDateDebutFin.Days / 7) + 1);

            //On s'assure que la fréquence ne dépasse pas 12
            if (shtFrequence >= 10)
                shtFrequence = 12;

            //Les multiples de 24 sont : 1,2,3,4,6,8,12
            //Si shtFrequence n'est pas égale à l'une de ces valeurs, alors on la force

            if (shtFrequence == 5)
                shtFrequence = 4;
            if (shtFrequence == 7)
                shtFrequence = 6;
            if (shtFrequence == 9)
                shtFrequence = 8;

            /* Avec ces calculs, on peut établir le nombre de valeur par jour selon la durée
             *
             *  Différence de jour  :   Valeur par jour
             *          0 - 6       :   24
             *          7 - 13      :   12
             *          14 - 20     :   8
             *          21 - 34     :   6
             *          35 - 48     :   4
             *          49 - 62     :   3
             *          x > 62      :   2
             */

            return shtFrequence;
        }
        public void mvfunUpdatemlstobjCJsonMeteo(DateTime dtmDateDeDebut, DateTime dtmDateDeFin)
        {
            /*
             * mvfunSetmlstobjCJsonMeteo(DateTime dtmDateDeDebut, DateTime dtmDateDeFin)
             *  dtmDateDeDebut  : Date de la donnée la plus ancienne souhaitée (exemple : 09/09/2025)
             *  dtmDateDeFin    : Date de la donnée la plus récente souhaitée (exemple : 13/09/2025)
             *
             * La méthode calcule un paramètre, la fréquence
             *  La fréquence indique l'espace de temps en heure entre chaque données
             *  Une fréquence de 3 veut dire que l'on a 8 données en 24h
             *  
             * Elle transmet les paramètres à CAPI pour former et envoyer la requête
             * 
             * Enfin, elle passe en plus en paramètre son mstrDataType pour préciser
             * quel est son type de données
             *  mstrDataType n'a pas de set, elle est seulement modifiée dans les constructeurs
             *  des héritiés de CInfoMeteo
             *  
             * Ensuite, elle récupère le retour, c'est un json sous forme de string
             * 
             * Elle traduit ce string en une liste d'objet CJsonMeteo
             * 
             * Enfin, une valeur est plus récente que mobjCJsonMeteoValeurRecente, alors elle remplace mobjCJsonMeteoValeurRecente
             */

            short shtFrequence;

            shtFrequence = mshtCalculFrequence(dtmDateDeDebut, dtmDateDeFin);

            mObjCAPI.mintfunWriteDdeQuerry(
                mStrDataType,
                dtmDateDeDebut,
                dtmDateDeFin,
                shtFrequence
                );

            //Envoi de la demande et réception
            String strRawJsonString = mObjCAPI.mStrFunSendGetQuerry();

            //Conversion de la réception en liste d'objet CJsonMeteo
            //Cette méthode vérifie aussi que la valeur la plus récente soit toujours la plus récente
            mvfunsetmlstobjCJsonMeteo(strRawJsonString);

            //Deplacer dans le setCJsonMeteo

            return;
        }
    }


}

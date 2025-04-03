/*

CEvapotranspiration.cs

Auteur : Fabien DAVID
Date de création : 31/03/2025, 08:22
Dernière modification : 31/03/2025, 08:22
Justification : X

Classe CEvapotranspiration hérite de CInfoMeteo
La donnée de l'évapotranspiration est un calcul, elle n'est pas fournie par l'API
Le calcul nécéssite plusieurs données fournie par l'API
Elle agit donc comme une classe controle

*/

using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAppFabien
{
    internal class CEvapotranspiration : CInfoMeteo
    {
        private CTemperatureAir mObjCTemperatureAir;
        private CHygrometrie mObjCHygrometrie;
        private CVitesseVent mObjCVitesseVent;
        private CEnsoleillement mObjCEnsoleillement;
        private float mFltAlbedo = 0.23F; // Albedo de l'hippodrome concerné, peut être changé
        private float mFltAltitude = 46.8F; // Altitude de l'hippodrome concerné, peut être changé

        #region Constructeurs et destructeur de classe
        public CEvapotranspiration() {}
        public CEvapotranspiration(CAPI objCAPI) : base (objCAPI) { }
        public CEvapotranspiration(
                    CAPI objCAPI,
                    CTemperatureAir objCTemperatureAir,
                    CHygrometrie objCHygrometrie,
                    CVitesseVent objCVitesseVent,
                    CEnsoleillement objCEnsoleillement
                    ) : base(objCAPI) 
        { 
            this.mObjCTemperatureAir = objCTemperatureAir;
            this.mObjCHygrometrie = objCHygrometrie;
            this.mObjCVitesseVent = objCVitesseVent;
            this.mObjCEnsoleillement = objCEnsoleillement;
        }

        ~CEvapotranspiration() { }
        #endregion

        #region Méthodes liés aux associations
        public void mVFunSetAssoCTemperatureAir(CTemperatureAir objCTemperatureAir)
        {
            this.mObjCTemperatureAir = objCTemperatureAir;
        }

        public void mVFunSetAssoCHygrometrie(CHygrometrie objCHygrometrie)
        {
            this.mObjCHygrometrie = objCHygrometrie;
        }

        public void mVFunSetAssoCVitesseVent(CVitesseVent objCVitesseVent)
        {
            this.mObjCVitesseVent = objCVitesseVent;
        }
        public int mVFunSetAssoCEnsoleillement(CEnsoleillement objCEnsoleillement)
        {
            this.mObjCEnsoleillement = objCEnsoleillement;
            return 0;
        }
        #endregion

        #region get et set des attributs
        public float mFltFunGetmFltAlbedo() { return this.mFltAlbedo; }
        public void mVFunSetmFltAlbedo(float fltAlbedo) { this.mFltAlbedo = fltAlbedo; }

        public float mFltFunGetmFltAltitude() {  return this.mFltAltitude; }
        public void mVFunSetmFltAltitude(float fltAltitude) {  this.mFltAltitude = fltAltitude; }
        #endregion

        public float mfltCalculEvapotranspiration(DateTime dtmDateDeDebut, DateTime dtmDateDeFin)
        {
            //Element à renvoyer
            float fltEvapotranspiration;

            //Si L'evapotranspiration n'est pas calculée, la méthode renvoie une valeur impossible
            fltEvapotranspiration = -1.0F;

            //La période de calcul de l'évapotranspiration est de minimum un jour
            TimeSpan tmsDateDebutFin;
            tmsDateDebutFin = new TimeSpan();
            tmsDateDebutFin = dtmDateDeFin.Subtract(dtmDateDeDebut);

            if (tmsDateDebutFin.Days > 0)
            {
                #region Déclaration des variables de méthodes
                //Moyennes utilisées dans le calcul
                float fltMoyenneTemperatureAir;
                float fltMoyenneHygrometrie;
                float fltMoyenneVitesseVent;
                float fltMoyenneEnsoleillement;

                //Constantes
                //Modifiable ici ou dans le constructeur de classe CEvapotranspiration
                float fltAlbedo = mFltAlbedo; //Si non modifiée, 0.23
                float fltAltitude = mFltAltitude; // Si non modifiée, 48.6 (mètre)

                //Sous calcul utilisant les moyennes et autres constantes
                float fltMoyenneVitesseVent2m;
                float fltRGNet;
                float fltPressionVapeurSaturee;
                float fltPressionVapeurEffective;
                float fltPenteCourbePressionVapeurSaturee;
                float fltPressionAtmospherique;
                float fltConstantePsychometrique;
                #endregion

                #region Calcul des moyennes
                fltMoyenneTemperatureAir = this.mObjCTemperatureAir.mFltFunCalculMoyennePeriode(dtmDateDeDebut, dtmDateDeFin);
                fltMoyenneHygrometrie = this.mObjCHygrometrie.mFltFunCalculMoyennePeriode(dtmDateDeDebut, dtmDateDeFin);
                fltMoyenneVitesseVent = this.mObjCVitesseVent.mFltFunCalculMoyennePeriode(dtmDateDeDebut, dtmDateDeFin);
                fltMoyenneEnsoleillement = this.mObjCEnsoleillement.mFltFunCalculMoyennePeriode(dtmDateDeDebut, dtmDateDeFin);

                // A ENLEVER
                fltMoyenneVitesseVent = 3.3F;
                fltMoyenneEnsoleillement = 500F / 11.575F; //Conversion de W/m² en MJ/m²/j
                fltMoyenneHygrometrie = 50F;
                fltMoyenneTemperatureAir = 13.5F;
                #endregion

                #region Calcul des sous calculs
                fltMoyenneVitesseVent2m = fltMoyenneVitesseVent;
                //fltMoyenneVitesseVent2m = fltMoyenneVitesseVent * 0.7; //Enlever commentaire sur la vitesse du vent est prélevée à 10m du sol

                fltRGNet = 1F - fltAlbedo;
                fltRGNet = fltMoyenneEnsoleillement * fltRGNet;

                fltPressionVapeurSaturee = (float)
                    (0.6108F * Math.Exp(
                        (17.27F * fltMoyenneTemperatureAir)
                        / (237.3F + fltMoyenneTemperatureAir)));

                fltPressionVapeurEffective = fltPressionVapeurSaturee * fltMoyenneHygrometrie / 100F;

                fltPenteCourbePressionVapeurSaturee = 4098F * fltPressionVapeurSaturee / (float)Math.Pow((237.3F + fltMoyenneTemperatureAir), 2F); ;

                fltPressionAtmospherique = (float)(101.3 * Math.Pow((293D - 0.0065 * fltAltitude) / 293D, 5.26));

                fltConstantePsychometrique = 0.665F * fltPressionAtmospherique * (float)Math.Pow(10D, -3D);
                #endregion

                #region Le calcul de l'evapotranspiration

                fltEvapotranspiration =
                    ((0.408F * fltPenteCourbePressionVapeurSaturee * fltRGNet) + ((fltConstantePsychometrique * 900F) / (273F + fltMoyenneTemperatureAir)) * fltMoyenneVitesseVent2m * (fltPressionVapeurSaturee - fltPressionVapeurEffective)) /
                    (fltPenteCourbePressionVapeurSaturee + (fltConstantePsychometrique * (1 + 0.34F * fltMoyenneVitesseVent2m)));
                #endregion
            }
            else
            {
                Console.WriteLine("Période de données pas assez grande");
                //Si L'evapotranspiration n'est pas calculée, la méthode renvoie une valeur impossible
                fltEvapotranspiration = -1.0F;
            }
            return fltEvapotranspiration;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PrototypeAppFabien
{
    public partial class Pageprincipale : Form
    {

        CAPI gobjCAPI;
        CTemperatureAir gobjCTemperatureAir;
        CPluviometrie gobjCPluviometrie;
        CHygrometrie gobjCHygrometrie;
        CVitesseVent gobjCVitesseVent;
        CDirectionVent gobjCDirectionVent;
        CEnsoleillement gobjCEnsoleillement;
        CEvapotranspiration gobjCEvapotranspiration;

        public Pageprincipale()
        {

            gobjCAPI = new CAPI();
            gobjCTemperatureAir = new CTemperatureAir(gobjCAPI);
            gobjCPluviometrie = new CPluviometrie(gobjCAPI);
            gobjCHygrometrie = new CHygrometrie(gobjCAPI);
            gobjCVitesseVent = new CVitesseVent(gobjCAPI);
            gobjCDirectionVent = new CDirectionVent(gobjCAPI);
            gobjCEnsoleillement = new CEnsoleillement(gobjCAPI);
            gobjCEvapotranspiration = new CEvapotranspiration(gobjCAPI, gobjCTemperatureAir, gobjCHygrometrie, gobjCVitesseVent, gobjCEnsoleillement);

            InitializeComponent();
            gdtmpDateDeDebut.MaxDate = DateTime.Now;
            gdtmpDateDeFin.MaxDate = DateTime.Now;

            gdtmpDateDeFin.Value = DateTime.Now;
            gdtmpDateDeDebut.Value = DateTime.Now.Subtract(new TimeSpan(7,0,0,0));

            gobjCTemperatureAir.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCPluviometrie.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCHygrometrie.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCVitesseVent.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCDirectionVent.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCEnsoleillement.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);

            glblTemperatureAir.Text = String.Concat("Température air : ", gobjCTemperatureAir.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur.ToString(), " °C");
            gtltToolTipGlobal.SetToolTip(glblTemperatureAir, String.Concat("Température de l'air prélevée le ",gobjCTemperatureAir.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblPluviometrie.Text = String.Concat("Pluviométrie: ", gobjCPluviometrie.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur.ToString(), " mm");
            gtltToolTipGlobal.SetToolTip(glblPluviometrie, String.Concat("Pluviométrie prélevée le ", gobjCPluviometrie.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblHygrometrie.Text = String.Concat("Hygrométrie: ", gobjCHygrometrie.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur.ToString(), " %");
            gtltToolTipGlobal.SetToolTip(glblHygrometrie, String.Concat("Hygrométrie prélevée le ", gobjCHygrometrie.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblVitesseVent.Text = String.Concat("Vitesse du vent : ", (gobjCVitesseVent.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur*3.6).ToString(), " km/h");
            gtltToolTipGlobal.SetToolTip(glblVitesseVent, String.Concat("Vitesse du vent prélevée le ", gobjCVitesseVent.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblDirectionVent.Text = String.Concat("Direction du vent : ", gobjCDirectionVent.mstrConvertionValRecente());
            gtltToolTipGlobal.SetToolTip(glblDirectionVent, String.Concat("Direction du vent prélevée le ", gobjCDirectionVent.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblEvapotranspiration.Text = String.Concat("Evapotranspiration : ", Math.Round(gobjCEvapotranspiration.mfltCalculEvapotranspiration(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value),2).ToString(), " mm/j");
            gtltToolTipGlobal.SetToolTip(glblEvapotranspiration, String.Concat("Evapotranspiration calculée avec la formule\r\nde Penman Monteith qui nécéssite :\r\n" +
        "- Température air\r\n- Hygrométrie\r\n- Vitesse vent\r\n- Ensoleillement","\nValeur calculée sur la plage de ",gdtmpDateDeDebut.Value.ToString()," à ", gdtmpDateDeFin.Value.ToString()));

        }

        private void glblRajouterDateArrosage_MouseClick(object sender, MouseEventArgs e)
        {
            //OUVRIR NOUVELLE PAGE COMME PR DP OBSERVEUR
        }

        private void gdtmpDateDeFin_ValueChanged(object sender, EventArgs e)
        {
            gdtmpDateDeDebut.MaxDate = gdtmpDateDeFin.Value;
        }

        private void gbtmConfirmationDate_Click(object sender, EventArgs e)
        {
            gobjCTemperatureAir.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCPluviometrie.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCHygrometrie.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCVitesseVent.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCDirectionVent.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);
            gobjCEnsoleillement.mvfunUpdatemlstobjCJsonMeteo(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value);

            glblTemperatureAir.Text = String.Concat("Température air : ", gobjCTemperatureAir.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur.ToString(), " °C");
            gtltToolTipGlobal.SetToolTip(glblTemperatureAir, String.Concat("Température de l'air prélevée le ", gobjCTemperatureAir.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblPluviometrie.Text = String.Concat("Pluviométrie: ", gobjCPluviometrie.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur.ToString(), " mm");
            gtltToolTipGlobal.SetToolTip(glblPluviometrie, String.Concat("Pluviométrie prélevée le ", gobjCPluviometrie.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblHygrometrie.Text = String.Concat("Hygrométrie: ", gobjCHygrometrie.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur.ToString(), " %");
            gtltToolTipGlobal.SetToolTip(glblHygrometrie, String.Concat("Hygrométrie prélevée le ", gobjCHygrometrie.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblVitesseVent.Text = String.Concat("Vitesse du vent : ", (gobjCVitesseVent.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mfltValeur * 3.6).ToString(), " km/h");
            gtltToolTipGlobal.SetToolTip(glblVitesseVent, String.Concat("Vitesse du vent prélevée le ", gobjCVitesseVent.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblDirectionVent.Text = String.Concat("Direction du vent : ", gobjCDirectionVent.mstrConvertionValRecente());
            gtltToolTipGlobal.SetToolTip(glblDirectionVent, String.Concat("Direction du vent prélevée le ", gobjCDirectionVent.mCJsonMeteoFunGetmObjCJsonMeteoRecent().mdtmDate.ToString()));

            glblEvapotranspiration.Text = String.Concat("Evapotranspiration : ", Math.Round(gobjCEvapotranspiration.mfltCalculEvapotranspiration(gdtmpDateDeDebut.Value, gdtmpDateDeFin.Value), 2).ToString(), " mm/j");
            gtltToolTipGlobal.SetToolTip(glblEvapotranspiration, String.Concat("Evapotranspiration calculée avec la formule\r\nde Penman Monteith qui nécéssite :\r\n" +
        "- Température air\r\n- Hygrométrie\r\n- Vitesse vent\r\n- Ensoleillement", "\nValeur calculée sur la plage de ", gdtmpDateDeDebut.Value.ToString(), " à ", gdtmpDateDeFin.Value.ToString()));

        }
    }
}

/*

CInfoGenerale.cs

Auteur : Fabien DAVID
Date de création : 18/03/2025, 17:34
Dernière modification : 18/03/2025, 17:34
Justification : X

Interface ayant comme implémenteur CInfoMeteo, CInfoPiste et CInfoArrosage
Elle va agir comme une classe contrôle.
Ces implémenteurs vont pouvoir communiquer avec les objets CAPI, puis stocker et exploiter les classes
implémentant l'interface ICJson

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAppFabien
{
    public interface ICInfoGenerale
    {
        void mVFunSetAssoCAPI(CAPI objCAPI);
        String mStrGetDataType();

        //public String strfunGetRequest();

    };
}

/*

CJsonArrosage.cs

Auteur : Fabien DAVID
Date de création : 17/03/2025, 11:00
Dernière modification : 26/03/2025, 09:16
Justification :
    Modification du type de la date de string à DateTime
    Modification de l'attribut de la date de mstrDate à mdtmDate
    Modification de l'attribut de la valeur de mstrvaleur à mstrValeur
    Modification de l'attribut de la piste de mstrpiste à mstrPiste

Classe CJsonArrosage qui implémente l'interface ICJson
elle sert à stocker les données récpurées de CAPI concernant les arrosages
sous l'ordre de la classe CInfoArrosage.
Elle agit donc comme une classe entité

Les fichiers json demandé à l'API à propos 
de l'arrosage ont les champs suivant : 
    - "quantite" en num
    - "date" en string
    - "piste" en string

Cette forme de json doit aussi être envoyable vers l'API
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PrototypeAppFabien
{
    class CJsonArrosage : ICJson
    {
        [JsonPropertyName("quantite")]
        public short mshtQuantite{ get; set; }

        [JsonPropertyName("date")]
        public DateTime mstrDate{ get; set; }

        [JsonPropertyName("piste")]
        public String mstrPiste{ get; set; }
    }
}
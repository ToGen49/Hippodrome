/*

CJsonMeteo.cs

Auteur : Fabien DAVID
Date de création : 24/03/2025, 08:51
Dernière modification : 26/03/2025, 09:16
Justification :
    Modification du type de la date de string à DateTime
    Modification de l'attribut de la date de mstrDate à mdtmDate
    Modification de l'attribut de la valeur de mstrvaleur à mstrValeur

Classe CJsonMeteo qui implémente l'interface ICJson
elle sert à stocker les données récpurées de CAPI concernant la météo
sous l'ordre de la classe CInfoMeteo et ses héritiés.
Elle agit donc comme une classe entité

Les fichiers json demandé à l'API à propos 
des données de la station météo ont les champs suivant :
    - "valeur" en num
    - "date" en string

Ils conviennent donc pour les informations suivantes :
    - Température de l'air
    - Hygrométrie (ou humidité de l'air)
    - Pluviométrie
    - Vitesse du vent
    - Direction du vent
    - Ensoleillement (Pas à afficher)

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
    public class CJsonMeteo : ICJson
    {
        [JsonPropertyName("valeur")]
        public float mfltValeur { get; set; }

        [JsonPropertyName("date")]
        public DateTime mdtmDate { get; set; }
    }
}

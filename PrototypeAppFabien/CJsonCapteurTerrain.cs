/*
CJsonCapteurTerrain.cs

Auteur : Fabien DAVID
Date de création : 17/03/2025, 11:00
Dernière modification : 17/03/2025, 11:00
Justification : X

Classe CJsonMeteo qui implémente l'interface ICJson
elle sert à stocker les données récpurées de CAPI concernant les données du terrain
sous l'ordre de la classe CInfoTerrain et ses héritiés.
Elle agit donc comme une classe entité

Les fichiers json demandé à l'API à propos
des données des capteurs du terrains ont les champs suivant :
    - "valeur" en num
    - "date" en string
    - "zone" en num

Il convient donc pour les informations suivantes :
    - Humidité du terrain
    - Température du terrain
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
    class CJsonCapteurTerrain : ICJson
    {
        [JsonPropertyName("valeur")]
        public float mfltvaleur{ get; set; }

        [JsonPropertyName("date")]
        public DateTime mstrdate{ get; set; }

        [JsonPropertyName("zone")]
        public short mshtzone{ get; set; }
    }
}
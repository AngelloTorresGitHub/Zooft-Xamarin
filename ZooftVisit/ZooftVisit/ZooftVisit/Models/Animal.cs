using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooftVisit.Models
{
    class Animal
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("id_zona")]
        public String IdZona { get; set; }

        [JsonProperty("nombre")]
        public String Nombre { get; set; }

        [JsonProperty("nombreEsp")]
        public String NombreEsp { get; set; }

        [JsonProperty("nombreIng")]
        public String NombreIng { get; set; }

        [JsonProperty("imagen")]
        public String Imagen { get; set; }

        [JsonProperty("especieEsp")]
        public String EspecieEsp { get; set; }

        [JsonProperty("especieIng")]
        public String EspecieIng { get; set; }

        [JsonProperty("imgEspecie")]
        public String ImgEspecie { get; set; }

        [JsonProperty("alimentacionEsp")]
        public String AlimentacionEsp { get; set; }

        [JsonProperty("alimentacionIng")]
        public String AlimentacionIng { get; set; }

        [JsonProperty("imgAlimentacion")]
        public String ImgAlimentacion { get; set; }

        [JsonProperty("regionEsp")]
        public String RegionEsp { get; set; }

        [JsonProperty("regionIng")]
        public String RegionIng { get; set; }

        [JsonProperty("imgRegion")]
        public String ImgRegion { get; set; }

        [JsonProperty("peso")]
        public String Peso { get; set; }

        [JsonProperty("longitud")]
        public String Longitud { get; set; }

        [JsonProperty("conservacionEsp")]
        public String ConservacionEsp { get; set; }

        [JsonProperty("conservacionIng")]
        public String ConservacionIng { get; set; }

        [JsonProperty("imgConservacion")]
        public String ImgConservacion { get; set; }

        [JsonProperty("descripcionEsp")]
        public String DescripcionEsp { get; set; }

        [JsonProperty("descripcionIng")]
        public String DescripcionIng { get; set; }

        [JsonProperty("costumbresEsp")]
        public String CostumbresEsp { get; set; }

        [JsonProperty("costumbresIng")]
        public String CostumbresIng { get; set; }

        [JsonProperty("sabiasEsp")]
        public String SabiasEsp { get; set; }

        [JsonProperty("sabiasIng")]
        public String SabiasIng { get; set; }


    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooftVisit.Models
{
    public class Animal
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("id_zona")]
        public String IdZona { get; set; }

        [JsonProperty("nombre")]
        public String Nombre { get; set; }

        [JsonProperty("nombreEsp")]
        public String EspNombre { get; set; }

        [JsonProperty("nombreIng")]
        public String IngNombre { get; set; }

        [JsonProperty("imagen")]
        public String Imagen { get; set; }

        [JsonProperty("especieEsp")]
        public String EspEspecie { get; set; }

        [JsonProperty("especieIng")]
        public String IngEspecie { get; set; }

        [JsonProperty("imgEspecie")]
        public String ImgEspecie { get; set; }

        [JsonProperty("alimentacionEsp")]
        public String EspAlimentacion { get; set; }

        [JsonProperty("alimentacionIng")]
        public String IngAlimentacion { get; set; }

        [JsonProperty("imgAlimentacion")]
        public String ImgAlimentacion { get; set; }

        [JsonProperty("regionEsp")]
        public String EspRegion { get; set; }

        [JsonProperty("regionIng")]
        public String IngRegion { get; set; }

        [JsonProperty("imgRegion")]
        public String ImgRegion { get; set; }

        [JsonProperty("peso")]
        public String Peso { get; set; }

        [JsonProperty("longitud")]
        public String Longitud { get; set; }

        [JsonProperty("conservacionEsp")]
        public String EspConservacion { get; set; }

        [JsonProperty("conservacionIng")]
        public String IngConservacion { get; set; }

        [JsonProperty("imgConservacion")]
        public String ImgConservacion { get; set; }

        [JsonProperty("descripcionEsp")]
        public String EspDescripcion { get; set; }

        [JsonProperty("descripcionIng")]
        public String IngDescripcion { get; set; }

        [JsonProperty("costumbresEsp")]
        public String EspCostumbres { get; set; }

        [JsonProperty("costumbresIng")]
        public String IngCostumbres { get; set; }

        [JsonProperty("sabiasEsp")]
        public String EspSabias { get; set; }

        [JsonProperty("sabiasIng")]
        public String IngSabias { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ZooftVisit.Models
{
   public class Coordenada
    {
        public int Id { get; set; }
        public int Latitud { get; set; }
        public int longitud { get; set; }
        public String Tipo { get; set; }
        public String TituloEsp { get; set; }
        public String TituloIng { get; set; }
        public String DescripcionEsp { get; set; }
        public String DescripcionIng { get; set; }
    }
}

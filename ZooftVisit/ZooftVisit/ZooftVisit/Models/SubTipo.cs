using System;
using System.Collections.Generic;
using System.Text;

namespace ZooftVisit.Models
{
    public class SubTipo
    {
        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public String Departamento { get; set; }
        public String Nivel { get; set; }
        public String DescripcionEsp { get; set; }
        public String DescripcionIng { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Auxiliar;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Modelo
{
    public class Alquiler
    {
        [Required]
        public string Matricula { get; set; }
        [Required]
        public string DniClienete { get; set; }
        [Required]
        public double PrecioAlquiler { get; set; }
        public double PrecioDiasExtras { get; set; }

    }
}

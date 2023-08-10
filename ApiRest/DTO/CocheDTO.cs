using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Auxiliar;

namespace ApiRest.DTO
{
    public class CocheDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string TipoCoche { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public string Matricula { get; set; }
    }

    public class CocheEntradaDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string TipoCoche { get; set; }
        [Required]
        public string Matricula { get; set; }
    }
}

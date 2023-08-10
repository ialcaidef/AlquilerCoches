using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Auxiliar;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Modelo
{
    public class Cliente
    {
        [Required]
        public string DNI { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int PuntosFidelidad { get; set; }


    }
}

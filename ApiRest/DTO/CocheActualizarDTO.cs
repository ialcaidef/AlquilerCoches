﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.DTO
{
    public class CocheActualizarDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string TipoCoche { get; set; }
    }
}

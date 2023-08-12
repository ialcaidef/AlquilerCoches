using ApiRest.DTO;
using ApiRest.Modelo;
using ApiRest.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Auxiliar;
using ApiRest.Settings;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ApiRest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CochesController : ControllerBase
    {

        private readonly ICochesEnMemoria repositorio;

        public CochesController(ICochesEnMemoria r)
        {
            repositorio = r;
        }

        [Route("Inventario")]
        [HttpGet]
        public IEnumerable<CocheDTO> DameCoches()
        {
            var listaCoches = repositorio.Inventario().Select(c=>c.convertirDTO());
            return listaCoches;
        }


        [HttpGet("Inventario/{matricula}")]
        public ActionResult<CocheDTO> DameCoche([Required] string matricula)
        {
            var coche = repositorio.DameCoche(matricula).convertirDTO();

            if (coche is null)
            {
                return NotFound();
            }

            return coche;
        }

        [HttpGet("PrecioAlquilerCoche/{matricula}")]
        public ActionResult<double> AlquilerCoche([Required] string matricula, [Required] int dias)
        {
            var coche = repositorio.DameCoche(matricula);

            if (coche is null)
            {
                return NotFound();
            }

            double result = 0;

            switch (coche.TipoCoche)
            {
                case Enumerados.TipoCarroceria.Premium:
                    result = coche.Precio * dias;
                    break;
                case Enumerados.TipoCarroceria.SUV:
                    if(dias <= 7)
                        result = coche.Precio * dias;
                    else if (dias > 7 && dias <= 30)
                        result = ((coche.Precio * 80) / 100) * dias;
                    else if (dias > 30)
                        result = ((coche.Precio * 50) / 100) * dias; 
                    break;
                case Enumerados.TipoCarroceria.Little:
                    if (dias <= 7)
                        result = coche.Precio * dias;
                    else 
                        result = ((coche.Precio * 60) / 100) * dias;
                    break;

            }
            return result;
        }

        [HttpGet("PrecioAlquilerCoches/{matriculas}")]
        // <summary>
        /// Permite devolver el precio del alquiler de varios coches
        /// </summary>
        /// <returns>precio total del alquiler de varios coches</returns>
        /// <param name="matrículas">relación de matrículas separadas por ;</param>
        public ActionResult<string> AlquilerCoches(string matriculas)
        {

            return "En desarrollo";

        }

        [HttpGet("PuntosFidelidad/{dni}")]
        public ActionResult<string> PuntosFidelidad(string dni)
        {
            return "En desarrollo";
        }

        [HttpGet("PrecioDiasExtra/{matricula}")]
        public ActionResult<double> DiasExtra(string matricula, int dias)
        {
            var coche = repositorio.DameCoche(matricula);

            if (coche is null)
            {
                return NotFound();
            }

            double result = 0;

            switch (coche.TipoCoche)
            {
                case Enumerados.TipoCarroceria.Premium:
                    result = (coche.Precio + (Appsettings.PorcIncDiaExtraPremium/100 * coche.Precio)) * dias;
                    break;
                case Enumerados.TipoCarroceria.SUV:
                    result = (coche.Precio + (Appsettings.PorcIncDiaExtraSuv /100 * Utilidades.PrecioDiaPorTipoCoche(Enumerados.TipoCarroceria.Little))) * dias;
                    break;
                case Enumerados.TipoCarroceria.Little:
                    result = (coche.Precio + (Appsettings.PorcIncDiaExtraLittle/100 * coche.Precio)) * dias;
                    break;

            }
            return result;
        }

        [Route("Coches")]
        [HttpPost]
        public ActionResult<CocheDTO> CrearCoche(CocheEntradaDTO c)
        {
            Coche coche = new Coche
            {
                Id = repositorio.Inventario().Max(c => c.Id) + 1,
                Nombre = c.Nombre,
                TipoCoche = Utilidades.ConvertirTipoCoche(c.TipoCoche),
                Matricula = c.Matricula,
                FechaAlta = DateTime.Now,

            };

            repositorio.CrearCoche(coche);

            return coche.convertirDTO();
        }

        [Route("Coches")]
        [HttpPut]
        public ActionResult<CocheDTO> ModificarCoche(String matricula, CocheActualizarDTO c)
        {
            Coche existeCoche = repositorio.DameCoche(matricula);
            if (existeCoche is null)
            {
                return NotFound();
            }

            existeCoche.Nombre = c.Nombre;
            existeCoche.TipoCoche = Utilidades.ConvertirTipoCoche(c.TipoCoche);

            repositorio.ModificarCoche(existeCoche);

            return existeCoche.convertirDTO();
        }

        [Route("Coches")]
        [HttpDelete]
        public ActionResult BorrarCoche(String matricula)
        {
            Coche existeCoche = repositorio.DameCoche(matricula);
            if (existeCoche is null)
            {
                return NotFound();
            }

            repositorio.BorrarCoche(matricula);

            return NoContent();
        }

    }
}

using ApiRest.DTO;
using ApiRest.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Auxiliar
{
    public static class Utilidades
    {
        public static CocheDTO convertirDTO(this Coche c)
        {
            if (c != null)
            {
                return new CocheDTO
                {
                    Nombre = c.Nombre,
                    TipoCoche = c.TipoCoche.ToString(),
                    Precio = c.Precio,
                    Matricula = c.Matricula,

                };
            }

            return null;
        }

        public static Enumerados.TipoCarroceria ConvertirTipoCoche(string tipoCoche)
        {

            switch (tipoCoche.ToUpper())
            {
                case "PREMIUM":
                    return Enumerados.TipoCarroceria.Premium;
                case "SUV":
                    return Enumerados.TipoCarroceria.SUV;
                case "PEQUEÑO":
                    return Enumerados.TipoCarroceria.Pequeño;
                default:
                    throw new Exception("No es un tipo de coche válido");
            }
        }

        public static double PrecioDiaPorTipoCoche(Enumerados.TipoCarroceria tipoCoche)
        {
            double result = 0;

            switch (tipoCoche)
            {
                case Enumerados.TipoCarroceria.Premium:
                    result = 300;
                    break;
                case Enumerados.TipoCarroceria.SUV:
                    result = 150;
                    break;
                case Enumerados.TipoCarroceria.Pequeño:
                    result = 50;
                    break;

            }
            return result;
        }
    }
}

using ApiRest.DTO;
using ApiRest.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Settings;

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
                case "LITTLE":
                    return Enumerados.TipoCarroceria.Little;
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
                    result = Appsettings.PrecioDiaPremium;
                    break;
                case Enumerados.TipoCarroceria.SUV:
                    result = Appsettings.PrecioDiaSuv;
                    break;
                case Enumerados.TipoCarroceria.Little:
                    result = Appsettings.PrecioDiaLittle;
                    break;

            }
            return result;
        }
    }
}

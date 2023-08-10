using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Auxiliar;

namespace ApiRest.Modelo
{
    public class Coche
    {
        

        public int Id { get; set; }
        public Enumerados.TipoCarroceria TipoCoche { get; set; }
        
        public string Nombre { get; set; }
        public double Precio 
        {
            get 
            {
                return Utilidades.PrecioDiaPorTipoCoche(this.TipoCoche);  
            }  
        }
        public DateTime FechaAlta { get; set; }
        public string Matricula { get; set; }


    }
}

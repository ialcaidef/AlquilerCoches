using ApiRest.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Auxiliar;

namespace ApiRest.Repositorio
{
    public class CochesEnMemoria : ICochesEnMemoria
    {
        private readonly List<Coche> coches = new List<Coche>()
        {
            new Coche { Id = 1, TipoCoche = Enumerados.TipoCarroceria.Premium, Nombre = "BMW 7", FechaAlta = DateTime.Now, Matricula = "PRE-BMW07-001" },
            new Coche { Id = 2, TipoCoche = Enumerados.TipoCarroceria.SUV, Nombre = "Kia Sorento", FechaAlta = DateTime.Now, Matricula = "SUV-KIASOR-001" },
            new Coche { Id = 3, TipoCoche = Enumerados.TipoCarroceria.SUV, Nombre = "Nissan Juke", FechaAlta = DateTime.Now, Matricula = "SUV-NISJUK-001" },
            new Coche { Id = 4, TipoCoche = Enumerados.TipoCarroceria.Pequeño, Nombre = "Seat Ibiza", FechaAlta = DateTime.Now, Matricula = "PEQ-SEATIBI-001" },
        };


        public IEnumerable<Coche> Inventario()
        {
            return coches;
        }

        public Coche DameCoche(string Matricula)
        {
            return coches.Where(coche => coche.Matricula == Matricula).SingleOrDefault();
        }

        public void CrearCoche(Coche coche)
        {
            coches.Add(coche);
        }

        public void ModificarCoche(Coche coche)
        {
            int indice = coches.FindIndex(existeCoche => existeCoche.Id == coche.Id);
            coches[indice] = coche;
        }

        public void BorrarCoche(string Matricula)
        {
            int indice = coches.FindIndex(existeCoche => existeCoche.Matricula == Matricula);
            coches.RemoveAt(indice);
        }
    }
}

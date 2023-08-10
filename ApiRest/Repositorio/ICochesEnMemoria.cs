using ApiRest.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Repositorio
{
    public interface ICochesEnMemoria
    {
        Coche DameCoche(string Matricula);
        IEnumerable<Coche> Inventario();
        void CrearCoche(Coche c);
        void ModificarCoche(Coche c);
        void BorrarCoche(string Matricula);

    }
}

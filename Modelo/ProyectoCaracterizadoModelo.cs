using System;
using System.Collections.Generic;

namespace Modelo
{
    public class ProyectoCaracterizadoModelo
    {
        public int Codigo { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public double ValorCaracterizacion { get; set; }

        public string TipoProyecto { get; set; }

        public GerenteModelo Gerente { get; set; }

        public List<FactorModelo> Factores { get; set; }
    }
}

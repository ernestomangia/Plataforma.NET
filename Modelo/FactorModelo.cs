using System.Collections.Generic;

namespace Modelo
{
    public class FactorModelo
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public List<ValorFactorModelo> Valores { get; set; }

        public List<ProyectoCaracterizadoModelo> Proyectos { get; set; } 
    }
}

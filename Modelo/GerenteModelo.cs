using System.Collections.Generic;

namespace Modelo
{
    public class GerenteModelo
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public List<ProyectoCaracterizadoModelo> ProyectoCaracterizados { get; set; }
    }
}

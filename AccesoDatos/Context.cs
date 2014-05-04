using System.Data.Entity;

using Modelo;

namespace AccesoDatos
{
    public class Context : DbContext
    {
        private DbSet<GerenteModelo> Gerentes { get; set; }

        private DbSet<ProyectoCaracterizadoModelo> ProyectosCaracterizados { get; set; }
    }
}

using System.Data.Entity;

using AccesoDatos.Configuracion;
using Modelo;

namespace AccesoDatos
{
    public class Context : DbContext
    {
        private DbSet<GerenteModelo> Gerentes { get; set; }

        private DbSet<ProyectoCaracterizadoModelo> ProyectosCaracterizados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GerenteConfiguracion());
        }
    }
}

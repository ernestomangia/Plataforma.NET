using System.Data.Entity;

using AccesoDatos.Configuracion;
using Modelo;

namespace AccesoDatos
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("Data Source=D-PC;Initial Catalog=TrabajoPracticoBD;Integrated Security=True")
        {
        }
        
        public DbSet<GerenteModelo> Gerentes { get; set; }

        public DbSet<ProyectoCaracterizadoModelo> ProyectosCaracterizados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GerenteConfiguracion());
            modelBuilder.Configurations.Add(new ProyectoCaracterizadoConfiguracion());
        }
    }
}

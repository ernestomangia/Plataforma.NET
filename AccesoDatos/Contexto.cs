using System.Data.Entity;

using AccesoDatos.Configuracion;
using Modelo;

namespace AccesoDatos
{
    public class Contexto : DbContext
    {
        public Contexto()

           // : base("Data Source=D-PC;Initial Catalog=TrabajoPracticoBD;Integrated Security=True")
            : base("TrabajoPracticoBD")
        {
        }
        
        public DbSet<GerenteModelo> Gerentes { get; set; }

        public DbSet<ProyectoCaracterizadoModelo> ProyectosCaracterizados { get; set; }

        public DbSet<FactorModelo> Factores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GerenteConfiguracion());
            modelBuilder.Configurations.Add(new ProyectoCaracterizadoConfiguracion());
            modelBuilder.Configurations.Add(new FactorConfiguracion());
            modelBuilder.Configurations.Add(new ValorFactorConfiguracion());
        }
    }
}

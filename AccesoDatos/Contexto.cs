using System.Data.Entity;

using AccesoDatos.Configuracion;
using Modelo;

namespace AccesoDatos
{
    public class Contexto : DbContext
    {
        static Contexto()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
            Database.SetInitializer<Contexto>(null);
        }

        public Contexto()
            //: base("Data Source=D-PC;Initial Catalog=TrabajoPracticoBD;Integrated Security=True")
            : base("Data Source=.\\SQLExpress;Initial Catalog=TrabajoPracticoBD;Integrated Security=True")
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

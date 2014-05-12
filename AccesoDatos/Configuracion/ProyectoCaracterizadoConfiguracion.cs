using System.Data.Entity.ModelConfiguration;

using Modelo;

namespace AccesoDatos.Configuracion
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProyectoCaracterizadoConfiguracion : EntityTypeConfiguration<ProyectoCaracterizadoModelo>
    {
        public ProyectoCaracterizadoConfiguracion()
        {
            this.ToTable("Proyectos");
            HasKey(p => p.Codigo).Property(p => p.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Titulo).HasMaxLength(50);
            Property(p => p.Fecha).IsRequired();
            Property(p => p.TipoProyecto).HasMaxLength(50).IsRequired();

            this.HasRequired(p => p.Gerente);
        }
    }
}

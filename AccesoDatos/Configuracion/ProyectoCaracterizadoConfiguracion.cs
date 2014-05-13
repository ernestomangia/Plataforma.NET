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

            this.HasMany(p => p.Factores).WithMany(f => f.Proyectos).Map(
                m =>
                    {
                        m.MapLeftKey("Factor_Codigo");
                        m.MapRightKey("Proyecto_Codigo");
                        m.ToTable("FactoresProyectos");
                    });


            // this.HasRequired(p => p.Gerente);
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Modelo;

namespace AccesoDatos.Configuracion
{
    public class FactorConfiguracion : EntityTypeConfiguration<FactorModelo>
    {
        public FactorConfiguracion()
        {
            this.ToTable("Factores");
            HasKey(f => f.Codigo).Property(f => f.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(f => f.Nombre).HasMaxLength(50).IsRequired();

            this.HasMany(f => f.Valores);
            this.HasMany(f => f.Proyectos);
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Modelo;

namespace AccesoDatos.Configuracion
{
    public class ValorFactorConfiguracion : EntityTypeConfiguration<ValorFactorModelo>
    {
        public ValorFactorConfiguracion()
        {
            this.ToTable("ValoresFactor");
            HasKey(v => v.Codigo).Property(v => v.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(v => v.Nombre).HasMaxLength(50).IsRequired();

            this.HasRequired(v => v.Factor);
        }
    }
}

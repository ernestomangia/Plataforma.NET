using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Modelo;

namespace AccesoDatos.Configuracion
{
    public class GerenteConfiguracion : EntityTypeConfiguration<GerenteModelo>
    {
        public GerenteConfiguracion()
        {
            Property(g => g.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(g => g.Nombre).HasMaxLength(50).IsRequired();
            Property(g => g.Apellido).HasMaxLength(50).IsRequired();
            Property(g => g.User).HasMaxLength(30).IsRequired();
            Property(g => g.Password).HasMaxLength(20).IsRequired();
            this.HasMany(g => g.ProyectoCaracterizados);
        }
    }
}

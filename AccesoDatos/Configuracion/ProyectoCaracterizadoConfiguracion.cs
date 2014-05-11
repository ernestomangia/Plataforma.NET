using System.Data.Entity.ModelConfiguration;

using Modelo;

namespace AccesoDatos.Configuracion
{
    public class ProyectoCaracterizadoConfiguracion : EntityTypeConfiguration<ProyectoCaracterizadoModelo>
    {
        public ProyectoCaracterizadoConfiguracion()
        {
            Property(p => p.Titulo).HasMaxLength(50);
            Property(p => p.Fecha).IsRequired();
            Property(p => p.TipoProyecto).HasMaxLength(50).IsRequired();

            this.HasRequired(p => p.Gerente);
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class GerenteModelo
    {
        [Key]
        public int Codigo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [StringLength(30)]
        public string User { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public List<ProyectoCaracterizadoModelo> ProyectoCaracterizados { get; set; }
    }
}

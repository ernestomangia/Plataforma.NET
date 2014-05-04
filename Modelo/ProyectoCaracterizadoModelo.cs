using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class ProyectoCaracterizadoModelo
    {
        [Key]
        public int Codigo { get; set; }

        [StringLength(50)]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public double ValorCaracterizacion { get; set; }

        [StringLength(50)]
        public string TipoProyecto { get; set; }

        public GerenteModelo Gerente { get; set; }
    }
}

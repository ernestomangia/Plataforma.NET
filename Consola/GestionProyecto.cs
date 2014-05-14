using System;
using System.Linq;

using AccesoDatos;

namespace Consola
{
    using System.Data.Entity;
    using System.Data.Entity.Validation;

    using Modelo;

    public class GestionProyecto
    {
        public string DibujarMenuProyecto()
        {
            Console.WriteLine("----------------------MENU PROYECTO----------------------");
            Console.WriteLine("1 - Alta Proyecto");
            Console.WriteLine("2 - Baja Proyecto");
            Console.WriteLine("3 - Modificación Proyecto");
            Console.WriteLine("4 - Menu Principal");
            Console.WriteLine();
            this.ListarProyectos();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese una opcion");
            var opcion = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            return opcion;
        }

        public void ListarProyectos()
        {
            Console.WriteLine("----------------------Listado de Proyectos----------------------");
            Console.WriteLine(
                            "ID".PadRight(5),
                            "Título".PadRight(50),
                            "Descripcion".PadRight(50),
                            "Fecha".PadRight(16),
                            "VC".PadRight(5),
                            "Tipo".PadRight(10),
                            "Gerente".PadRight(50));
            using (var contexto = new Contexto())
            {
                foreach (var p in contexto.ProyectosCaracterizados.Include(p => p.Gerente))
                {
                    Console.WriteLine(
                        "{0} | {1} | {2} | {3} | {4} | {5} | {6}",
                        p.Codigo.ToString().PadRight(5),
                        p.Titulo.PadRight(50),
                        p.Descripcion.PadRight(50),
                        p.Fecha.ToString("dd/MM/yyyy hh:ss").PadRight(16),
                        p.ValorCaracterizacion.ToString().PadRight(5),
                        p.TipoProyecto.PadRight(10),
                        p.Gerente.Nombre.PadRight(50));
                }

                if (!contexto.Gerentes.Any())
                    Console.WriteLine("No hay proyectos cargados.");
            }
        }

        public void AltaProyecto()
        {
            Console.WriteLine("----------------------ALTA PROYECTO----------------------");
            Console.WriteLine("Ingrese Titulo:");
            var nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Descripción:");
            var descripcion = Console.ReadLine();

            var proyecto = new ProyectoCaracterizadoModelo
            {
                Titulo = nombre,
                Descripcion = descripcion,
                Fecha = DateTime.Now
            };

            using (var contexto = new Contexto())
            {
                contexto.ProyectosCaracterizados.Add(proyecto);
                try
                {
                    contexto.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine("Error al insertar. Intente nuevamente. Presione una tecla para continuar.");
                    Console.ReadKey();
                }
            }
        }

        public void EliminarProyecto()
        {

        }

        public void ModificarProyecto()
        {

        }
    }
}

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

using AccesoDatos;
using Modelo;

namespace Consola
{
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
                            "{0} | {1} | {2} | {3} | {4} | {5} | {6}",
                            "ID".PadRight(3),
                            "Título".PadRight(10),
                            "Descripcion".PadRight(12),
                            "Fecha".PadRight(16),
                            "VC".PadRight(5),
                            "Tipo".PadRight(10),
                            "Gerente".PadRight(10));

            using (var contexto = new Contexto())
            {
                foreach (var p in contexto.ProyectosCaracterizados.Include(p => p.Gerente))
                {
                    Console.WriteLine(
                        "{0} | {1} | {2} | {3} | {4} | {5} | {6}",
                        p.Codigo.ToString().PadRight(3),
                        p.Titulo.PadRight(10),
                        p.Descripcion.PadRight(12),
                        p.Fecha.ToString("dd/MM/yyyy hh:ss").PadRight(16),
                        p.ValorCaracterizacion.ToString().PadRight(5),
                        (p.TipoProyecto ?? string.Empty).PadRight(10),
                        (p.Gerente != null ? p.Gerente.Nombre.PadRight(10) : string.Empty).PadRight(10));
                }

                if (!contexto.ProyectosCaracterizados.Any())
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
            Console.WriteLine();

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
                    if (contexto.SaveChanges() == 1)
                        Console.WriteLine("Se agregó exitosamente el Proyecto");
                }
                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine("Error al insertar. Intente nuevamente.");

                    // Console.ReadKey();
                }
            }
        }

        public void EliminarProyecto()
        {
            Console.WriteLine("----------------------BAJA PROYECTO----------------------");
            Console.WriteLine("Ingrese el ID del Proyecto que desea eliminar. Luego presione enter:");

            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            using (var contexto = new Contexto())
            {
                var proyectoUpdate = contexto.ProyectosCaracterizados.Find(id);

                if (proyectoUpdate != null)
                {
                    contexto.ProyectosCaracterizados.Remove(proyectoUpdate);
                    try
                    {
                        if (contexto.SaveChanges() == 1) Console.WriteLine("Se eliminó exitosamente el Proyecto");
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine(
                            "No se puede borrar el Proyecto seleccionado debido a que esta relacionado a otra/s entidad/es");
                    }
                }
                else
                {
                    Console.WriteLine("El ID del Proyecto ingresado no existe");
                }
            }
        }

        public void ModificarProyecto()
        {
            Console.WriteLine("----------------------MODIFICAR PROYECTO----------------------");
            Console.WriteLine("Ingrese el ID del Proyecto que desea modificar. Luego presione enter:");

            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            using (var contexto = new Contexto())
            {
                var proyectoUpdate = contexto.ProyectosCaracterizados.Find(id);
                if (proyectoUpdate != null)
                {
                    Console.WriteLine("Ingrese Titulo:");
                    proyectoUpdate.Titulo = Console.ReadLine();
                    Console.WriteLine("Ingrese Descripción");
                    proyectoUpdate.Descripcion = Console.ReadLine();
                    Console.WriteLine();

                    try
                    {
                        if (contexto.SaveChanges() == 1)
                            Console.WriteLine("Se modificó exitosamente el Proyecto");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error al modificar un Proyecto.");
                    }
                }
                else
                {
                    Console.WriteLine("El ID del Proyecto ingresado no existe");
                }
            }
        }
    }
}

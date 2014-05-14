using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

using AccesoDatos;

using Modelo;

namespace Consola
{
    public class GestionGerente
    {
        public string DibujarMenuGerente()
        {
            Console.WriteLine("----------------------MENU GERENTE----------------------");
            Console.WriteLine("1 - Alta Gerente");
            Console.WriteLine("2 - Baja Gerente");
            Console.WriteLine("3 - Modificación Gerente");
            Console.WriteLine("4 - Menu Principal");
            Console.WriteLine();
            this.ListarGerentes();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese una opcion");
            var opcion = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            return opcion;
        }

        public void ListarGerentes()
        {
            Console.WriteLine("----------------------Listado de Gerentes----------------------");
            Console.WriteLine(
                            "{0} | {1} | {2} | {3} | {4}",
                            "ID".PadRight(3),
                            "Nombre".PadRight(15),
                            "Apellido".PadRight(15),
                            "User".PadRight(15),
                            "Password".PadRight(10));

            using (var contexto = new Contexto())
            {
                foreach (var g in contexto.Gerentes)
                {
                    Console.WriteLine(
                        "{0} | {1} | {2} | {3} | {4}",
                        g.Codigo.ToString().PadRight(3),
                        g.Nombre.PadRight(15),
                        g.Apellido.PadRight(15),
                        g.User.PadRight(15),
                        g.Password.PadRight(10));
                }

                if (!contexto.Gerentes.Any())
                    Console.WriteLine("No hay gerentes cargados.");
            }
        }

        public void AltaGerente()
        {
            Console.WriteLine("----------------------ALTA GERENTE----------------------");
            Console.WriteLine("Ingrese Nombre:");
            var nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido:");
            var apellido = Console.ReadLine();
            Console.WriteLine("Ingrese User:");
            var user = Console.ReadLine();
            Console.WriteLine("Ingrese Password:");
            var password = Console.ReadLine();
            Console.WriteLine();

            var gerente = new GerenteModelo
            {
                Nombre = nombre,
                Apellido = apellido,
                User = user,
                Password = password
            };

            using (var contexto = new Contexto())
            {
                contexto.Gerentes.Add(gerente);
                try
                {
                    if (contexto.SaveChanges() == 1)
                        Console.WriteLine("Se agregó exitosamente el Gerente");
                }
                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine("Error al insertar. Intente nuevamente.");

                    // Console.ReadKey();
                }
            }
        }

        public void EliminarGerente()
        {
            Console.WriteLine("----------------------BAJA GERENTE----------------------");
            Console.WriteLine("Ingrese el ID del Gerente que desea eliminar. Luego presione enter:");

            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            using (var contexto = new Contexto())
            {
                var gerenteUpdate = contexto.Gerentes.Find(id);
                if (gerenteUpdate != null)
                {
                    contexto.Gerentes.Remove(gerenteUpdate);
                    try
                    {
                        if (contexto.SaveChanges() == 1)
                            Console.WriteLine("Se eliminó exitosamente el Gerente");
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine("No se puede borrar el Gerente seleccionado debido a que esta relacionado a otra/s entidad/es");
                    }
                }
                else
                {
                    Console.WriteLine("El ID del Gerente ingresado no existe");
                }
            }
        }

        public void ModificarGerente()
        {
            Console.WriteLine("----------------------MODIFICAR GERENTE----------------------");
            Console.WriteLine("Ingrese el ID del Gerente que desea modificar. Luego presione enter:");

            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            using (var contexto = new Contexto())
            {
                var gerenteUpdate = contexto.Gerentes.Find(id);
                if (gerenteUpdate != null)
                {
                    Console.WriteLine("Ingrese Nombre:");
                    gerenteUpdate.Nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese Apellido:");
                    gerenteUpdate.Apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese User:");
                    gerenteUpdate.User = Console.ReadLine();
                    Console.WriteLine("Ingrese Password:");
                    gerenteUpdate.Password = Console.ReadLine();
                    Console.WriteLine();

                    try
                    {
                        if (contexto.SaveChanges() == 1)
                            Console.WriteLine("Se modificó exitosamente el Gerente");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error al modificar un Gerente.");
                    }
                }
                else
                {
                    Console.WriteLine("El ID del Gerente ingresado no existe");
                }
            }

        }
    }
}

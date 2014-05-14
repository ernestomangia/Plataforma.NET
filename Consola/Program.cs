using System;
using System.Data.Entity;

using AccesoDatos;
using Modelo;

namespace Consola
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());

            // Menu Principal
            var opcion = DibujarMenuPrincipal();
            while (opcion != "S")
            {
                switch (opcion)
                {
                    case "A":

                        // Menu Gerente
                        var opcionGerente = DibujarMenuGerente();

                        switch (opcionGerente)
                        {
                            case "1":
                                Console.WriteLine("----------------------ALTA GERENTE----------------------");
                                Console.WriteLine("Ingrese Nombre");
                                var nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese Apellido");
                                var apellido = Console.ReadLine();
                                Console.WriteLine("Ingrese Password");
                                var password = Console.ReadLine();
                                Console.WriteLine("Ingrese User");
                                var user = Console.ReadLine();

                                var gerente = new GerenteModelo
                                {
                                    Nombre = nombre,
                                    Apellido = apellido,
                                    Password = password,
                                    User = user,
                                    ProyectoCaracterizados = new List<ProyectoCaracterizadoModelo>
                                                                 {
                                                                     new ProyectoCaracterizadoModelo()
                                                                         {
                                                                             Titulo = "asd"
                                                                         },
                                                                     new ProyectoCaracterizadoModelo()
                                                                 }
                                };

                                using (var contexto = new Contexto())
                                {
                                    contexto.Gerentes.Add(gerente);
                                    contexto.SaveChanges();
                                }

                                break;
                            case "2":
                                Console.WriteLine("----------------------BAJA GERENTE----------------------");
                                Console.WriteLine("Ingrese ID de Gerente a dar de baja");

                                var idGerente = Convert.ToInt32(Console.ReadLine());

                                using (var contexto = new Contexto())
                                {
                                    contexto.Gerentes.Remove(contexto.Gerentes.Find(idGerente));
                                    try
                                    {
                                        if (contexto.SaveChanges() == 1)
                                            Console.WriteLine("Se ha eliminado exitosamente");

                                    }
                                    catch (DbUpdateException ex)
                                    {
                                        Console.WriteLine("No se puede borrar el Gerente seleccionado debido a que esta relacionado a otra/s entidad/es");
                                    }
                                }

                                break;
                            case "3":

                                Console.WriteLine("Ingrese ID de Gerente que desea modificar y presione enter");
                                var id_Gerente_Modificar = Convert.ToInt32(Console.ReadLine());



                                using (var contexto = new Contexto())
                                {

                                    var gerenteUpdate = contexto.Gerentes.Find(id_Gerente_Modificar);

                                    Console.WriteLine("Ingrese el nombre de Gerente");
                                    gerenteUpdate.Nombre = Console.ReadLine().ToString();

                                    Console.WriteLine("Ingrese apellido de Gerente");
                                    gerenteUpdate.Apellido = Console.ReadLine().ToString();

                                    Console.WriteLine("Ingrese user de Gerente");
                                    gerenteUpdate.User = Console.ReadLine().ToString();

                                    Console.WriteLine("Ingrese password de Gerente");
                                    gerenteUpdate.Password = Console.ReadLine().ToString();

                                    if (contexto.SaveChanges() == 1)
                                        Console.WriteLine("Se ha modificado exitosamente");

                                }

                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Opción Incorrecta");
                                break;
                        }

                        break;
                    case "B":

                        /*  var proyecto = new ProyectoCaracterizadoModelo
                                         {
                                             Descripcion = "Proyecto 1 ",
                                             TipoProyecto = string.Empty,
                                             Fecha = DateTime.Now,
                                             Titulo = string.Empty,
                                             ValorCaracterizacion = 22.1,
                                             Gerente = gerente
                                         };*/

                        //gerente.ProyectoCaracterizados = new List<ProyectoCaracterizadoModelo>
                        //                                     {
                        //                                         proyecto
                        //                                     };
                        /*     using (var contexto = new Contexto())
                         {
                             contexto.Gerentes.Add(gerente);
                             contexto.ProyectosCaracterizados.Add(proyecto);
                             contexto.SaveChanges();
                         }
                         */
                        break;
                    case "C":
                        break;
                    case "S":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta. Presione una tecla para continuar e intente nuevamente...");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
                opcion = DibujarMenuPrincipal();
            }
        }

        public static string DibujarMenuPrincipal()
        {
            // Menu
            Console.WriteLine("¡Bienvenido!");
            Console.WriteLine("----------------------MENU PRINCIPAL----------------------");
            Console.WriteLine("A - ABMC Gerente");
            Console.WriteLine("B - ABMC Proyecto");
            Console.WriteLine("C - ABMC Factor");
            Console.WriteLine("S - Salir");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese una opción: ");

            var opcion = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.Clear();
            return opcion;
        }

        public static string DibujarMenuGerente()
        {
            Console.WriteLine("----------------------MENU GERENTE----------------------");
            Console.WriteLine("1 - Alta Gerente");
            Console.WriteLine("2 - Baja Gerente");
            Console.WriteLine("3 - Modificacion Gerente");
            Console.WriteLine("4 - Menu Principal");
            Console.WriteLine();
            Console.WriteLine("----------------------Listado de Gerentes----------------------");
            Console.WriteLine("Nombre           Apellido            User            Password");
            using (var contexto = new Contexto())
            {
                foreach (var g in contexto.Gerentes)
                {
                    Console.WriteLine("{0}          {1}         {2}         {3}", g.Nombre, g.Apellido, g.User, g.Password);
                }

                if (!contexto.Gerentes.Any())
                    Console.WriteLine("No hay gerentes cargados.");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese una opcion");
            var opcionGerente = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            return opcionGerente;
        }
    }
}

using System;
using System.CodeDom;
using System.Data.Entity;

using AccesoDatos;
using Modelo;

namespace Consola
{
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());


            // Menu
            Console.WriteLine("¡Bienvenido!");
            Console.WriteLine("----------------------MENU----------------------");
            Console.WriteLine("A - ABMC Gerente");
            Console.WriteLine("B - ABMC Proyecto");
            Console.WriteLine("C - ABMC Factor");
            Console.WriteLine("D - SALIR");
            Console.WriteLine();
            Console.WriteLine("Ingrese una opción: ");

            var opcion = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.Clear();



            switch (opcion)
            {
                case "A":

                    var opcionGerente = DibujarMenuGerente();


                    switch (opcionGerente)
                    {
                        case "1":

                            Console.WriteLine("Ingrese Nombre de Gerente");
                            var nombre = Console.ReadLine();

                            Console.WriteLine("Ingrese Apellido de Gerente");
                            var apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese Password de Gerente");
                            var password = Console.ReadLine();
                            Console.WriteLine("Ingrese User de Gerente");
                            var user = Console.ReadLine();

                            var gerente = new GerenteModelo
                            {
                                Nombre = nombre,
                                Apellido = apellido,
                                Password = password,
                                User = user
                            };

                            using (var contexto = new Contexto())
                            {
                                contexto.Gerentes.Add(gerente);
                                contexto.SaveChanges();
                            }


                            break;

                        case "2":
                            Console.WriteLine("Ingrese ID de Gerente a dar de baja y presione enter");

                            var id_Gerente = Convert.ToInt32(Console.ReadLine());


                            using (var contexto = new Contexto())
                            {

                                contexto.Gerentes.Remove(contexto.Gerentes.Find(id_Gerente));
                                contexto.SaveChanges();


                                if (contexto.SaveChanges() == 1)
                                    Console.WriteLine("Se ha eliminado exitosamente");

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
                case "B":

                    break;
                case "C":

                    break;
                default:
                    Console.WriteLine("Opción incorrecta. Intente nuevamente");
                    break;



            }
            Console.WriteLine("listo");
            Console.ReadKey();
        }

        public static string DibujarMenuGerente()
        {
            Console.WriteLine("1 - Alta Gerente");
            Console.WriteLine("2 - Baja Gerente");
            Console.WriteLine("3 - Modificacion Gerente");
            Console.WriteLine("4 - Menu Principal");
            Console.WriteLine();
            Console.WriteLine("Ingrese una opcion");

            Console.WriteLine("Nombre           Apellido            User            Password");
            using (var contexto = new Contexto())
            {
                foreach (var g in contexto.Gerentes)
                {
                    Console.Write("{0}          {1}         {2}         {3}", g.Nombre, g.Apellido, g.User,
                        g.Password);
                }

            }

            var opcionGerente = Console.ReadKey().KeyChar.ToString();
            Console.Clear();

            return opcionGerente;
        }


    }
}

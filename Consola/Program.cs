using System;
using System.Data.Entity;

using AccesoDatos;
using Modelo;

namespace Consola
{
    using System.Collections.Generic;
    using System.Runtime.Remoting.Contexts;

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
            Console.WriteLine("Ingrese una opción: ");
            var opcion = Console.ReadKey().KeyChar.ToString().ToUpper();

            switch (opcion)
            {
                case "A":
                    {
                        var gerente = new GerenteModelo
                        {
                            Nombre = "Juan",
                            Apellido = "Perez",
                            Password = "pass",
                            User = "user"
                        };

                        var proyecto = new ProyectoCaracterizadoModelo
                                           {
                                               Descripcion = "Proyecto 1 ",
                                               TipoProyecto = string.Empty,
                                               Fecha = DateTime.Now,
                                               Titulo = string.Empty,
                                               ValorCaracterizacion = 22.1,
                                               Gerente = gerente
                                           };

                        //gerente.ProyectoCaracterizados = new List<ProyectoCaracterizadoModelo>
                        //                                     {
                        //                                         proyecto
                        //                                     };
                        using (var contexto = new Contexto())
                        {
                            contexto.Gerentes.Add(gerente);
                            contexto.ProyectosCaracterizados.Add(proyecto);
                            contexto.SaveChanges();
                        }

                        break;
                    }
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
    }
}

using System;
using System.Data.Entity;

using AccesoDatos;
using Modelo;

namespace Consola
{

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
            var opcion = Console.ReadKey().Key.ToString();

            switch (opcion)
            {
                case "A":
                    var gerente = new GerenteModelo
                                      {
                                          Nombre = "Juan",
                                          Apellido = "Perez",
                                          Password = "pass",
                                          User = "user"
                                      };
                    using (var contexto = new Contexto())
                    {
                        contexto.Gerentes.Add(gerente);
                        contexto.SaveChanges();
                    }

            break;
                case "B":
                    
                    break;
                case "C":
                    
                    break;
                default:
                    Console.WriteLine("Opción incorrecta. Intente nuevamente");
                    break;
            }

            Console.ReadKey();
        }
    }
}

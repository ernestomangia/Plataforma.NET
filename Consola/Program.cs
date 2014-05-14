using System;
using System.Data.Entity;

using AccesoDatos;

namespace Consola
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
            var gestionProyecto = new GestionProyecto();
            var gestionGerente = new GestionGerente();
            var gestionFactor = new GestionFactor();

            // Menu Principal
            var opcion = DibujarMenuPrincipal();
            while (opcion != "S")
            {
                switch (opcion)
                {
                    case "A":

                        // Menu Gerente
                        var opcionGerente = gestionGerente.DibujarMenuGerente();
                        while (opcionGerente != "4")
                        {
                            switch (opcionGerente)
                            {
                                case "1":
                                    gestionGerente.AltaGerente();
                                    break;
                                case "2":
                                    gestionGerente.EliminarGerente();
                                    break;
                                case "3":
                                    gestionGerente.ModificarGerente();
                                    break;
                                case "4":
                                    break;
                                default:
                                    Console.WriteLine("Opción incorrecta. Intente nuevamente.");
                                    break;
                            }

                            Console.WriteLine();
                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            opcionGerente = gestionGerente.DibujarMenuGerente();
                        }

                        break;
                    case "B":

                        // Menu Proyecto
                        var opcionProyecto = gestionProyecto.DibujarMenuProyecto();
                        while (opcionProyecto != "4")
                        {
                            switch (opcionProyecto)
                            {
                                case "1":
                                    gestionProyecto.AltaProyecto();
                                    break;
                                case "2":
                                    gestionProyecto.EliminarProyecto();
                                    break;
                                case "3":
                                    gestionProyecto.ModificarProyecto();
                                    break;
                                case "4":
                                    break;
                                default:
                                    Console.WriteLine("Opción incorrecta. Intente nuevamente.");
                                    break;
                            }
                            Console.WriteLine();
                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            opcionProyecto = gestionProyecto.DibujarMenuProyecto();
                        }
                        break;
                    case "C":
                        var opcionFactor = gestionFactor.DibujarMenuFactor();

                        switch (opcionFactor)
                        {
                            case "1":
                                gestionFactor.AltaFactor();
                                break;
                        }

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
            Console.WriteLine("----------------------| MENU PRINCIPAL |----------------------");
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
    }
}

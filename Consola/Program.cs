using System;

namespace Consola
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

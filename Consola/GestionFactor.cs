using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Modelo;

namespace Consola
{
    public class GestionFactor
    {
        public string DibujarMenuFactor()
        {
            Console.WriteLine("----------------------MENU FACTOR----------------------");
            Console.WriteLine("1 - Alta Factor");
            Console.WriteLine("2 - Baja Factor");
            Console.WriteLine("3 - Modificacion Factor");
            Console.WriteLine("4 - Menu Principal");
            Console.WriteLine();
            Console.WriteLine("----------------------Listado de Factores----------------------");

            Console.WriteLine("Codigo           Nombre            Valor1            Valor2          Valor3");

            using (var contexto = new Contexto())
            {

                var factores = contexto.Factores.Include(b => b.Valores).ToList();

                foreach (var f in factores)
                {
                    Console.WriteLine("{0}          {1}         {2}         {3}         {4}", f.Codigo, f.Nombre, f.Valores[0].Nombre, f.Valores[1].Nombre, f.Valores[2].Nombre);
                }



                if (!contexto.Factores.Any())
                    Console.WriteLine("No hay factores cargados.");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese una opcion");
            var opcionFactor = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            return opcionFactor;


        }

        public void AltaFactor()
        {
            Console.WriteLine("----------------------ALTA FACTOR----------------------");
            Console.WriteLine("Ingrese Nombre");
            var nombre = Console.ReadLine();
            Console.WriteLine("VALOR 0");
            Console.WriteLine("Ingrese Nombre");
            var v1 = Console.ReadLine();
            Console.WriteLine("VALOR 1");
            Console.WriteLine("Ingrese Nombre");
            var v2 = Console.ReadLine();
            Console.WriteLine("VALOR 2");
            Console.WriteLine("Ingrese Nombre");
            var v3 = Console.ReadLine();

            var factor = new FactorModelo
            {
                Nombre=nombre,

                Valores = new List<ValorFactorModelo>
                {


                    new ValorFactorModelo()
                    {
                        Nombre = v1,
                        Valor=0
                    },

                    new ValorFactorModelo()
                    {
                        
                       Nombre=v2,
                       Valor=1

                    },

                    new ValorFactorModelo()
                    {
                        Nombre=v2,
                        Valor=2
                    }
                }
            };


            using (var contexto = new Contexto())
            {
                contexto.Factores.Add(factor);
                contexto.SaveChanges();
            }









        }
    }
}

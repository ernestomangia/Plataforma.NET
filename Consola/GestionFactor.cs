using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

            ListarFactores();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese una opcion");
            var opcionFactor = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            return opcionFactor;


        }

        public void ListarFactores()
        {
            Console.WriteLine("----------------------Listado de Factores----------------------");

            using (var contexto = new Contexto())
            {

                var factores = contexto.Factores.Include(b => b.Valores).ToList();

                foreach (var f in factores)
                {
                    Console.WriteLine("ID: {0}", f.Codigo);
                    Console.WriteLine("Nombre: {0}", f.Nombre);
                    Console.WriteLine("Valor 1: {0}", f.Valores[0].Nombre);
                    Console.WriteLine("Valor 2: {0}", f.Valores[1].Nombre);
                    Console.WriteLine("Valor 3: {0}", f.Valores[2].Nombre);
                    Console.WriteLine();

                }


                if (!contexto.Factores.Any())
                    Console.WriteLine("No hay factores cargados.");
            }

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
                Nombre = nombre,

                Valores = new List<ValorFactorModelo>
                {


                    new ValorFactorModelo()
                    {
                        Nombre = v1,
                        Valor = 0
                    },

                    new ValorFactorModelo()
                    {

                        Nombre = v2,
                        Valor = 1

                    },

                    new ValorFactorModelo()
                    {
                        Nombre = v3,
                        Valor = 2
                    }
                }
            };


            using (var contexto = new Contexto())
            {
                contexto.Factores.Add(factor);

                try
                {
                    if (contexto.SaveChanges() == 1)
                        Console.WriteLine("Se ha insertado correctamente.");
                }

                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine("No se ha podido insertar. Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }

        }

        public void BajaFactor()
        {
            ListarFactores();
            Console.WriteLine();
            Console.WriteLine("----------------------BAJA FACTOR----------------------");
            Console.WriteLine("Ingrese el ID del factor");
            var idFactor = Console.ReadLine();

            int id;

            if (!int.TryParse(idFactor, out id))
            {
                Console.WriteLine("El valor no es valido. Vuelva al menu anterior e intente nuevamente.");
                return;
            }


            using (var contexto = new Contexto())
            {
                var factorBuscado = contexto.Factores.Find(idFactor);
                if(factorBuscado != null)
                {
                    contexto.Factores.Remove(factorBuscado);

                    try
                    {
                        if (contexto.SaveChanges() == 1)
                            Console.WriteLine("Se ha eliminado exitosamente");
                    }

                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine(
                            "No se puede borrar el factor seleccionado. Presione una tecla para continuar...");
                        Console.ReadKey();
                    }

                }
                else Console.WriteLine("El ID del factor ingresado no existe");

            }
        }

        public void ModificarFactor()
        {
            ListarFactores();
            Console.WriteLine();
            Console.WriteLine("----------------------MODIFICAR FACTOR----------------------");
            Console.WriteLine("Ingrese el ID de factor.");
            var idFactor = Console.ReadLine();

            int id;

            if (!int.TryParse(idFactor, out id))
            {
                Console.WriteLine("El valor no es valido. Vuelva al menu anterior e intente nuevamente.");
                return;
            }


            using (var contexto = new Contexto())
            {

                var factorUpdate = contexto.Factores.Where(b => b.Codigo == Convert.ToInt32(idFactor)).Include(v => v.Valores).FirstOrDefault();
                if (factorUpdate != null)
                {
                    Console.WriteLine("Ingrese nombre de factor");
                    factorUpdate.Nombre = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Ingrese nombre del valor 1 asociado al factor");
                    factorUpdate.Valores[0].Nombre = Console.ReadLine();

                    //factorUpdate.Valores[0].Valor = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Ingrese nombre del valor 2 asociado al factor");
                    factorUpdate.Valores[1].Nombre = Console.ReadLine();
                    //factorUpdate.Valores[1].Valor = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Ingrese nombre del valor 3 asociado al factor");
                    Console.WriteLine();
                    factorUpdate.Valores[2].Nombre = Console.ReadLine();

                    try
                    {
                        if (contexto.SaveChanges() == 1)
                            Console.WriteLine("Se ha modificado exitosamente...");
                    }
                    catch (DbUpdateException exception)
                    {
                        Console.WriteLine("No se ha podido modificar");
                    }
                }
                else Console.WriteLine("El ID de factor ingresado no existe.");
            }
            
        }


    }
}




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
            Console.WriteLine("----------------------| MENU FACTOR |----------------------");
            Console.WriteLine("1 - Alta Factor");
            Console.WriteLine("2 - Baja Factor");
            Console.WriteLine("3 - Modificación Factor");
            Console.WriteLine("4 - Menu Principal");
            Console.WriteLine();
            this.ListarFactores();
            Console.WriteLine("Ingrese una opcion");
            var opcionFactor = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            return opcionFactor;
        }

        public void ListarFactores()
        {
            Console.WriteLine("----------------------| LISTADO DE FACTORES |----------------------");
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
            Console.WriteLine("----------------------| ALTA FACTOR |----------------------");
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
            Console.WriteLine();

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
                        Console.WriteLine("Se agregó exitosamente el Factor");
                }
                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine("Error al insertar. Intente nuevamente.");
                }
            }
        }

        public void EliminarFactor()
        {
            this.ListarFactores();
            Console.WriteLine("----------------------| BAJA FACTOR |----------------------");
            Console.WriteLine("Ingrese el ID del Factor que desea eliminar. Luego presione enter:");
            var idFactor = Console.ReadLine();

            int id;

            if (!int.TryParse(idFactor, out id))
            {
                Console.WriteLine("El valor no es valido. Vuelva al menu anterior e intente nuevamente.");
                return;
            }

            using (var contexto = new Contexto())
            {
                var factorBuscado = contexto.Factores.Find(id);

                if (factorBuscado != null)
                {
                    contexto.Factores.Remove(factorBuscado);
                    try
                    {
                        if (contexto.SaveChanges() == 1)
                            Console.WriteLine("Se eliminó exitosamente el Factor");
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine("No se puede borrar el Factor seleccionado debido a que esta relacionado a otra/s entidad/es");
                    }
                }
                else Console.WriteLine("El ID del Factor ingresado no existe");
            }
        }

        public void ModificarFactor()
        {
            this.ListarFactores();
            Console.WriteLine("----------------------| MODIFICAR FACTOR |----------------------");
            Console.WriteLine("Ingrese el ID del Factor que desea modificar. Luego presione enter:");

            var idFactor = Console.ReadLine();

            int id;

            if (!int.TryParse(idFactor, out id))
            {
                Console.WriteLine("El valor no es valido. Vuelva al menu anterior e intente nuevamente.");
                return;
            }

            using (var contexto = new Contexto())
            {
                var factorUpdate = contexto.Factores.Where(b => b.Codigo == id).Include(v => v.Valores).FirstOrDefault();

                if (factorUpdate != null)
                {
                    Console.WriteLine("Ingrese Nombre:");
                    factorUpdate.Nombre = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Ingrese Nombre del VALOR 1 asociado al factor:");
                    factorUpdate.Valores[0].Nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese Nombre del VALOR 2 asociado al factor:");
                    factorUpdate.Valores[1].Nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese Nombre del VALOR 3 asociado al factor:");
                    factorUpdate.Valores[2].Nombre = Console.ReadLine();

                    try
                    {
                        if (contexto.SaveChanges() == 1)
                            Console.WriteLine("Se modificó exitosamente el Factor");
                    }
                    catch (DbUpdateException exception)
                    {
                        Console.WriteLine("Error al modificar un Factor.");
                    }
                }
                else Console.WriteLine("El ID de Factor ingresado no existe.");
            }
        }
    }
}




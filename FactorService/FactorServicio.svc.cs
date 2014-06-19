using System;

using Gestor;

namespace FactorService
{
    using System.Collections.Generic;
    using System.Linq;

    using DTO;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FactorServicio : IFactorServicio
    {
        private FactorGestor factorGestor = new FactorGestor();

        public IList<Factor> Listar()
        {
            return this.factorGestor.Listar().Select(factor => new Factor
                                                         {
                                                             Codigo = factor.Codigo,
                                                             Nombre = factor.Nombre,
                                                             Valores = factor.ValoresFactores.Select(valor => new FactorValor
                                                                                                                  {
                                                                                                                      Codigo = valor.Codigo,
                                                                                                                      Nombre = valor.Nombre,
                                                                                                                      Valor = valor.Valor
                                                                                                                  }).ToList(),
                                                             Valor1 = new FactorValor
                                                             {
                                                                 Codigo = factor.Valor1.Codigo,
                                                                 Nombre = factor.Valor1.Nombre,
                                                                 Valor = factor.Valor1.Valor
                                                             },
                                                             Valor2 = new FactorValor
                                                             {
                                                                 Codigo = factor.Valor2.Codigo,
                                                                 Nombre = factor.Valor2.Nombre,
                                                                 Valor = factor.Valor2.Valor
                                                             },
                                                             Valor3 = new FactorValor
                                                             {
                                                                 Codigo = factor.Valor3.Codigo,
                                                                 Nombre = factor.Valor3.Nombre,
                                                                 Valor = factor.Valor3.Valor
                                                             }
                                                         }).ToList();
        }

        public void Guardar(Factor f)
        {
            this.factorGestor.Guardar(new FactorDTO
            {
                Nombre = f.Nombre,
                Codigo = f.Codigo,
                Valor1 = new ValorFactorDTO
                {
                    Codigo = f.Valor1.Codigo,
                    Nombre = f.Valor1.Nombre,
                    Valor = f.Valor1.Valor
                },
                Valor2 = new ValorFactorDTO
                {
                    Codigo = f.Valor2.Codigo,
                    Nombre = f.Valor2.Nombre,
                    Valor = f.Valor2.Valor
                },
                Valor3 = new ValorFactorDTO
                {
                    Codigo = f.Valor3.Codigo,
                    Nombre = f.Valor3.Nombre,
                    Valor = f.Valor3.Valor
                }
            });
        }

        public void Eliminar(Factor f)
        {
            this.factorGestor.Eliminar(new FactorDTO { Codigo = f.Codigo });
        }

        public Factor GetById(int id)
        {
            var factorDto = this.factorGestor.GetById(id);
            return new Factor
                       {
                           Codigo = factorDto.Codigo,
                           Nombre = factorDto.Nombre,
                           Valores =
                               factorDto.ValoresFactores.Select(
                                   valor =>
                                   new FactorValor
                                       {
                                           Codigo = valor.Codigo,
                                           Nombre = valor.Nombre,
                                           Valor = valor.Valor
                                       }).ToList(),
                           Valor1 =
                               new FactorValor
                                   {
                                       Codigo = factorDto.Valor1.Codigo,
                                       Nombre = factorDto.Valor1.Nombre,
                                       Valor = factorDto.Valor1.Valor
                                   },
                           Valor2 =
                               new FactorValor
                                   {
                                       Codigo = factorDto.Valor2.Codigo,
                                       Nombre = factorDto.Valor2.Nombre,
                                       Valor = factorDto.Valor2.Valor
                                   },
                           Valor3 =
                               new FactorValor
                                   {
                                       Codigo = factorDto.Valor3.Codigo,
                                       Nombre = factorDto.Valor3.Nombre,
                                       Valor = factorDto.Valor3.Valor
                                   }
                       };
        }
    }
}

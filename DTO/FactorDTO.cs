using System.Collections.Generic;

using Modelo;

namespace DTO
{
    public class FactorDTO : FactorModelo
    {
        public FactorDTO()
            : base()
        {
            ValoresFactores = new List<ValorFactorDTO>();
        }

        public List<ValorFactorDTO> ValoresFactores { get; set; }

        public ValorFactorDTO Valor1
        {
            get
            {
                return ValoresFactores.Count == 3 ? ValoresFactores[0] : new ValorFactorDTO();

                //var valorFactorModelo = Valores[0];
                //return new ValorFactorDTO
                //           {
                //               Nombre = valorFactorModelo.Nombre,
                //               Codigo = valorFactorModelo.Codigo,
                //               Valor = valorFactorModelo.Valor,
                //               Factor = valorFactorModelo.Factor
                //           };
            }

            set
            {
                this.ValoresFactores.Add(value);
            }
        }

        public ValorFactorDTO Valor2
        {
            get
            {
                return ValoresFactores.Count == 3 ? ValoresFactores[1] : new ValorFactorDTO();
            }

            set
            {
                this.ValoresFactores.Add(value);
            }
        }

        public ValorFactorDTO Valor3
        {
            get
            {
                return ValoresFactores.Count == 3 ? ValoresFactores[2] : new ValorFactorDTO();
            }

            set
            {
                this.ValoresFactores.Add(value);
            }
        }
    }
}

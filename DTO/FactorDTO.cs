using Modelo;

namespace DTO
{
    using System.Linq;

    public class FactorDTO : FactorModelo
    {
        public FactorDTO()
            : base()
        {
        }

        public ValorFactorDTO Valor1
        {
            get
            {
                var valorFactorModelo = Valores[0];
                return new ValorFactorDTO
                           {
                               Nombre = valorFactorModelo.Nombre,
                               Codigo = valorFactorModelo.Codigo,
                               Valor = valorFactorModelo.Valor,
                               Factor = valorFactorModelo.Factor
                           };
            }

            set
            {
                this.Valores.Add(value);
            }
        }

        public ValorFactorDTO Valor2
        {
            get
            {
                var valorFactorModelo = Valores[1];
                return new ValorFactorDTO
                {
                    Nombre = valorFactorModelo.Nombre,
                    Codigo = valorFactorModelo.Codigo,
                    Valor = valorFactorModelo.Valor,
                    Factor = valorFactorModelo.Factor
                };
            }

            set
            {
                this.Valores.Add(value);
            }
        }

        public ValorFactorDTO Valor3
        {
            get
            {
                var valorFactorModelo = Valores[2];
                return new ValorFactorDTO
                {
                    Nombre = valorFactorModelo.Nombre,
                    Codigo = valorFactorModelo.Codigo,
                    Valor = valorFactorModelo.Valor,
                    Factor = valorFactorModelo.Factor
                };
            }

            set
            {
                this.Valores.Add(value);
            }
        }
    }
}

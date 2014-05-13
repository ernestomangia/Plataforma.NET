namespace Modelo
{
    public class ValorFactorModelo
    {
        public int Codigo { get; set; }
        
        public string Nombre { get; set; }

        public double Valor { get; set; }

        public FactorModelo Factor { get; set; } 
    }
}

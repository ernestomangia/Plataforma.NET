using Modelo;
using System.Data.Entity;

namespace Repositorio
{
    public class FactorRepositorio : Repositorio<FactorModelo> 
    {
        public FactorRepositorio(DbContext ctx)
            : base(ctx)
        {
        }
    }
}

using System.Data.Entity;
using System.Linq;

using Modelo;

namespace Repositorio
{
    public class FactorRepositorio : Repositorio<FactorModelo>
    {
        public FactorRepositorio(DbContext ctx)
            : base(ctx)
        {
        }

        public override FactorModelo GetById(int id)
        {
            return DbSet.Where(f => f.Codigo == id).Include(f => f.Valores).Include(f => f.Proyectos).FirstOrDefault();
        }
    }
}

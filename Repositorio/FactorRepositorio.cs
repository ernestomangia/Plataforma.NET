using System.Data.Entity;

using Modelo;

namespace Repositorio
{
    using System.Linq;

    public class FactorRepositorio : Repositorio<FactorModelo>
    {
        public FactorRepositorio(DbContext ctx)
            : base(ctx)
        {
            //DbSet = DbSet.Include(f => f.Valores).Include(f => f.Proyectos).();
        }

        public override FactorModelo GetById(int id)
        {
            return DbSet.Where(f => f.Codigo == id).Include(f => f.Valores).Include(f => f.Proyectos).FirstOrDefault();
        }
    }
}

using System.Data.Entity;
using System.Linq;

namespace Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        #region Protected Members

        protected DbSet<T> DbSet;
        protected DbContext Context;

        #endregion

        #region Constructor(s)

        public Repositorio(DbContext ctx)
        {
            Context = ctx;
            DbSet = ctx.Set<T>();
        }

        #endregion

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Guardar(T entidad, int id)
        {
            if (id == 0)
            {
                DbSet.Add(entidad);
            }

            Context.SaveChanges();
        }

        public IQueryable<T> Listar()
        {
            return DbSet;
        }

        public void Eliminar(T entidad)
        {
            DbSet.Remove(entidad);
            Context.SaveChanges();
        }
    }
}

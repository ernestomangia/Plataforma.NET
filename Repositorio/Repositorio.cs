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

        T IRepositorio<T>.GetById(int id)
        {
            return DbSet.Find(id);
        }

        void IRepositorio<T>.Guardar(T entidad, int id)
        {
            if (id == 0)
            {
                DbSet.Add(entidad);
            }

            Context.SaveChanges();
        }

        IQueryable<T> IRepositorio<T>.Listar()
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

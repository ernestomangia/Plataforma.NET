using System.Linq;

namespace Repositorio
{
    public interface IRepositorio<T>
    {
        T GetById(int id);

        void Guardar(T entidad, int id);

        IQueryable<T> Listar();

        void Eliminar(T entidad);
    }
}

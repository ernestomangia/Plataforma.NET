using System.Collections.Generic;

namespace Gestor
{
    public interface IGestor<T> where T : class
    {
        void Guardar(T entidad);
        
        void Eliminar(T entidad);
        
        T GetById(int id);
        
        IList<T> Listar();

        bool Validar(T entidad);
    }
}

using AppCrudAdo_0209.Models;

namespace AppCrudAdo_0209.Repository.IRepository
{
    public interface IContactoRepository<T>
    {
        //Creando los metodos para las interfaces

        Task<List<T>> GetAll();

        Task<T>GetbyID(int id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete (int id);
    }
}

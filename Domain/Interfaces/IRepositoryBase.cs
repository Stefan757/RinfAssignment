using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        bool Exists(int id);

        T? Get(int id);

        List<T> GetAll();

        bool Delete(int id);
    }
}
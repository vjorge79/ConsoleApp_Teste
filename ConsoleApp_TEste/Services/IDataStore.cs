using System.Collections.Generic;

namespace ConsoleApp_TEste.Services
{
    public interface IDataStore<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(int id);
    }
}

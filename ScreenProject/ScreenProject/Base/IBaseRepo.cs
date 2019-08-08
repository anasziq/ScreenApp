using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.Base
{
    public interface IBaseRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T t);
        Task Update(int id, T t);
        Task Delete(int id);
        Task DeleteAll();
    }
}

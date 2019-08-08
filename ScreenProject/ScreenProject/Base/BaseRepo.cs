using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.Base
{

    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {

        private AppContext _app;
        public BaseRepo(AppContext app)
        {
            this._app = app;
        }
        public virtual async Task<List<T>> GetAll()
        {

            return await _app.Set<T>().ToListAsync();
        }
        public virtual async Task<T> Get(int id)
        {
            return await _app.Set<T>().FindAsync(id);
        }
        public  async Task Add(T t)
        {
           await _app.Set<T>().AddAsync(t);
           await _app.SaveChangesAsync();
        }
        public async Task Update(int id, T t)
        {
            _app.Set<T>().Update(t);
            await _app.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            _app.Remove(_app.Set<T>().Find(id));
            await _app.SaveChangesAsync();

        }
        public async Task DeleteAll()
        {
            _app.Set<T>().RemoveRange(_app.Set<T>().ToList());
            await _app.SaveChangesAsync();

        }


    }
}

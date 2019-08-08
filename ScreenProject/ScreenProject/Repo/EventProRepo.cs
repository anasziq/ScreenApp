using Microsoft.EntityFrameworkCore;
using ScreenProject.Base;
using ScreenProject.IRepo;
using ScreenProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.Repo
{
    public class EventProRepo : BaseRepo<EventPropereties> , IEventPro
    {

        AppContext _app;
        public EventProRepo(AppContext app) : base(app)
        {
            this._app = app;
        }
        public override async Task<List<EventPropereties>> GetAll()
        {
            return await _app.Set<EventPropereties>(). Include(c => c.Events).Include(d => d.TempFields).ToListAsync();
        }
        public override async Task<EventPropereties> Get(int id)
        {
            return await _app.Set<EventPropereties>().Include(c => c.Events).Include(d => d.TempFields).FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
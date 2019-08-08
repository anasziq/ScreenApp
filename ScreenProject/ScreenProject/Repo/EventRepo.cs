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
    public class EventRepo : BaseRepo<Event>, IEvent
    {

        AppContext _app;
        public EventRepo(AppContext app) : base(app)
        {
            this._app = app;
        }
        public override async Task<List<Event>> GetAll()
        {
            return await _app.Set<Event>().Include(d => d.Templates).ThenInclude(c => c.TemplatesFields).ThenInclude(r => r.EventPropers).ToListAsync();
        }
        public override async Task<Event> Get(int id)
        {
            return await _app.Set<Event>().Include(c => c.EventsProps).Include(d => d.Templates).FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}

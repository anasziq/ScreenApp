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
    public class TemplateRepo : BaseRepo<Template>, ITemplate
    {

        AppContext _app;
        public TemplateRepo(AppContext app) : base(app)
        {
            this._app = app;
        }
        public override async Task<List<Template>> GetAll()
        {
            return await _app.Set<Template>().Include(c => c.Events).Include(d => d.TemplatesFields).ToListAsync();
        }
        public override async Task<Template> Get(int id)
        {
            return await _app.Set<Template>().Include(c => c.Events).Include(d => d.TemplatesFields).FirstOrDefaultAsync(c => c.Id == id);
        }
            
    }   
}

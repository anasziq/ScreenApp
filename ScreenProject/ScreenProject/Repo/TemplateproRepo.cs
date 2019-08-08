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
    public class TemplateproRepo : BaseRepo<TemplateProperties>, ITemplatePro
    {

        AppContext _app;
        public TemplateproRepo(AppContext app) : base(app)
        {
            this._app = app;
        }
        public override async Task<List<TemplateProperties>> GetAll()
        {
            return await _app.Set<TemplateProperties>().Include(c => c.EventPropers).Include(d => d.Template).ToListAsync();
        }
        public override async Task<TemplateProperties> Get(int id)
        {
            return await _app.Set<TemplateProperties>().Include(c => c.EventPropers).Include(d => d.Template).FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}

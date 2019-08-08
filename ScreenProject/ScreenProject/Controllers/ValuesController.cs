using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ScreenProject.IRepo;
using ScreenProject.Models;
using ScreenProject.ViewModel;

namespace ScreenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMapper _mapp;

        private ITemplate _inter;

      public  ValuesController(IMapper mapp , ITemplate Item)
        {
            this._mapp = mapp;
            this._inter = Item;
        }

       
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public async Task<List<TemplateViewModel>> Get()
        {
            var x = await _inter.GetAll();
            var evm = _mapp.Map<List<TemplateViewModel>>(x);
            return evm;
        }

        // GET api/values/5
        [EnableCors("AllowOrigin")]
        [HttpGet("{id}")]
        public async Task<TemplateViewModel> GetAsync(int id)
        {
           Template x = await _inter.Get(id);
            TemplateViewModel tvm = _mapp.Map<TemplateViewModel>(x);
            return tvm;
        }

        // POST api/values
        [HttpPost]
        public async Task PostAsync([FromBody] Template t)
        {
           await _inter.Add(t);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Template t)
        {
            await _inter.Update(id,t);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _inter.Delete(id);
        }
        [HttpDelete("All")]
        public async Task DeleteAll(int id)
        {
          await _inter.DeleteAll();
        }
    }
}

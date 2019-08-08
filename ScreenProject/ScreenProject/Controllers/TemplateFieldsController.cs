using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScreenProject.IRepo;
using ScreenProject.Models;
using ScreenProject.ViewModel;

namespace ScreenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateFieldsController : ControllerBase
    {
        private ITemplatePro _item;
        private readonly IMapper mapper;

        public TemplateFieldsController( ITemplatePro item , IMapper mapper)
        {
            _item = item;
            this.mapper = mapper;
        }
        // GET api/values
       
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public async Task<List<TemplateFieldsViewModel>> Get()
        {

            var x = await _item.GetAll();
            var evm = mapper.Map<List<TemplateFieldsViewModel>>(x);
            return evm;
        }
        // GET api/values/5


        // POST api/values
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public async Task PostAsync([FromBody] TemplateProperties t)
        {
            await _item.Add(t);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _item.Delete(id);
        }
        [HttpDelete("All")]
        public async Task DeleteAll(int id)
        {
            await _item.DeleteAll();
        }
    }
}
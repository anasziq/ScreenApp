using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScreenProject.IRepo;
using ScreenProject.Models;

namespace ScreenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventPropsController : ControllerBase
    {
        private IEventPro _ievent;
        public EventPropsController(IEventPro ievent)
        {
            this._ievent = ievent;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet]
        public async Task<List<EventPropereties>> Get()
        {
            return await _ievent.GetAll();
        }
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public async Task Post([FromBody] EventPropereties t)
        {
          await _ievent.Add(t);

        }
        [HttpDelete("All")]
        public async Task DeleteAll()
        {
            await _ievent.DeleteAll();
        }
    }
}
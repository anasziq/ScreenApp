using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ScreenProject.IRepo;
using ScreenProject.Models;
using ScreenProject.ViewModel;

namespace ScreenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEvent _ievent;
        private readonly IMapper mapper;
        private AppSetting appSettings;

        public EventController(IEvent ievent , IMapper mapper, IOptions<AppSetting> appSettingsOptions)
        {
            this.appSettings = appSettingsOptions.Value;
            this._ievent = ievent;
            this.mapper = mapper;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet]
        public async Task<List<EventViewModel>> Get()
        {

            var x = await _ievent.GetAll();
            var evm = mapper.Map<List<EventViewModel>>(x);
            return evm;
        }
        [EnableCors("AllowOrigin")]
        [HttpGet("appSetting")]
        public AppSetting GetApp()
        {
            return appSettings;
        }


        [EnableCors("AllowOrigin")]
        [HttpGet("{id}")]
        public async Task<Event> GetAsync(int id)
        {
            return await _ievent.Get(id);
        }


        [EnableCors("AllowOrigin")]
        [HttpPost]
        public async Task Post([FromBody] Event t)
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
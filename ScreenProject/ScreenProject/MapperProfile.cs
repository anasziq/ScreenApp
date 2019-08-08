using AutoMapper;
using ScreenProject.Models;
using ScreenProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Template, TemplateViewModel>().ReverseMap();
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<EventPropereties, EventProViewModel>().ReverseMap();
            CreateMap<TemplateProperties, TemplateFieldsViewModel > ().ReverseMap();

            ////CreateMap<Drivers, DriverViewModel>()
            ////   .ForMember(c => c.CarName, map => map.MapFrom<string>(c => c.myCar.Name));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroungImg { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<TemplateProperties> TemplatesFields { get; set; }
    }
}

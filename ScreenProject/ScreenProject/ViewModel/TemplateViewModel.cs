using ScreenProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.ViewModel
{
    public class TemplateViewModel
    {
        public int Id { get; set; }
        public string BackgroungImg { get; set; }
        public string Name { get; set; }
        public ICollection<TemplateFieldsViewModel> TemplatesFields { get; set; }

    }
}

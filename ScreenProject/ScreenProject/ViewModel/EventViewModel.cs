using ScreenProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.ViewModel
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public string Occurence { get; set; }
        public int Priorty { get; set; }
        public TemplateViewModel Templates { get; set; }
    }
}

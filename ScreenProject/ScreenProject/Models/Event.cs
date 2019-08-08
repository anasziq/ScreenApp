using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.Models
{
    public class Event
    {

        public int Id { get; set; }
        public string Type { get; set; }
        public int TemplateId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public string Occurence { get; set; }

        public int Priorty { get; set; }
        public ICollection<EventPropereties> EventsProps { get; set; }
        public Template Templates { get; set; }
    }
}

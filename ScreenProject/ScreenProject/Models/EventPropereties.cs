using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.Models
{
    public class EventPropereties
    {

        public int Id { get; set; }

        public int EventId { get; set; }
        public string value { get; set; }
        public int TempfieldId { get; set; }
        public Event Events { get; set; }
        public TemplateProperties TempFields { get; set; }
    }
}

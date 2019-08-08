using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenProject.Models
{
    public class TemplateProperties
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public int FontSize { get; set; }
        public int TopMargin { get; set; }
        public int LeftMargin { get; set; }
        public string FontFamily { get; set; }
        public string ForeColor { get; set; }

        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public EventPropereties EventPropers { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDigital
{
    public class Website
    {
        public int IdWebsite { get; set; }
        public string Name { get; set; }
        public Website()

        {
            IdWebsite = 0;
            Name = string.Empty;
        }
    }
}

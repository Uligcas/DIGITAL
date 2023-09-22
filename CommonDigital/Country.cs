using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDigital
{
    public class Country
    {
        public int IdCountry { get; set; }
        public string ISO { get; set; }
        public Country()

        {
            IdCountry = 0;
            ISO = string.Empty;
        }
    }
}

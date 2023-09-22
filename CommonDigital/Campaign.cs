using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDigital
{
    public class Campaign
    {
        public int Id { get; set; }
        public int IdCampaign { get; set; }
        public int IdBrand { get; set; }
        public int IdCountry { get; set; }

        public string Name { get; set; }
        public string LandingPage { get; set; }

        public Campaign()

        {
            Id = 0;
            IdBrand = 0;
            IdCountry = 0;
            LandingPage = string.Empty;
            Name = string.Empty;
        }
    }
}

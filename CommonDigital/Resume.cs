using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDigital
{
    public class Resume
    {
        public int Id { get; set; }
        public int Campaign { get; set; }
        public int IdWebsite { get; set; }
        public string Website_sections { get; set; }
        public int IdDevice { get; set; }
        public string Ad_type_id { get; set; }
        public string Ad_type { get; set; }
        public string Ad_link { get; set; }
        public string Ad_servers { get; set; }
        public string Ad_sizes { get; set; }
        public string Ad_lengths { get; set; }
        public string Sold_bys { get; set; }
        public string Screenshot_link { get; set; }
        public DateTime Date { get; set; }
        public int Metrics_count { get; set; }
        public int Metrics_impressions { get; set; }
        public int Metrics_impact { get; set; }
        public int Metrics_valuation { get; set; }
        public int Metrics_valuation_usd { get; set; }
        public int Metrics_blocker_avg { get; set; }

 public        Resume ()
        {
            Id = 0;
            Campaign = 0;
            IdDevice = 0;
            IdWebsite = 0;
            Website_sections    =string.Empty;
            Ad_type_id = string.Empty;
            Ad_type = string.Empty;
            Ad_link = string.Empty;
            Ad_servers =string.Empty;
            Ad_sizes =string.Empty; 
            Ad_lengths =string.Empty;
            Sold_bys =string.Empty;
            Screenshot_link =string.Empty;
            Date = DateTime.Now;
            Metrics_count = 0;
            Metrics_impact = 0;
            Metrics_valuation = 0;
            Metrics_valuation_usd = 0;
            Metrics_blocker_avg = 0;
        }


    }
}

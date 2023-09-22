using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDigital
{
    public class Brand : ICloneable
    {

        

        public int IdBrand { get; set; }
        public int IdCountry { get; set; }
        public int IdIndustry { get; set; }
        public string Name { get; set; }


        public Brand()

        {
            IdBrand = 0;
            IdCountry = 0;  
            IdIndustry = 0;
            Name = string.Empty;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

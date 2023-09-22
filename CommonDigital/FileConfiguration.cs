using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDigital
{
    public class FileConfiguration
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileProcess { get; set; }
        public string Statu { get; set; }
        public DateTime Date { get; set; }


        public FileConfiguration()

        {
            Id = 0;
            FileName = string.Empty;
            FileProcess = string.Empty; 
            Statu = string.Empty;
            Date = DateTime.Now;
        }

    }
}

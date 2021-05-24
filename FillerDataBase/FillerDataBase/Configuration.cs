using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillerDataBase
{
    class Configuration
    {
        [Key]
        public int Id { get; set; }

        public string Processor { get; set; }
        public string Motherboard { get; set; }
        public string Videocard { get; set; }
        public string RAM { get; set; }
        public string HDD { get; set; }
        public string SSD { get; set; }
        public string Cooling { get; set; }
        public string PowerModule { get; set; }
        public string Case { get; set; }
        public string Target { get; set; }
        public string Budget { get; set; }
    }
}

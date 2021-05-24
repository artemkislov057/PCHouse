using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class Processor : IComponent
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string Socket { get; set; }
        public double RamFrequency { get; set; }

    }
}

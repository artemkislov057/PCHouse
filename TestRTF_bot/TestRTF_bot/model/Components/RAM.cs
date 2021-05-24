using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class RAM : IComponent
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string TypeMemory { get; set; }
        public double Frequency { get; set; }
        public string Latency { get; set; }
    }
}

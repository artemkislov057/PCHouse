using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class Motherboard : IComponent
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string Socket { get; set; }
        public RAM Ram { get; set; }
        public int CoolingProcess { get; set; }
        public int CoolingCase { get; set; }
        public int SataInterfaceCount { get; set; }
    }
}

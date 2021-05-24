using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class Motherboard : IAccessory
    {
        public int Cost { get; set; }
        public int Rating { get; set; }
        public CharacteristicsInfo Characteristics { get; set; }
    }
}

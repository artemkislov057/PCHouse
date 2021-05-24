using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class VideoCard : IComponent
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string Power { get;  set; }
        public int Length { get;  set; }
        public int Width { get;  set; }
        public int Height { get;  set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class VideoCard : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public int Length { get; set; } // до передней стенки корпуса
        public int Width { get; set; } // до боковой стенки корпуса
        public int Height { get; set; }
        public int EnergyConsumption { get; set; }
    }
}

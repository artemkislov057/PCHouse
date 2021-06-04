using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class Processor : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string Socket { get; set; }
        public double RamFrequency { get; set; }   // Здесь частота у нас double, хотя в самой памяти она int
        public int EnergyConsumption { get; set; }

        public bool IsCompatible(IComponent otherComponent)
        {
            if (otherComponent is RAM ram)
                return true;
            if(otherComponent is Motherboard motherboard)
                return motherboard.IsCompatible(this);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.model.Components;

namespace TestRTF_bot.Models.Accessories
{
    class PowerModule : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public int Power { get; set; }
        public string PinPowerCP { get; set; }
        public string PinPowerVideoCard { get; set; }
        public int SataCount { get; set; }

        public bool IsCompatible(IComponent otherComponent)
        {
            if (otherComponent is VideoCard videoCard)
                return videoCard.PinPowerVideoCard.ToLower() == PinPowerVideoCard.ToLower();
            if (otherComponent is Motherboard motherboard)
                return motherboard.IsCompatible(this);
            return true;
        }
    }
}

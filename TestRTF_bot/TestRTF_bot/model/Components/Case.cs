using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class Case : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string ARRAY_FormFactor { get; set; }
        public string ARRAY_FanSlotsAndDiameter { get; set; }
        public bool PossibilityOfInstallationWaterCooling { get; set; }
        public string ARRAYWaterCoolingSlotsAndDiameter { get; set; }
        public int MaximumHeightOfTowerCooler { get; set; }
        public int MaximumWidthOfVideoCard { get; set; }
        public int MaximumHeightOfVideoCard { get; set; }
    }
}

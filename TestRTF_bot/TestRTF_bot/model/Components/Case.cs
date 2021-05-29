using System.ComponentModel.DataAnnotations;

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
        public string ARRAY_FanSlotsAndSize { get; set; }
        public bool PossibilityOfInstallationWaterCooling { get; set; }
        public string ARRAYWaterCoolingSlotsAndSize { get; set; }
        public int MaximumHeightOfTowerCooler { get; set; }
        public int MaximumWidthOfVideoCard { get; set; }
        public int MaximumHeightOfVideoCard { get; set; }

        public bool IsCompatible(IComponent otherComponent)
        {
            throw new System.NotImplementedException();
        }
    }
}

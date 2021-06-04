using System.Linq;
using System.ComponentModel.DataAnnotations;
using TestRTF_bot.model;
using TestRTF_bot.model.Components;

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
        public int MaximumHeightOfTowerCooler { get; set; }
        public int MaximumWidthOfVideoCard { get; set; }
        public int MaximumHeightOfVideoCard { get; set; }
        public int MaximumLengthOfVideoCard { get; set; }

        public bool IsCompatible(IComponent otherComponent)
        {
            if (otherComponent is Motherboard motherboard)
                return GetFormFactors().Any(x => x.ToLower() == motherboard.FormFactor.ToLower());

            if (otherComponent is CaseCooling caseCooling)
                return GetFanSlotsAndSize().Any(x => x.ToLower() == caseCooling.FanSize.ToString().ToLower());

            if (otherComponent is ProcessorCooling cpuCooler)
                return MaximumHeightOfTowerCooler >= cpuCooler.CoolerHeight;

            if (otherComponent is VideoCard videoCard)
                return MaximumLengthOfVideoCard >= videoCard.Length;
            return true;
        }

        public string[] GetFormFactors() => ARRAY_FormFactor.GetArray();

        public string[] GetFanSlotsAndSize() => ARRAY_FanSlotsAndSize.GetArray();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model
{
    public interface ITarget
    {
        int ProcessorPercent { get; }
        int MotherboardPercent { get; }
        int RAMPercent { get; }
        int VideoCardPercent { get; }
        int PowerModulePercent { get; }
        int CasePercent { get; }
        int StoragePercent { get; }
        int M2Percent { get; }
        int ProcessorCoolingPercent { get; }
        int CaseCoolingPercent { get; }
        double ProcessorRating { get; }
        double MotherboardRating { get; }
        double RAMRating { get; }
        double VideoCardRating { get; }
        double PowerModuleRating { get; }
        double CaseRating { get; }
        double StorageRating { get; }
        double M2Rating { get; }
        double ProcessorCoolingRating { get; }
        double CaseCoolingRating { get; }
    }
}

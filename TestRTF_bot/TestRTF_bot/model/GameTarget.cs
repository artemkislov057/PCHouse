using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model
{
    class GameTarget : ITarget
    {
        public int ProcessorPercent => 15;

        public int MotherboardPercent => 15;

        public int RAMPercent => 26;

        public int VideoCardPercent => 56;

        public int PowerModulePercent => 20;

        public int CasePercent => 20;

        public int StoragePercent => 25;

        public int M2Percent => 30;

        public int ProcessorCoolingPercent => 18;

        public int CaseCoolingPercent => 100;

        public double ProcessorRating => 0.3;

        public double MotherboardRating => 0.3;

        public double RAMRating => 0.4;

        public double VideoCardRating => 0.6;

        public double PowerModuleRating => 0.2;

        public double CaseRating => 0.2;

        public double StorageRating => 0.4;

        public double M2Rating => 0.4;

        public double ProcessorCoolingRating => 0.4;

        public double CaseCoolingRating => 0.2;
    }
}

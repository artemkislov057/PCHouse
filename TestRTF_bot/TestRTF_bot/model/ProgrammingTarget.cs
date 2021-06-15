using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model
{
    class ProgrammingTarget : ITarget
    {
        public int ProcessorPercent => 30;

        public int MotherboardPercent => 16;

        public int RAMPercent => 25;

        public int VideoCardPercent => 26;

        public int PowerModulePercent => 70;

        public int CasePercent => 20;

        public int StoragePercent => 34;

        public int M2Percent => 40;

        public int ProcessorCoolingPercent => 70;

        public int CaseCoolingPercent => 100;

        public double ProcessorRating => 0.8;

        public double MotherboardRating => 0.4;

        public double RAMRating => 0.5;

        public double VideoCardRating => 0.5;

        public double PowerModuleRating => 0.4;

        public double CaseRating => 0.2;

        public double StorageRating => 0.6;

        public double M2Rating => 0.6;

        public double ProcessorCoolingRating => 0.5;

        public double CaseCoolingRating => 0.3;
    }
}

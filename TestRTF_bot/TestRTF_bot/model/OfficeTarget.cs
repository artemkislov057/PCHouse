using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model
{
    class OfficeTarget : ITarget
    {
        public int ProcessorPercent => 50;

        public int MotherboardPercent => 25;

        public int RAMPercent => 25;

        public int VideoCardPercent => 25;

        public int PowerModulePercent => 30;

        public int CasePercent => 10;

        public int StoragePercent => 25;

        public int M2Percent => 50;

        public int ProcessorCoolingPercent => 50;

        public int CaseCoolingPercent => 100;

        public double ProcessorRating => 0.7;

        public double MotherboardRating => 0.2;

        public double RAMRating => 0.4;

        public double VideoCardRating => 0.3;

        public double PowerModuleRating => 0.3;

        public double CaseRating => 0.2;

        public double StorageRating => 0.5;

        public double M2Rating => 0.5;

        public double ProcessorCoolingRating => 0.3;

        public double CaseCoolingRating => 0.1;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model
{
    class VideoEditingTarget : ITarget
    {
        public int ProcessorPercent => 40;

        public int MotherboardPercent => 15;

        public int RAMPercent => 20;

        public int VideoCardPercent => 40;

        public int PowerModulePercent => 30;

        public int CasePercent => 10;

        public int StoragePercent => 25;

        public int M2Percent => 30;

        public int ProcessorCoolingPercent => 50;

        public int CaseCoolingPercent => 100;

        public double ProcessorRating => 0.4;

        public double MotherboardRating => 0.4;

        public double RAMRating => 0.3;

        public double VideoCardRating => 0.8;

        public double PowerModuleRating => 0.6;

        public double CaseRating => 0.4;

        public double StorageRating => 0.8;

        public double M2Rating => 0.6;

        public double ProcessorCoolingRating => 0.5;

        public double CaseCoolingRating => 0.4;
    }
}

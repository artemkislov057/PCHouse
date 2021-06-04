using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model
{
    class OfficeTarget : ITarget
    {
        public int ProcessorPercent => 40;

        public int MotherboardPercent => 15;

        public int RAMPercent => 20;

        public int VideoCardPercent => 20;

        public int PowerModulePercent => 30;

        public int CasePercent => 10;

        public int StoragePercent => 25;

        public int M2Percent => 30;

        public int ProcessorCoolingPercent => 50;

        public int CaseCoolingPercent => 100;
    }
}

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
    }
}

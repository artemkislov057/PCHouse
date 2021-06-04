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
    }
}

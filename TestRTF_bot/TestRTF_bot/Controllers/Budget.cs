using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Controllers
{
    public class Budget
    {
        public int MinValue { get; }
        public int MaxValue { get; }

        public Budget(int MinValue, int MaxValue)
        {
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;
        }

        public override string ToString()
        {
            if (MaxValue <= 40)
                return "<40";
            if (MinValue == 80)
                return ">80";
            if (MinValue >= 100)
                return ">100";
            return MinValue.ToString() + "-" + MaxValue.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models
{
    public class UserInformation
    {
        public int MinCost { get; private set; }
        public int MaxCost { get; private set; }
        public Target Target { get; private set; }

        public UserInformation(int minCost, int maxCost, Target target)
        {
            this.MinCost = minCost;
            this.MaxCost = maxCost;
            this.Target = target;
        }
    }

}

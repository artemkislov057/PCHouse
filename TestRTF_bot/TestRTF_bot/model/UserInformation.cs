using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.Controllers;
using TestRTF_bot.model;

namespace TestRTF_bot.Models
{
    public class UserInformation
    {
        public int MinCost { get; set; }
        public int MaxCost { get; set; }
        public ITarget TargetInterface { get; set; }
        public Target Target { get; set; }
        public Budget Budget { get; set; }

        public UserInformation(int minCost, int maxCost, ITarget target)
        {
            this.MinCost = minCost;
            this.MaxCost = maxCost;
            this.TargetInterface = target;
        }

        public UserInformation()
        {

        }
    }
}

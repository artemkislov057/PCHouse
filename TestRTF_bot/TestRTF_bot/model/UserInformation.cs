using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.Controllers;

namespace TestRTF_bot.Models
{
    public class UserInformation
    {
        public Budget Budget { get; set; }
        public Target Target { get; set; }

        public UserInformation() { }
        public UserInformation(Budget budget, Target target)
        {
            this.Budget = budget;
            this.Target = target;
        }
    }

}

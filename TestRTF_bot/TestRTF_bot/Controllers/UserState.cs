using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.Models;

namespace TestRTF_bot.Controllers
{
    public class UserState
    {
        public UserInformation Info { get; set; }
        public State State { get; set; }

        public UserState(UserInformation userInformation, State state)
        {
            this.Info = userInformation;
            this.State = state;
        }
    }
}

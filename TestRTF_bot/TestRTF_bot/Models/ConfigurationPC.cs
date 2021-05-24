using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models
{
    class ConfigurationPC
    {
        public UserInformation UserInfo { get; set; }
        public IAccessory[] Accessories { get; set; }
        public int Rating { get; set; }
    }
}

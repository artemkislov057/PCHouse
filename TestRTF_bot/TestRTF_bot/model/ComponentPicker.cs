using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.Models;

namespace TestRTF_bot.model
{
    class ComponentPicker
    {
        public DataBase Data { get; set; } = new DataBase();

        public ConfigurationPC[] GetConfigurations(UserInformation userInformation)
        {
            throw new NotImplementedException();
        }
    }
}

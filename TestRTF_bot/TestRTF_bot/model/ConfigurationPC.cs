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
        public IComponent[] Components { get; set; }
        public ConfigurationPC(IComponent[] components)
        {
            Components = components;
        }
        public int Rating 
        {
            get
            {
                var rating = 0;
                if (Components == null || Components.Length == 0)
                    return 0;
                foreach (var component in Components)
                    rating += component.Rating;
                return rating;
            }
        }
    }
}

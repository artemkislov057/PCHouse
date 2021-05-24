using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models
{
    public class CharacteristicsInfo
    {
        private Dictionary<IAccessory, string> Characteristics;
        
        public CharacteristicsInfo(Type accessoryType, string accessoryName)
        {
            Characteristics = GetCharacteristics();
        }

        private Dictionary<IAccessory, string> GetCharacteristics()
        {
            throw new NotImplementedException();
        }
    }
}

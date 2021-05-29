using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.Models.Accessories;

namespace TestRTF_bot.model
{
    class DataBase
    {
        IEnumerable<Processor> processors; 
        IEnumerable<Motherboard> motherboards;
        IEnumerable<VideoCard> videoCards;
        IEnumerable<RAM> rams;
        IEnumerable<PowerModule> powerModules;
        IEnumerable<ProcessorCooling> coolings;
        IEnumerable<Case> cases;
    }
}
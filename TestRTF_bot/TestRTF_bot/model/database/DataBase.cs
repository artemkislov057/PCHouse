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
        Accessories<Processor> processors;
        Accessories<Motherboard> motherboards;
        Accessories<VideoCard> videoCards;
        Accessories<RAM> rams;
        Accessories<PowerModule> powerModules;
        Accessories<ProcessorCooling> coolings;
        Accessories<Case> cases;
    }
}
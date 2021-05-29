using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.model.Components;
using TestRTF_bot.model.database;
using TestRTF_bot.Models.Accessories;

namespace TestRTF_bot.model
{
    class DataBase
    {
        public Components<Processor> processors;
        public Components<Motherboard> motherboards;
        public Components<VideoCard> videoCards;
        public Components<RAM> rams;
        public Components<PowerModule> powerModules;
        public Components<ProcessorCooling> coolings;
        public Components<Case> cases;
        public Components<Storage> storages;
        public Components<M2> M2collection;
        public Components<CaseCooling> CaseCoolings;
    }
}
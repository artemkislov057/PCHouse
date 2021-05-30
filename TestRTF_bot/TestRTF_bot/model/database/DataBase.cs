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
        private DataBase
            (IEnumerable<Processor> processors,
            IEnumerable<Motherboard> motherboards,
            IEnumerable<VideoCard> videoCards,
            IEnumerable<RAM> rams,
            IEnumerable<PowerModule> powerModules,
            IEnumerable<ProcessorCooling> processorCoolings,
            IEnumerable<Case> cases,
            IEnumerable<Storage> storages,
            IEnumerable<M2> m2Collection,
            IEnumerable<CaseCooling> caseCoolings)
        {
            Processors = new ComponentsList<Processor>(processors, x => x.Cost);
            Motherboards = new ComponentsList<Motherboard>(motherboards, x => x.Cost);
            VideoCards = new ComponentsList<VideoCard>(videoCards, x => x.Cost);
            RAMs = new ComponentsList<RAM>(rams, x => x.Cost);
            PowerModules = new ComponentsList<PowerModule>(powerModules, x => x.Cost);
            ProcessorCoolings = new ComponentsList<ProcessorCooling>(processorCoolings, x => x.Cost);
            Cases = new ComponentsList<Case>(cases, x => x.Cost);
            Storages = new ComponentsList<Storage>(storages, x => x.Cost);
            M2Collection = new ComponentsList<M2>(m2Collection, x => x.Cost);
            CaseCoolings = new ComponentsList<CaseCooling>(caseCoolings, x => x.Cost);
        }

        private DataBase(ComponentsContext context) : this
            (context.Processors,
            context.Motherboards,
            context.VideoCards,
            context.RAMs,
            context.PowerModules,
            context.ProcessorCoolings,
            context.Cases, context.Storages,
            context.M2Collection,
            context.CaseCoolings)
        {

        }

        public readonly ComponentsList<Processor> Processors;
        public readonly ComponentsList<Motherboard> Motherboards;
        public readonly ComponentsList<VideoCard> VideoCards;
        public readonly ComponentsList<RAM> RAMs;
        public readonly ComponentsList<PowerModule> PowerModules;
        public readonly ComponentsList<ProcessorCooling> ProcessorCoolings;
        public readonly ComponentsList<Case> Cases;
        public readonly ComponentsList<Storage> Storages;
        public readonly ComponentsList<M2> M2Collection;
        public readonly ComponentsList<CaseCooling> CaseCoolings;

        public static DataBase DefaultDataBase()
        {
            return FromFile("DataBase.mdf");
        }

        public static DataBase FromContext(ComponentsContext context)
        {
            return new DataBase(context);
        }

        public static DataBase FromFile(string path)
        {
            DataBase result = null;
            using (var context = new ComponentsContext(path))
            {
                result = FromContext(context);
            }
            return result;
        }

        public static DataBase FromCollections
            (IEnumerable<Processor> processors,
            IEnumerable<Motherboard> motherboards,
            IEnumerable<VideoCard> videoCards,
            IEnumerable<RAM> rams,
            IEnumerable<PowerModule> powerModules,
            IEnumerable<ProcessorCooling> processorCoolings,
            IEnumerable<Case> cases,
            IEnumerable<Storage> storages,
            IEnumerable<M2> m2Collection,
            IEnumerable<CaseCooling> caseCoolings)
        {
            return new DataBase(processors, motherboards, videoCards, rams, powerModules, processorCoolings, cases, storages, m2Collection, caseCoolings);
        }
    }
}
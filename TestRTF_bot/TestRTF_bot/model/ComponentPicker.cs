using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.model.Components;
using TestRTF_bot.model.database;
using TestRTF_bot.Models;
using TestRTF_bot.Models.Accessories;

namespace TestRTF_bot.model
{
    class ComponentPicker
    {
        public DataBase Data { get; set; }

        public ComponentPicker(IEnumerable<Processor> processors,
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
            Data = DataBase.FromCollections(processors, motherboards, videoCards, rams, powerModules, processorCoolings, cases, storages, m2Collection, caseCoolings);
        }

        public ComponentPicker(DataBase data)
        {
            Data = data;
        }

        public ComponentPicker(ComponentsContext context)
        {
            Data = DataBase.FromContext(context);
        }

        public ComponentPicker(string pathToDataBase)
        {
            Data = DataBase.FromFile(pathToDataBase);
        }

        public ComponentPicker()
        {
            Data = DataBase.DefaultDataBase();
        }

        private const int processorDelta = 20;
        private const int motherboardDelta = 20;
        private const int videoCardDelta = 20;
        private const int ramDelta = 20;
        private const int powerModuleDelta = 20;
        private const int processorCoolingDelta = 20;
        private const int caseDelta = 20;
        private const int storageDelta = 20;
        private const int m2Delta = 20;
        private const int caseCoolingDelta = 0;

        public ConfigurationPC[] GetConfigurations(UserInformation userInformation)
        {
            var result = new SortedSet<ConfigurationPC>(new ConfigurationComparer());
            var processors = Data.Processors.GetRange(userInformation.MaxCost * (userInformation.Target.ProcessorPercent - processorDelta) / 100, userInformation.MaxCost * (userInformation.Target.ProcessorPercent + processorDelta) / 100);
            foreach (var processor in processors)
            {
                var costWithoutProcessor = userInformation.MaxCost - processor.Cost;
                var motherboards = Data.Motherboards
                    .GetRange(costWithoutProcessor * (userInformation.Target.MotherboardPercent - motherboardDelta) / 100, costWithoutProcessor * (userInformation.Target.MotherboardPercent + motherboardDelta) / 100)
                    .Where(mb => mb.IsCompatible(processor));
                foreach (var motherboard in motherboards)
                {
                    var costWithoutMotherboard = costWithoutProcessor - motherboard.Cost;
                    var videocards = Data.VideoCards
                        .GetRange(costWithoutMotherboard * (userInformation.Target.VideoCardPercent - videoCardDelta) / 100, costWithoutMotherboard * (userInformation.Target.VideoCardPercent + videoCardDelta) / 100)
                        .Where(vc => vc.IsCompatible(motherboard));
                    foreach (var videocard in videocards)
                    {
                        var costWithoutVideoCard = costWithoutMotherboard - videocard.Cost;
                        var rams = Data.RAMs
                            .GetRange(costWithoutVideoCard * (userInformation.Target.RAMPercent - ramDelta) / 100, costWithoutVideoCard * (userInformation.Target.RAMPercent + ramDelta) / 100)
                            .Where(r => r.IsCompatible(motherboard));
                        foreach (var ram in rams)
                        {
                            var costWithoutRAM = costWithoutVideoCard - ram.Cost;
                            var powerModules = Data.PowerModules
                                .GetRange(costWithoutRAM * (userInformation.Target.PowerModulePercent - powerModuleDelta) / 100, costWithoutRAM * (userInformation.Target.PowerModulePercent + powerModuleDelta) / 100)
                                .Where(pm => pm.IsCompatible(motherboard));
                            foreach (var powerModule in powerModules)
                            {
                                var costWithoutPowerModule = costWithoutRAM - powerModule.Cost;
                                var processorCoolings = Data.ProcessorCoolings
                                    .GetRange(costWithoutPowerModule * (userInformation.Target.ProcessorCoolingPercent - processorCoolingDelta) / 100, costWithoutPowerModule * (userInformation.Target.ProcessorCoolingPercent + processorCoolingDelta) / 100)
                                    .Where(c => c.IsCompatible(powerModule)
                                             && c.IsCompatible(motherboard)
                                             && c.IsCompatible(processor));
                                foreach (var processorCooling in processorCoolings)
                                {
                                    var costWithoutCooling = costWithoutPowerModule - processorCooling.Cost;
                                    var cases = Data.Cases
                                        .GetRange(costWithoutCooling * (userInformation.Target.CasePercent - caseDelta) / 100, costWithoutCooling * (userInformation.Target.CasePercent + caseDelta) / 100)
                                        .Where(c => c.IsCompatible(videocard)
                                                 && c.IsCompatible(motherboard)
                                                 && c.IsCompatible(processorCooling));
                                    foreach (var body in cases)
                                    {
                                        var costWithoutCase = costWithoutCooling - body.Cost;
                                        var storages = Data.Storages
                                            .GetRange(costWithoutCase * (userInformation.Target.StoragePercent - storageDelta) / 100, costWithoutCase * (userInformation.Target.StoragePercent + storageDelta) / 100)
                                            .Where(s => s.IsCompatible(motherboard));
                                        foreach (var storage in storages)
                                        {
                                            var costWithoutStorage = costWithoutCase - storage.Cost;
                                            var M2collection = Data.M2Collection
                                                .GetRange(costWithoutStorage * (userInformation.Target.M2Percent - m2Delta) / 100, costWithoutStorage * (userInformation.Target.M2Percent + m2Delta) / 100)
                                                .Where(m2 => m2.IsCompatible(motherboard));
                                            foreach (var m2 in M2collection)
                                            {
                                                var costWithoutM2 = costWithoutStorage - m2.Cost;
                                                var caseCoolings = Data.CaseCoolings
                                                    .GetRange(costWithoutM2 * (userInformation.Target.CaseCoolingPercent - caseCoolingDelta) / 100, costWithoutM2 * (userInformation.Target.CaseCoolingPercent + caseCoolingDelta) / 100)
                                                    .Where(cc => cc.IsCompatible(body));
                                                foreach (var caseCooling in caseCoolings)
                                                {
                                                    var confifurationPC = new ConfigurationPC(userInformation, processor, motherboard, videocard, ram, powerModule, processorCooling, body, storage, m2, caseCooling);
                                                    var cost = confifurationPC.Cost;
                                                    if (cost >= userInformation.MinCost && cost <= userInformation.MaxCost)
                                                        result.Add(confifurationPC);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result.Take(5).ToArray();
        }

        class ConfigurationComparer : IComparer<ConfigurationPC>
        {
            public int Compare(ConfigurationPC x, ConfigurationPC y)
            {
                return -x.Rating.CompareTo(y.Rating);
            }
        }
    }
}

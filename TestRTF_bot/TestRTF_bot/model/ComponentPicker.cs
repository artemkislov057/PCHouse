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

        //private const int processorDelta = 10;
        //private const int motherboardDelta = 20;
        //private const int videoCardDelta = 20;
        //private const int ramDelta = 30;
        //private const int powerModuleDelta = 10;
        //private const int processorCoolingDelta = 30;
        //private const int caseDelta = 20;
        //private const int storageDelta = 20;
        //private const int m2Delta = 10;
        //private const int caseCoolingDelta = 30;

        public IEnumerable<ConfigurationPC> GetConfigurations(UserInformation userInformation)
        {
            var result = new SortedSet<ConfigurationPC>(new ConfigurationComparer());
            var target = userInformation.TargetInterface;
            var cost = (userInformation.MinCost + userInformation.MaxCost) / 2;
            var processors = Data.Processors.GetRangeIndex(cost, 5, target.ProcessorPercent);
            foreach (var processor in processors)
            {
                var costWithoutProcessor = userInformation.MaxCost - processor.Cost;
                var motherboards = Data.Motherboards
                    .GetRangeIndex(costWithoutProcessor, 3, target.MotherboardPercent)
                    .Where(mb => mb.IsCompatible(processor));
                foreach (var motherboard in motherboards)
                {
                    var costWithoutMotherboard = costWithoutProcessor - motherboard.Cost;
                    var videocards = Data.VideoCards
                        .GetRangeIndex(costWithoutMotherboard, 3, target.VideoCardPercent)
                        .Where(vc => vc.IsCompatible(motherboard));
                    foreach (var videocard in videocards)
                    {
                        var costWithoutVideoCard = costWithoutMotherboard - videocard.Cost;
                        var rams = Data.RAMs
                            .GetRangeIndex(costWithoutVideoCard, 3, target.RAMPercent)
                            .Where(r => r.IsCompatible(motherboard));
                        foreach (var ram in rams)
                        {
                            var costWithoutRAM = costWithoutVideoCard - ram.Cost;
                            var powerModules = Data.PowerModules
                                .GetRangeIndex(costWithoutRAM, 3, target.PowerModulePercent)
                                .Where(pm => pm.IsCompatible(motherboard));
                            foreach (var powerModule in powerModules)
                            {
                                var costWithoutPowerModule = costWithoutRAM - powerModule.Cost;
                                var processorCoolings = Data.ProcessorCoolings
                                    .GetRangeIndex(costWithoutPowerModule, 3, target.ProcessorCoolingPercent)
                                    .Where(c => c.IsCompatible(powerModule)
                                             && c.IsCompatible(motherboard)
                                             && c.IsCompatible(processor));
                                foreach (var processorCooling in processorCoolings)
                                {
                                    var costWithoutCooling = costWithoutPowerModule - processorCooling.Cost;
                                    var cases = Data.Cases
                                        .GetRangeIndex(costWithoutCooling, 3, target.CasePercent)
                                        .Where(c => c.IsCompatible(videocard)
                                                 && c.IsCompatible(motherboard)
                                                 && c.IsCompatible(processorCooling));
                                    foreach (var body in cases)
                                    {
                                        var costWithoutCase = costWithoutCooling - body.Cost;
                                        var storages = Data.Storages
                                            .GetRangeIndex(costWithoutCase, 3, target.StoragePercent)
                                            .Where(s => s.IsCompatible(motherboard));
                                        foreach (var storage in storages)
                                        {
                                            var costWithoutStorage = costWithoutCase - storage.Cost;
                                            var M2collection = Data.M2Collection
                                                .GetRangeIndex(costWithoutStorage, 3, target.M2Percent)
                                                .Where(m2 => m2.IsCompatible(motherboard));
                                            foreach (var m2 in M2collection)
                                            {
                                                var costWithoutM2 = costWithoutStorage - m2.Cost;
                                                var caseCoolings = Data.CaseCoolings
                                                    .GetRangeIndex(costWithoutM2, 3, target.CaseCoolingPercent)
                                                    .Where(cc => cc.IsCompatible(body));
                                                foreach (var caseCooling in caseCoolings)
                                                {
                                                    var confifurationPC = new ConfigurationPC(userInformation, processor, motherboard, videocard, ram, powerModule, processorCooling, body, storage, m2, caseCooling);
                                                    if (confifurationPC.Cost >= userInformation.MinCost && confifurationPC.Cost <= userInformation.MaxCost)
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
            return result;
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

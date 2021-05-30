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

        public ConfigurationPC[] GetConfigurations(UserInformation userInformation)
        {
            var result = new List<ConfigurationPC>();
            var processors = Data.Processors.GetRange(10, 20);
            foreach (var processor in processors)
            {
                var motherboards = Data.Motherboards.GetRange(1, 9).Where(mb => mb.IsCompatible(processor));
                foreach (var motherboard in motherboards)
                {
                    var videocards = Data.VideoCards.GetRange(1, 10).Where(vc => vc.IsCompatible(motherboard));
                    foreach (var videocard in videocards)
                    {
                        var rams = Data.RAMs.GetRange(1, 10).Where(r => r.IsCompatible(motherboard));
                        foreach (var ram in rams)
                        {
                            var powerModules = Data.PowerModules.GetRange(1, 10).Where(pm => pm.IsCompatible(motherboard));
                            foreach (var powerModule in  powerModules)
                            {
                                var coolings = Data.ProcessorCoolings
                                    .GetRange(1, 10)
                                    .Where(c => c.IsCompatible(powerModule) 
                                             && c.IsCompatible(motherboard) 
                                             && c.IsCompatible(processor));
                                foreach (var cooling in coolings)
                                {
                                    var cases = Data.Cases
                                        .GetRange(1, 10)
                                        .Where(c => c.IsCompatible(videocard) 
                                                 && c.IsCompatible(motherboard) 
                                                 && c.IsCompatible(cooling));
                                    foreach (var body in cases)
                                    {
                                        var storages = Data.Storages
                                            .GetRange(1, 10)
                                            .Where(s => s.IsCompatible(motherboard));
                                        foreach (var storage in storages)
                                        {
                                            var M2collection = Data.M2Collection
                                                .GetRange(1, 10)
                                                .Where(m2 => m2.IsCompatible(motherboard));
                                            foreach (var m2 in M2collection)
                                            {
                                                var caseCoolings = Data.CaseCoolings
                                                    .GetRange(1, 10)
                                                    .Where(cc => cc.IsCompatible(body));
                                                foreach (var caseCooling in caseCoolings)
                                                {
                                                    var components = new IComponent[]
                                                    {
                                                        processor,
                                                        motherboard,
                                                        videocard,
                                                        ram,
                                                        powerModule,
                                                        cooling,
                                                        body,
                                                        storage,
                                                        m2,
                                                        caseCooling
                                                    };
                                                    var confifurationPC = new ConfigurationPC(components);
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
            return result.OrderByDescending(x => x.Rating).Take(5).ToArray();
        }

        
    }
}

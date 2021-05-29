using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.model.database;
using TestRTF_bot.Models;
using TestRTF_bot.Models.Accessories;

namespace TestRTF_bot.model
{
    class ComponentPicker
    {
        public DataBase Data { get; set; }

        public ComponentPicker()
        {
            Data = new DataBase();
        }

        public ConfigurationPC[] GetConfigurations(UserInformation userInformation)
        {
            var result = new List<ConfigurationPC>();
            var processors = Data.processors.GetRange(10, 20);
            foreach (var processor in processors)
            {
                var motherboards = Data.motherboards.GetRange(1, 9).Where(mb => mb.IsCompatible(processor));
                foreach (var motherboard in motherboards)
                {
                    var videocards = Data.videoCards.GetRange(1, 10).Where(vc => vc.IsCompatible(motherboard));
                    foreach (var videocard in videocards)
                    {
                        var rams = Data.rams.GetRange(1, 10).Where(r => r.IsCompatible(motherboard));
                        foreach (var ram in rams)
                        {
                            var powerModules = Data.powerModules.GetRange(1, 10).Where(pm => pm.IsCompatible(motherboard));
                            foreach (var powerModule in  powerModules)
                            {
                                var coolings = Data.coolings
                                    .GetRange(1, 10)
                                    .Where(c => c.IsCompatible(powerModule) 
                                             && c.IsCompatible(motherboard) 
                                             && c.IsCompatible(processor));
                                foreach (var cooling in coolings)
                                {
                                    var cases = Data.cases
                                        .GetRange(1, 10)
                                        .Where(c => c.IsCompatible(videocard) 
                                                 && c.IsCompatible(motherboard) 
                                                 && c.IsCompatible(cooling));
                                    foreach (var body in cases)
                                    {
                                        var storages = Data.storages
                                            .GetRange(1, 10)
                                            .Where(s => s.IsCompatible(motherboard));
                                        foreach (var storage in storages)
                                        {
                                            var M2collection = Data.M2collection
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

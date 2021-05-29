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
                                var coolings = Data.coolings.GetRange(1, 10).Where(c => c.IsCompatible(powerModule) && c.IsCompatible(motherboard));
                                //foreach ()
                                //{
                                //    foreach ()
                                //    {
                                //        foreach ()
                                //        {
                                //            foreach ()
                                //            {
                                //                foreach ()
                                //                {

                                //                }
                                //            }
                                //        }
                                //    }
                                //}
                            }
                        }
                    }
                }
            }



            throw new NotImplementedException();
        }

        
    }
}

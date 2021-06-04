using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.model;
using TestRTF_bot.Models;
using TestRTF_bot.Models.Accessories;

namespace TestRTF_bot.tests
{

    class Picker_Tests
    {
        private static ComponentPicker picker = new ComponentPicker();

        [Test]
        public void PickerTest()
        {
            var minCost = 20000;
            var delta = 20000;
            var step = 10000;
            var targets = new ITarget[]
            {
                new OfficeTarget(),
                new GameTarget(),
                new ProgrammingTarget(),
                new VideoEditingTarget()
            };
            foreach (var target in targets)
            {
                for (; minCost + delta < 120000; minCost += step)
                {
                    var result = picker.GetConfigurations(new UserInformation(minCost, minCost + delta, target));
                    Assert.IsTrue(result.Length > 0, $"\tMinCost = {minCost}\n\tMaxCost = {minCost + delta}\n\tTarget = \"{target.GetType().Name}\"");
                }
            }
        }
    }
}

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
        [Test]
        public void Test1()
        {
            var picker = new ComponentPicker();
            var user = new UserInformation(0, 100000, new ProgrammingTarget());
            var result = picker.GetConfigurations(user);
        }

        [Test]
        public void Test2()
        {
            var db = DataBase.DefaultDataBase();
            var list = new List<Tuple<Case, Motherboard>>();
            foreach (var first in db.Cases)
            {
                foreach (var second in db.Motherboards)
                {
                    if (first.IsCompatible(second))
                    {
                        list.Add(Tuple.Create(first, second));
                    }
                }
            }

        }
    }
}

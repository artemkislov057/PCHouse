using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseComponentFiller.Model.DataBase
{
    public class TableAttribute : Attribute
    {
        public TableAttribute(string name)
        {
            Name = name;
        }

        public readonly string Name;
    }
}

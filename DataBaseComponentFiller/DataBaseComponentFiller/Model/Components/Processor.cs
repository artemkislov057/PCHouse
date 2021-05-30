using DataBaseComponentFiller.Model.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseComponentFiller.Model.Components
{
    class Processor : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string Socket { get; set; }
        public double RamFrequency { get; set; }
        public int EnergyConsumption { get; set; }

        public bool IsCompatible(IComponent otherComponent)
        {
            throw new NotImplementedException();
        }
    }
}

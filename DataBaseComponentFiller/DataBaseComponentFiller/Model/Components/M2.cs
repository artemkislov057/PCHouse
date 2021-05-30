using DataBaseComponentFiller.Model.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseComponentFiller.Model.Components
{
    class M2 : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public int Length { get; set; }

        public bool IsCompatible(IComponent otherComponent)
        {
            throw new NotImplementedException();
        }
    }
}

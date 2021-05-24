using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class Motherboard : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string Socket { get; set; }
        public string RAM { get; set; }
        public int RAMFrequency { get; set; }
        public string RAMTimings { get; set; }
        public string ARRAY_ProcessorCoolings { get; set; }
        public string ARRAY_CaseCoolings { get; set; }
        public int SataInterfaceCount { get; set; }
        public int M2Length { get; set; }
    }
}

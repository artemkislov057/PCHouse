using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model.database
{
    class Configuration
    {
        [Key]
        public int Id { get; set; }

        public string Processor { get; set; }
        public string Motherboard { get; set; }
        public string Videocard { get; set; }
        public string RAM { get; set; }
        public string HDD { get; set; }
        public string SSD { get; set; }
        public string Cooling { get; set; }
        public string PowerModule { get; set; }
        public string Case { get; set; }
        public string Target { get; set; }
        public string Budget { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (!string.IsNullOrEmpty(Processor))
            {
                result.Append("Процессор: ");
                result.Append(Processor);
                result.Append('\n');
            }
            if (!string.IsNullOrEmpty(Motherboard))
            {
                result.Append("Материнская плата: ");
                result.Append(Motherboard);
                result.Append('\n');
            }
            if (!string.IsNullOrEmpty(Videocard))
            {
                result.Append("Видеокарта: ");
                result.Append(Videocard);
                result.Append('\n');
            }
            if (!string.IsNullOrEmpty(RAM))
            {
                result.Append("Оперативная память: ");
                result.Append(RAM);
                result.Append('\n');
            }
            if (!string.IsNullOrEmpty(HDD))
            {
                result.Append("HDD: ");
                result.Append(HDD);
                result.Append('\n');
            }
            if (!string.IsNullOrEmpty(SSD))
            {
                result.Append("SSD: ");
                result.Append(SSD);
                result.Append('\n');
            }
            if (!string.IsNullOrEmpty(Cooling))
            {
                result.Append("Охлаждение: ");
                result.Append(Cooling);
                result.Append('\n');
            }
            if (!string.IsNullOrEmpty(PowerModule))
            {
                result.Append("Блок питания: ");
                result.Append(PowerModule);
                result.Append('\n');
            }
            if (!string.IsNullOrEmpty(Case))
            {
                result.Append("Корпус: ");
                result.Append(Case);
                result.Append('\n');
            }
            if (result.Length > 0)
                result.Remove(result.Length - 1, 1);
            return result.ToString();
            //return $"Процессор: {this.Processor}\n" +
            //    $"Материнская плата: {this.Motherboard}\n" +
            //    $"Видеокарта: {this.Videocard}\n" +
            //    $"RAM: {this.RAM}\n" +
            //    $"HDD: {this.HDD}\n" +
            //    $"SSD: {this.SSD}\n" +
            //    $"Охлаждение: {this.Cooling}\n" +
            //    $"Блок питания: {this.PowerModule}\n" +
            //    $"Корпус: {this.Case}";
        }
    }
}

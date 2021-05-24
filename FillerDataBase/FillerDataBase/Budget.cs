using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillerDataBase
{
    class Budget
    {
        [Key]
        public int Id { get; set; }
        public string Range { get; set; }
    }
}

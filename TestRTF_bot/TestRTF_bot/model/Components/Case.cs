﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Models.Accessories
{
    class Case : IComponent
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
    }
}

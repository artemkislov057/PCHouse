using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.model
{
    public static class Extensions
    {
        public static string[] GetArray(this string line)
        {
            return line.Split(", ");
        }
    }
}

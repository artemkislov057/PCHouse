using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseComponentFiller.Model.DataBase
{
    public static class Extensions
    {
        public static string GetCharacteristics(this IComponent component)
        {
            var result = new StringBuilder();
            foreach (var property in component.GetType().GetProperties())
            {
                result.Append(property.Name);
                result.Append(": ");
                result.Append(property.GetValue(component));
                result.Append('\n');
            }
            return result.ToString();
        }
    }
}

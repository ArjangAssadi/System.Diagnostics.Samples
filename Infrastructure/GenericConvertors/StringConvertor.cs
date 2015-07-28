using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Infrastructure.GenericConvertors
{
    public class StringConvertor
    {
        public string EnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public string Delimeted(IEnumerable<string> values , string delimeter)
        {
            if (values == null) return String.Empty;
            if (values.Count() == 0 ) return String.Empty;
            
            return values.Aggregate((m, n) => m + delimeter + n);
        }

    }
}

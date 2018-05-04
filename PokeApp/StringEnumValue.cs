using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp
{
    public class StringEnumValue : System.Attribute
    {
        private readonly string _value;

        public StringEnumValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}

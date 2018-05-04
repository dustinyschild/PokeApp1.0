using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp
{
    public class Action
    {
        public ActionType Type { get; set; }
        public int Value { get; set; }

        public Action(ActionType type, int value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}

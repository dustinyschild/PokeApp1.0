using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp
{
    class Pokemon
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Types[] Types { get; set; }
        public int Base_Experience { get; set; }
        public Moves[] Moves { get; set; }

        public Pokemon(string id, string name, int level, int hp, Moves[] moves)
        {
            this.Id = id;
            this.Name = name;
            this.Level = level;
        }
    }
}

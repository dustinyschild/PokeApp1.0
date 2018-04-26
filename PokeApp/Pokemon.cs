using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp
{
    class Pokemon
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Speed { get; set; }
        public Type[] Types { get; set; }
        public Move[] Moves { get; set; }

        public Pokemon(
            int id,
            string name,
            int level,
            int hp,
            int speed,
            Move[] moves,
            Type[] types
        )
        {
            this.Id = id;
            this.Name = name;
            this.Nickname = name;
            this.Level = level;
            this.Hp = hp;
            this.Speed = speed;
            this.Moves = moves;
            this.Types = types;
        }

        public void ChangeNickname(string nickname)
        {
            this.Nickname = nickname;
        }

        public void LogAllStats()
        {
            // Pokemon
            Console.WriteLine("Stats for {0}", Nickname);
            Console.WriteLine("Id: {0}", Id);
            Console.WriteLine("Species: {0}", Name);
            Console.WriteLine("Level: {0}", Level);
            Console.WriteLine("Hit Points: {0}", Hp);
            Console.WriteLine("Speed: {0}", Speed);
            Console.WriteLine("Moves:");
            // Moves TODO: refactor to method
            foreach (Move Move in Moves)
            {
                Console.WriteLine($"    {Move.Name}");
            }
            Console.WriteLine("Types:");
            foreach (Type Type in Types)
            {
                Console.WriteLine($"    {Type.Name}");
            }
        }
    }
}

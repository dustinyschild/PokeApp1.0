
using System;

namespace PokeApp
{
    class Trainer
    {
        public string Name { get; set; }
        public Pokemon[] Pokemon { get; set; }

        public Trainer(string name, Pokemon[] pokemon)
        {
            this.Name = name;
            this.Pokemon = pokemon;
        }

        public void ChangeTrainerName(string newName)
        {
            this.Name = newName;
            Console.WriteLine($"Name changed to {this.Name}");
        }

        public void ListAllPokemon()
        {
            Console.WriteLine("Pokemon:");
            foreach (Pokemon Pokemon in this.Pokemon)
            {
                Console.WriteLine($"  {Pokemon.Nickname}");
            }
        }
    }
}
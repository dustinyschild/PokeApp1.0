using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp
{
    class Program
    {
        static Program()
        {

        }
        static void Main(string[] args)
        {
            Pokemon[] Pokemons = {
                new Pokemon(1, "Bulbasaur", 1, 30),
                new Pokemon(4, "Charmander", 1, 30),
                new Pokemon(7, "Squirtle", 1, 30)
            };

            foreach(Pokemon Pokemon in Pokemons)
            {
                Console.WriteLine("Name: {0}, Index No.: {1}", Pokemon.Name, Pokemon.Id);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}

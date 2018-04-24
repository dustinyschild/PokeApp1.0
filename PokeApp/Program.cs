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
        public enum Game
        {
            [StringEnumValue("no")]
            No = 0,
            [StringEnumValue("yes")]
            Yes = 1
        };

        static void Main(string[] args)
        {
            // initialize()
            Pokemon[] Pokemons = {
                new Pokemon(1, "Bulbasaur", 1, 30),
                new Pokemon(4, "Charmander", 1, 30),
                new Pokemon(7, "Squirtle", 1, 30)
            };

            // game setup
            string game = Prompt("Would you like to do battle?").ToLower();

            foreach (Pokemon Pokemon in Pokemons)
            {
                Console.WriteLine("Name: {0}, Index No.: {1}", Pokemon.Name, Pokemon.Id);
            }
            Prompt("Choose a pokemon from above that you would like to do battle with: ");


            // game start
            while (game == Game.Yes.ToString())
            {
                Write("Game loop");
                Console.ReadKey();
                game = Game.No.ToString();
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static void Write(string message)
        {
            Console.WriteLine(message);
        }

    }
}

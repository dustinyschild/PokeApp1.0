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
        private enum Game
        {
            [StringEnumValue("no")]
            No = 0,
            [StringEnumValue("yes")]
            Yes = 1
        };
        
        private static readonly Move[] Moves =
        {
            new Move("Bite"),
            new Move("Kick"),
            new Move("Punch"),
            new Move("Chop")
        };

        private static readonly Type[] Types =
        {
            new Type("grass")
        };

        private static readonly Pokemon[] Pokemons = {
            new Pokemon(1, "Bulbasaur", 1, 30, 10, Moves, Types),
            new Pokemon(4, "Charmander", 1, 30, 20, Moves, Types),
            new Pokemon(7, "Squirtle", 1, 30, 30, Moves, Types)
        };

        static void Main(string[] args)
        {
            // game setup
            var game = Prompt("Would you like to do battle?").ToLower();
            while (game == Game.Yes.ToString().ToLower())
            {
                foreach (Pokemon Pokemon in Pokemons)
                {
                    Pokemon.LogAllStats();
                }
                Prompt("Choose a pokemon from above that you would like to do battle with: ");

                // game start
                Write("Game loop");
                game = Game.No.ToString().ToLower();
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        private static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private static void Write(string message)
        {
            Console.WriteLine(message);
        }

    }
}

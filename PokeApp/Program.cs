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

        static Random random = new Random();

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

        private static Trainer Player = new Trainer("Player", Pokemons);
        private static Trainer Opponent = new Trainer("Stormy Daniels", Pokemons);

        static void Main(string[] args)
        {
            // game setup
            var game = Prompt("Would you like to do battle?").ToLower();
            while (game == Game.Yes.ToString().ToLower())
            {
                var playerName = Prompt("What is your name?");
                if (playerName != "")
                {
                    Player.ChangeTrainerName(playerName);
                }

                Player.ListAllPokemon();

                var playerPokemonChoice = Prompt("Choose a pokemon from above that you would like to do battle with: ");
                Pokemon playerPokemon = Player.Pokemon.FirstOrDefault(Pokemon => String.Equals(Pokemon.Name, playerPokemonChoice, StringComparison.CurrentCultureIgnoreCase));

                while (playerPokemon == null)
                {
                    playerPokemonChoice = Prompt("Invalid input, please try again:");
                    playerPokemon = Player.Pokemon.FirstOrDefault(Pokemon => String.Equals(Pokemon.Name, playerPokemonChoice, StringComparison.CurrentCultureIgnoreCase));
                }

                Pokemon opponentPokemon = GenerateRandomPokemon(Opponent);
                Write(opponentPokemon.Name);

                // game start
                if (playerPokemon.Speed > opponentPokemon.Speed)
                {
                    Write($"{opponentPokemon.Name} will go first.");
                    Move opponentMove = GenerateRandomMove(opponentPokemon.Moves);
                }
                else
                {
                    Write($"{playerPokemon.Name} will go first.");
                    foreach (Move Move in playerPokemon.Moves)
                    {
                        Write(Move.Name);
                    }

                    var playerMoveChoice = Prompt("What move would you like to use?");
                    Move playerMove = playerPokemon.Moves.FirstOrDefault(move => String.Equals(move.Name, playerMoveChoice, StringComparison.CurrentCultureIgnoreCase));

                    while (playerMove == null)
                    {
                        playerMoveChoice = Prompt("Invalid input, please try again:");
                        playerMove = playerPokemon.Moves.FirstOrDefault(move => String.Equals(move.Name, playerMoveChoice, StringComparison.CurrentCultureIgnoreCase));
                    }

                    Write(playerMove.Name);
                }

                game = Game.No.ToString().ToLower();
            }
            
            Console.WriteLine("Thanks for playing!");
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

        //Opponent Generators
        private static Pokemon GenerateRandomPokemon(Trainer trainer)
        {
            var index = random.Next(trainer.Pokemon.Length);
            return trainer.Pokemon[index];
        }

        private static Move GenerateRandomMove(Move[] moves)
        {
            var index = random.Next(moves.Length);
            return moves[index];
        }

        private static void Turn(Pokemon pokemon)
        {

        }
    }
}

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
    public class Program
    {
        private enum Game
        {
            [StringEnumValue("no")] No = 0,
            [StringEnumValue("yes")] Yes = 1
        };

        private static Action DefaultAction = new Action(ActionType.Attack, 5);

        static Random random = new Random();

        private static readonly Move[] Moves =
        {
            new Move("Bite", DefaultAction),
            new Move("Kick", DefaultAction),
            new Move("Punch", DefaultAction),
            new Move("Chop", DefaultAction)
        };

        private static readonly Pokemon[] Pokemons =
        {
            new Pokemon(1, "Bulbasaur", 1, 30, 10, Moves, new Element[] {Element.Grass}),
            new Pokemon(4, "Charmander", 1, 30, 20, Moves, new Element[] {Element.Fire}),
            new Pokemon(7, "Squirtle", 1, 30, 30, Moves, new Element[] {Element.Water})
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

                Console.WriteLine("Your choices:");
                Player.ListAllPokemon();

                Pokemon playerPokemon = null;

                string playerPokemonChoice = Prompt("Please choose a Pokemon:");
                while (playerPokemon == null)
                {
                    playerPokemon = Player.Pokemon.FirstOrDefault(Pokemon =>
                        String.Equals(Pokemon.Name, playerPokemonChoice, StringComparison.CurrentCultureIgnoreCase));
                    if (playerPokemon == null)
                        playerPokemonChoice = Prompt("Invalid input, please try again:");
                }

                Pokemon opponentPokemon = GenerateRandomPokemon(Opponent);

                if (playerPokemon.Speed > opponentPokemon.Speed)
                {
                    Round(playerPokemon, opponentPokemon);
                }
                else
                {
                    Round(opponentPokemon,playerPokemon);
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

        private static void Pause()
        {
            Console.ReadKey(true);
        }

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

        private static void Turn(Pokemon initiator, Pokemon receiver, Move move)
        {
            Write($"{initiator.Name} uses {move.Name}!");
            move.ApplyAction(receiver);
        }

        private static void Round(Pokemon player, Pokemon opponent)
        {
            //generate opponent move
            Move opponentMove = GenerateRandomMove(opponent.Moves);

            //clear player move and prompt user
            foreach (Move Move in player.Moves)
                Write(Move.Name);

            Move playerMove = null;
            string playerMoveChoice = Prompt("What move would you like to use?:");
            while (playerMove == null)
            {
                playerMove = player.Moves.FirstOrDefault(move =>
                    String.Equals(move.Name, playerMoveChoice, StringComparison.CurrentCultureIgnoreCase));
                if (playerMove == null)
                    playerMoveChoice = Prompt("Invalid input, please try again:");
            }

            //update user on selected moves
            Write($"You chose {playerMove.Name}!");
            Write($"{opponent.Name} chose {opponentMove.Name}");

            Write(player.Speed > opponent.Speed ? $"{player.Name} will go first." : $"{opponent.Name} will go first.");
            bool round = true;
            do
            {
                if (player.Speed > opponent.Speed)
                {
                    Turn(player, opponent, playerMove);
                    Write($"{player.Name} health: {player.Hp}");
                    Write($"{opponent.Name} health: {opponent.Hp}");
                    round = CheckHealth(player, opponent);
                    Pause();
                    if (!round) break;

                    Turn(opponent, player, opponentMove);
                    Write($"{player.Name} health: {player.Hp}");
                    Write($"{opponent.Name} health: {opponent.Hp}");
                    round = CheckHealth(player, opponent);
                    Pause();
                }
                else
                {
                    Turn(opponent, player, opponentMove);
                    Write($"{player.Name} health: {player.Hp}");
                    Write($"{opponent.Name} health: {opponent.Hp}");
                    round = CheckHealth(player, opponent);
                    Pause();
                    if (!round) break;

                    Turn(player, opponent, playerMove);
                    Write($"{player.Name} health: {player.Hp}");
                    Write($"{opponent.Name} health: {opponent.Hp}");
                    round = CheckHealth(player, opponent);
                    Pause();
                }
            } while (round);

            if (player.Hp > 0 && opponent.Hp <= 0)
                Write("You win!");
            else if (opponent.Hp > 0 && player.Hp <= 0)
                Write($"{opponent.Name} wins!");
            else Write("Winner is unclear, it's a draw!");
        }

        private static bool CheckHealth(Pokemon player, Pokemon opponent)
        {
            return !(player.Hp >= 0 && opponent.Hp <= 0 || opponent.Hp >= 0 && player.Hp <= 0);
        }
    }
}

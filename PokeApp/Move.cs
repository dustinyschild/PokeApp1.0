using System;
using PokeApp;

namespace PokeApp
{
    public class Move
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public Action Action { get; set; }

        public Move(string name, Action action)
        {
            this.Name = name;
            this.Nickname = name;
            this.Action = action;
        }

        public void ApplyAction(Pokemon receiver)
        {
            switch (Action.Type)
            {
                case ActionType.Attack:
                    receiver.Hp -= Action.Value;
                    break;
                case ActionType.Defense:
                    Console.WriteLine("Warning: Defensive moves are not yet implemented.");
                    break;
                case ActionType.Buff:
                    Console.WriteLine("Warning: Buffing moves are not yet implemented.");
                    break;
                case ActionType.Debuff:
                    Console.WriteLine("Warning: Debuffing moves are not yet implemented.");
                    break;
                default:
                    Console.WriteLine("Error: Move type invalid.");
                    break;
            }
        }
    }
}
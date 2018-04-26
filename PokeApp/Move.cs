namespace PokeApp
{
    public class Move
    {
        public string Name { get; set; }
        public string Nickname { get; set; }

        public Move(string name)
        {
            this.Name = name;
            this.Nickname = name;
            // not yet implemented:
            // this.ActionType = action
            // this.ElementalType = element
            //
        }
    }
}
namespace XO
{
    internal class Player
    {
        public string Name { get; }
        public char Marker { get; }

        public Player(string name, char marker)
        {
            Name = name;
            Marker = marker;
        }
    }
}
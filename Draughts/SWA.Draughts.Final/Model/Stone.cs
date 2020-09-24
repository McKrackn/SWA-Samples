namespace SWA.Draughts.Final.Model
{
    public class Stone
    {
        public StoneColors Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsQueen { get; set; } = false;
        public bool IsDead { get; set; } = false;

        public Stone(int x, int y, StoneColors color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }
    }
}
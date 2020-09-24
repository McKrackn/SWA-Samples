namespace SWA.Draughts.Final.Input
{
    public class DraughtsInputKickRequest : DraughtsInput
    {
        public int X { get; }
        public int Y { get; }

        public DraughtsInputKickRequest(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

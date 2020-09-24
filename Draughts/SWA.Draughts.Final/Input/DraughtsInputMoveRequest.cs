namespace SWA.Draughts.Final.Input
{
    public class DraughtsInputMoveRequest : DraughtsInput
    {
        public int FromX { get; set; }
        public int FromY { get; set; }
        public int ToX { get; set; }
        public int ToY { get; set; }
    }
}

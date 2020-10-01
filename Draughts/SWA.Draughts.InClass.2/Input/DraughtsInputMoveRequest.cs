namespace SWA.Draughts.Final.Input
{
    public class DraughtsInputMoveRequest : DraughtsInput, IRequestHasPositionInformation
    {
        public int ToX { get; set; }
        public int ToY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override string PrintMyMove()
        {
            return $"{X}/{Y} -> {ToX}/{ToY}";
        }

        public string PrintMyMove(int x)
        {
            return "ok";
        }
    }
}

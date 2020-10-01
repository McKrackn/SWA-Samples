namespace SWA.Draughts.Final.Input
{
    public abstract class DraughtsInput
    {
        protected const string NoMoveText = "no move";

        public virtual string PrintMyMove()
        {
            return NoMoveText;
        }

        public string PrintMyMove(int deltaX, int deltaY)
        {
            return NoMoveText;
        }
    }
}

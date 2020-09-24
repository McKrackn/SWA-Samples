using SWA.Draughts.Final.Input;

namespace SWA.Draughts.Final
{
    class Program
    {
        private static InputReader _reader = new InputReader();
        private static Board _board = new Board();
        static void Main(string[] args)
        {
            _board.Draw();
            DraughtsInput input = null;
            while (!((input = _reader.Read()) is DraughtsInputQuitRequest))
            {
                _board.ExecuteRequest(input);
                _board.Draw();
            }
        }
    }
}

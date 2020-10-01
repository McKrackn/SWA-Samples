using System;
using SWA.Draughts.Final.Input;

namespace SWA.Draughts.Final
{
    class Program
    {
        private static InputReader _reader = new InputReader();
        private static Board _board;
        static void Main(string[] args)
        {
            _board = new Board();

            DraughtsInput input = null;
            _board.BoardHasChanged += BoardOnBoardHasChanged;
            
            _board.Draw();
            while (!((input = _reader.Read()) is DraughtsInputQuitRequest))
            {
                _board.ExecuteRequest(input);
            }

            _board.Dispose();
            _board = null;
        }

        private static void BoardOnBoardHasChanged(object? sender, EventArgs e)
        {
            _board.Draw();
        }
    }
}

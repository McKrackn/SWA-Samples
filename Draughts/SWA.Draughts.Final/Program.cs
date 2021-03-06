﻿using System;
using SWA.Draughts.Final.Input;

namespace SWA.Draughts.Final
{
    class Program
    {
        private static InputReader _reader = new InputReader();
        public static Board Board { get; set; }
        static void Main(string[] args)
        {
            Board = new Board();

            DraughtsInput input = null;
            Board.BoardHasChanged += BoardOnBoardHasChanged;
            
            Board.Draw();
            while (!((input = _reader.Read()) is DraughtsInputQuitRequest))
            {
                Board.ExecuteRequest(input);
            }

            Board.Dispose();
            Board = null;
        }

        private static void BoardOnBoardHasChanged(object sender, EventArgs e)
        {
            Board.Draw();
        }
    }
}

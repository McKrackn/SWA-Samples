using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Draughts
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
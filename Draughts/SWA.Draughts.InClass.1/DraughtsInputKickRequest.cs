using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Draughts
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

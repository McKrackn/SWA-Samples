using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Draughts.Final.Input
{
    public class DraughtsInputPromoteRequest : DraughtsInput, IRequestHasPositionInformation
    {
        public int X { get; }
        public int Y { get; }

        public DraughtsInputPromoteRequest(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

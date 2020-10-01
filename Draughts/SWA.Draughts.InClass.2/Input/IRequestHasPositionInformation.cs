using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Draughts.Final.Input
{
    public interface IRequestHasPositionInformation
    {
        public int X { get; }
        public int Y { get; }
    }
}

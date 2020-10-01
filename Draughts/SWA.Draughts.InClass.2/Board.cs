using System;
using System.Collections.Generic;
using SWA.Draughts.Final.Input;
using SWA.Draughts.Final.Model;

namespace SWA.Draughts.Final
{
    public class Board : IDisposable
    {
        // private Stone[] _stones = new Stone[24];
        private List<Stone> _stones = new List<Stone>();

        public event EventHandler<EventArgs> BoardHasChanged;

        public Board()
        {
            for (int i = 0; i < 24; i++)
            {
                int x = (i % 4) * 2 + ((i / 4) % 2);
                int y = i / 4;
                StoneColors color = StoneColors.White;
                if (i >= 12)
                {
                    y += 2;
                    color = StoneColors.Black;
                }

                _stones.Add(new Stone(x, y, color));
            }
        }

        private Stone FindStone(int x, int y)
        {
            foreach (var stone in _stones)
            {
                if (stone.X == x && stone.Y == y)
                {
                    return stone;
                }
            }

            return null;
        }

        public void Draw()
        {
            Console.Clear();
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Console.BackgroundColor = (((x + y) % 2) == 0) ? ConsoleColor.DarkGray : ConsoleColor.Black;
                    Stone stone = FindStone(x, y);
                    if (stone == null || stone.IsDead)
                    {
                        bool isBlack = ((x + y) % 2 == 0);
                        // Console.Write(isBlack ? " x " : "   ");
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.Write(stone.Color == StoneColors.Black ? " B" : " W");
                        Console.Write(stone.IsQueen ? "Q" : " ");
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void ExecuteRequest(DraughtsInput input)
        {
            Stone stone = null;
            if (input is IRequestHasPositionInformation)
            {
                IRequestHasPositionInformation infoStone = (IRequestHasPositionInformation)input;
                stone = FindStone(infoStone.X, infoStone.Y);
                if (stone == null)
                {
                    return;
                }

                if (BoardHasChanged != null)
                {
                    BoardHasChanged.Invoke(this, EventArgs.Empty);
                }
            }

            if (input is DraughtsInputKickRequest)
            {
                stone.IsDead = true;
                stone.X = -1;
                stone.Y = -1; // so that FindStone is not in trouble about 2 stones on a field

                if (BoardHasChanged != null)
                {
                    BoardHasChanged.Invoke(this, EventArgs.Empty);
                }

            }
            else if (input is DraughtsInputMoveRequest)
            {
                DraughtsInputMoveRequest mv = (DraughtsInputMoveRequest)input;

                stone.X = mv.ToX;
                stone.Y = mv.ToY;

                if (BoardHasChanged != null)
                {
                    BoardHasChanged.Invoke(this, EventArgs.Empty);
                }

            }
            else if (input is DraughtsInputPromoteRequest)
            {
                stone.IsQueen = true;

                if (BoardHasChanged != null)
                {
                    BoardHasChanged.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Game over");
        }
    }
}
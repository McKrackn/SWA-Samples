using System;
using SWA.Draughts.Final.Input;
using SWA.Draughts.Final.Model;

namespace SWA.Draughts.Final
{
    public class Board
    {
        private Stone[] _stones = new Stone[24];

        public Board()
        {
            for (int i = 0; i < _stones.Length; i++)
            {
                int x = (i % 4) * 2 + ((i / 4) % 2);
                int y = i / 4;
                StoneColors color = StoneColors.White;
                if (i >= 12)
                {
                    y += 2;
                    color = StoneColors.Black;
                }
                _stones[i] = new Stone(x, y, color);
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
                        Console.Write(stone.IsQueen ? "Q": " ");
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void ExecuteRequest(DraughtsInput input)
        {
            if (input is DraughtsInputKickRequest)
            {
                DraughtsInputKickRequest kr = (DraughtsInputKickRequest)input;
                var stone = FindStone(kr.X, kr.Y);
                if (stone != null)
                {
                    stone.IsDead = true;
                    stone.X = -1;
                    stone.Y = -1; // so that FindStone is not in trouble about 2 stones on a field
                }
            }
            else if (input is DraughtsInputMoveRequest)
            {
                DraughtsInputMoveRequest mv = (DraughtsInputMoveRequest)input;
                var stone = FindStone(mv.FromX, mv.FromY);
                if (stone != null)
                {
                    stone.X = mv.ToX;
                    stone.Y = mv.ToY;
                }
            } else if (input is DraughtsInputPromoteRequest)
            {
                DraughtsInputPromoteRequest pr = (DraughtsInputPromoteRequest)input;
                var stone = FindStone(pr.X, pr.Y);
                if (stone != null)
                {
                    stone.IsQueen = true;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Draughts
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
                    Stone stone = FindStone(x, y);
                    if (stone == null || stone.IsDead)
                    {
                        bool isBlack = ((x + y) % 2 == 0);
                        Console.Write(isBlack ? "x" : " ");
                    }
                    else
                    {
                        Console.Write(stone.Color == StoneColors.Black ? "B" : "W");
                    }
                }

                Console.WriteLine();
            }
        }

        public void ExecuteRequest(DraughtsInput input)
        {
            if (input is DraughtsInputKickRequest)
            {
                DraughtsInputKickRequest kr = (DraughtsInputKickRequest) input;
                var stone = FindStone(kr.X, kr.Y);
                if (stone != null)
                {
                    stone.IsDead = true;
                }
            }
        }
    }
}
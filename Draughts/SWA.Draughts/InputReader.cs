using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Draughts
{
    public class InputReader
    {
        private void ParsePosition(string text, out int x, out int y)
        {
            var parts = text.Split("/");
            x = int.Parse(parts[0]);
            y = int.Parse(parts[1]);
        }

        public DraughtsInput Read()
        {
            string rawInput = Console.ReadLine().Trim();
            if (rawInput == "quit")
            {
                return new DraughtsInputQuitRequest();
            }

            if (rawInput.StartsWith("kick "))
            {
                int x;
                int y;
                ParsePosition(rawInput.Substring(5), out x, out y);
                return new DraughtsInputKickRequest(x,y);
            }

            return new DraughtsInput();
        }
    }
}
using System;
using System.IO;
using System.Threading;

namespace SWA.Draughts.Final.Input
{
    public class InputReader
    {
        private DraughtsInput LastInput { get; set; } = null;

        private void ParsePosition(string text, out int x, out int y)
        {
            var parts = text.Split("/");
            if (parts.Length != 2)
            {
                throw new InvalidDataException("position format invalid");
            }

            x = int.Parse(parts[0].Trim());
            y = int.Parse(parts[1].Trim());
        }

        public DraughtsInput Read()
        {
            try
            {
                string rawInput = Console.ReadLine().Trim();
                while (string.IsNullOrWhiteSpace(rawInput))
                {
                    rawInput = Console.ReadLine().Trim();
                }

                Thread.Sleep(1000); // for debug purpose ... set this if you redirect stdin and want to see the moves

                if (rawInput == "quit")
                {
                    return (LastInput = new DraughtsInputQuitRequest());
                }

                if (rawInput.StartsWith("kick "))
                {
                    int x;
                    int y;
                    ParsePosition(rawInput.Substring(5), out x, out y);
                    return (LastInput = new DraughtsInputKickRequest(x, y));
                }

                if (rawInput.StartsWith("promote "))
                {
                    int x;
                    int y;
                    ParsePosition(rawInput.Substring(8), out x, out y);
                    return (LastInput = new DraughtsInputPromoteRequest(x, y));
                }

                if (rawInput.StartsWith("move "))
                {
                    int x;
                    int y;
                    int x2;
                    int y2;
                    
                    string[] positions = rawInput.Substring(5).Split("->", StringSplitOptions.None);
                    if (positions.Length != 2)
                    {
                        throw new InvalidDataException("movement format invalid");
                    }

                    ParsePosition(positions[0], out x, out y);
                    ParsePosition(positions[1], out x2, out y2);
                    return (LastInput = new DraughtsInputMoveRequest() {X = x, Y = y, ToX = x2, ToY = y2});
                }
            }
            catch
            {
                // ignore
            }

            return (LastInput = new DraughtsInputNoOperation());
        }
    }
}
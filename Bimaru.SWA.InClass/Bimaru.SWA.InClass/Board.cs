using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bimaru.SWA.InClass
{
    public class Board
    {
        public const int XDimension = 6;
        public const int YDimension = 6;
        public char[] Fields { get; } = new char[YDimension * XDimension];
        public char[] RowConstraints { get; } = new char[YDimension];
        public char[] ColumnConstraints { get; } = new char[XDimension];

        private List<int> _readonlyIndexes = new List<int>();

        public string AdditionalInformation { get; }

        public Board(string rawBoard)
        {
            StringReader reader = new StringReader(rawBoard);
            int mode = 0; // state-machine state

            string line;
            int y = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (mode == 0 && line.Trim() == "+------+")
                {
                    mode++;
                    continue;
                }

                if (mode == 1 && line[0] == '|' && line[7] == '|' && char.IsDigit(line[8]))
                {
                    for (int x = 0; x < XDimension; x++)
                    {
                        Fields[y * XDimension + x] = line[1 + x];
                        if (line[1 + x] == 'X' || line[1 + x] == 'O')
                        {
                            _readonlyIndexes.Add(y * XDimension + x);
                        }
                    }

                    RowConstraints[y] = line[8];

                    y++;
                    if (y == YDimension)
                    {
                        mode++;
                    }

                    continue;
                }

                if (mode == 2 && line.Trim() == "+------+")
                {
                    mode++;
                    continue;
                }

                if (mode == 3 && line[0] == ' ')
                {
                    for (int x = 0; x < XDimension; x++)
                    {
                        ColumnConstraints[x] = line[1 + x];
                    }

                    mode++;
                    continue;
                }

                if (mode == 4)
                {
                    this.AdditionalInformation = line;
                    mode++;
                    continue;
                }

                throw new InvalidDataException("mode and data incompatible: see line: " + line);
            }
        }


        public void Toggle(in int index)
        {
            if (!IsPreset(index))
            {
                switch (Fields[index])
                {
                    case ' ':
                        Fields[index] = 'O';
                        break;
                    case 'O':
                        Fields[index] = 'X';
                        break;
                    case 'X':
                        Fields[index] = ' ';
                        break;
                }
            }
        }

        public bool CheckSolved()
        {
            for (int y = 0; y < YDimension; y++)
            {
                int lineCount = 0;
                for (int x = 0; x < XDimension; x++)
                {
                    if (Fields[y * XDimension + x] == 'X')
                    {
                        lineCount++;
                    }
                }

                if (lineCount != (this.RowConstraints[y]-'0'))
                {
                    return false;
                }
            }

            for (int x = 0; x < XDimension; x++)
            {
                int rowCount = 0;
                for (int y = 0; y < YDimension; y++)
                {
                    if (Fields[y * XDimension + x] == 'X')
                    {
                        rowCount++;
                    }
                }

                if (rowCount != (this.ColumnConstraints[x]-'0'))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPreset(int index)
        {
            return _readonlyIndexes.Contains(index);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bimaru.SWA.InClass
{
    public class RawBoardProvider
    {
        public string GetBoardRaw()
        {
            return @"
+------+
|O    O|2
|      |1
|      |1
|  O   |3
|      |1
| X    |2
+------+
 212203
1x3, 2x2, 3x1
";
        }
    }
}

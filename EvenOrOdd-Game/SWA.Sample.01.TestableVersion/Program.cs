using System;
using System.Diagnostics;
using System.Linq;

namespace SWA.Sample._01.TestableVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            string mode = "interactive";
            if (args.Length > 0 && args[0] == "test")
            {
                mode = "test";
            }

            if (mode == "interactive")
            {
                GetInputs(out string name1, out string name2, out int number1, out int number2, out int selectedPlayerNr, out bool isEvenSelected);
                bool checkWon = HasWon(isEvenSelected, number1, number2);
                PrintWinner(checkWon, selectedPlayerNr == 1 ? name1 : name2, selectedPlayerNr != 1 ? name1 : name2, number1, number2);
            }
            else if (mode == "test")
            {
                // in case you know unit tests... make some unit tests out of these cases below
                Assert_CheckEquals(true, HasWon(true, 1, 1));
                Assert_CheckEquals(false, HasWon(true, 1, 2));
                Assert_CheckEquals(false, HasWon(false, 1, 1));
                Assert_CheckEquals(true, HasWon(false, 1, 2));
            }
        }

        static void GetInputs(out string name1, out string name2, out int number1, out int number2, out int selectedPlayerNr, out bool isEvenSelected)
        {
            Console.Write("Enter your name: ");
            name1 = Console.ReadLine();
            Console.Write("Enter your name: ");
            name2 = Console.ReadLine();

            Console.Write("Enter a number: ");
            Console.ForegroundColor = ConsoleColor.Black; // dirty
            number1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White; // dirty

            Console.Write("Enter a number: ");
            Console.ForegroundColor = ConsoleColor.Black;
            number2 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Random random = new Random(DateTime.Now.Millisecond);
            selectedPlayerNr = (random.Next(1000) % 2) + 1;

            string selectedPlayerName = selectedPlayerNr == 1 ? name1 : name2;
            Console.WriteLine($"Please {selectedPlayerName} enter 'even' or 'odd': ");
            string selectedWinCondition = Console.ReadLine();
            isEvenSelected = selectedWinCondition == "even";
        }

        static bool HasWon(bool isEvenSelected, int number1, int number2)
        {
            bool isEven = (number1 + number2) % 2 == 0;
            return isEvenSelected == isEven;
        }

        static void PrintWinner(bool selectedPlayerHasWon, string selectedPlayerName, string otherGuyPlayerName, int number1, int number2)
        {
            Console.WriteLine(selectedPlayerHasWon ? $"{selectedPlayerName} won" : $"{otherGuyPlayerName} won");
            Console.WriteLine("The 2 numbers are: {0}, {1}", number1, number2);
        }

       

        private static void Assert_CheckEquals(bool expectedValue, bool calculatedValue)
        {
            if (expectedValue != calculatedValue)
            {
                Console.Error.WriteLine("Error in a check");
                Debugger.Break();
            }
        }
    }
}

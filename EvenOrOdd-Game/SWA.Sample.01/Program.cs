using System;

namespace SWA.Sample._01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name1 = Console.ReadLine();
            Console.Write("Enter your name: ");
            var name2 = Console.ReadLine();

            Console.Write("Enter a number: ");
            Console.ForegroundColor = ConsoleColor.Black; // dirty
            int number1 =int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White; // dirty

            Console.Write("Enter a number: ");
            Console.ForegroundColor = ConsoleColor.Black;
            int number2 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Random random = new Random(DateTime.Now.Millisecond);
            int selectedPlayerNr = (random.Next(1000) % 2) + 1;

            /*string selectedPlayerName;
            if (selectedPlayerNr == 1)
            {
                selectedPlayerName = name1;
            }
            else
            {
                selectedPlayerName = name2;
            }*/

            string selectedPlayerName = selectedPlayerNr == 1
                ? name1
                : name2;
            string otherGuyPlayerName = selectedPlayerNr != 1
                ? name1
                : name2;

            Console.WriteLine($"Please {selectedPlayerName} enter 'even' or 'odd': ");
            string selectedWinCondition = Console.ReadLine();
            bool isEvenSelected = selectedWinCondition == "even";
            bool isEven = (number1 + number2) % 2 == 0;
            if (isEvenSelected == isEven)
            {
                Console.WriteLine($"{selectedPlayerName} won");
            }
            else
            {
                Console.WriteLine($"{otherGuyPlayerName} won");
            }

            Console.WriteLine("The 2 numbers are: {0}, {1}", number1, number2);
        }
    }
}

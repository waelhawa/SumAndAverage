using System;
using System.Collections.Generic;
using System.Text;

namespace SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            bool looper = true;                                         //A boolean to loop until user chooses otherwise
            int choice;                                                 //Choose between 1 (Ex37) or 2 (Ex38) or 3 to exit
            int numberOfEntries = 0;                                    //Expanded the program to allow for variable entries. (Enter 5 to match the exercises)
            double total;                                               //Holds the result
            StringBuilder text = new StringBuilder();                   //Used to build the final form of the result
            List<double> numbers = new List<double>();                  //Used a List to hold the numbers since variability is important
            while (looper)
            {
                numbers.Clear();
                text.Clear();
                total = 0;
                Console.WriteLine("Choose 1 or 2:\n1- Summation\n2- Average\n3- Exit");
                choice = IntegerEntry("Entry: ", "Invalid Entry.");
                if (choice <= 2)
                {
                    Console.WriteLine("How many numbers do you want to enter?");
                    numberOfEntries = IntegerEntry("Number of entries: ", "Invalid Entry or entry is zero.");
                    for (int i = 0; i < numberOfEntries; i++)
                    {
                        numbers.Add(DoubleEntry($"Enter number {i + 1}: ", "Invalid number"));
                    }
                }
                switch (choice)
                {
                    case 1:
                        foreach (double number in numbers)
                        {
                            text.Append($"{number} + ");
                            total = Summation(total, number);
                        }
                        Result(text, total, choice, numberOfEntries);
                        break;

                    case 2:
                        foreach (double number in numbers)
                        {
                            text.Append($"{number} + ");
                            total = Summation(total, number);
                        }
                        total = Average(total, numberOfEntries);
                        Result(text, total, choice, numberOfEntries);
                        break;

                    case 3:
                        looper = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid entry.\n");
                        break;
                }
                if (choice <= 2)
                {
                    looper = ContinueEntry("Would you like to continue (Y/N)? ", "Invalid Entry.");
                }
                if (!looper)
                {
                    Console.WriteLine("\n\nGoodBye!");
                }

            }

        } //end main

        public static double Summation(double total, double number)
        {
            return total + number;
        } //end Summation

        public static double Average(double total, int number)
        {
            return total / (double)number;
        } //end Average

        /* This method is used to build the final form and to write
           to console the corresponding answer based on each selection.*/
        public static void Result (StringBuilder text, double total, int choice, int numberOfEntries)
        {
            if (choice == 1)
            {
                text.Remove(text.Length - 2, 2).Append("= ");
            }
            else
            {
                text.Remove(text.Length - 3, 3).Insert(0, '(').Insert(text.Length, ')').Append($" / {numberOfEntries} = ");
            }
            Console.WriteLine("{0}{1}", text, total);  
        } //end Result

        /* This method is used only for the integer numbers above*/
        public static int IntegerEntry(string phrase, string error)
        {
            string text;
            int integerNumber;
            while (true)
            {
                Console.Write(phrase);
                text = Console.ReadLine().Trim().ToLower();
                if (int.TryParse(text, out integerNumber) && integerNumber > 0)
                {
                    return integerNumber;
                }
                else
                {
                    Console.WriteLine(error);
                }
            }
        } //end IntegerEntry

        /* This method will deal with calculation numbers.
         * The decision to make it double so to make calculation easier.*/
        public static double DoubleEntry(string phrase, string error)
        {
            string text;
            double doubleNumber;
            while (true)
            {
                Console.Write(phrase);
                text = Console.ReadLine().Trim().ToLower();
                if (double.TryParse(text, out doubleNumber))
                {
                    return doubleNumber;
                }
                else
                {
                    Console.WriteLine(error);
                }
            }
        } //end doubleEntry

        /* Below method is used to loop until the user chooses y/yes or n/no.
         * Prints an error otherwise.*/
        public static bool ContinueEntry(string phrase, string error)
        {
            string text;
            while (true)
            {
                Console.Write(phrase);
                text = Console.ReadLine().Trim().ToLower();

                switch (text)
                {
                    case "y":
                    case "yes":
                        return true;


                    case "n":
                    case "no":
                        return false;


                    default:
                        Console.WriteLine(error);
                        break;
                }
            }
        } //end ContinueEntry

    } //end class
} //end package

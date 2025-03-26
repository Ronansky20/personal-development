using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calculator\r");
            Console.WriteLine("------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                string? numInputFirstValue = "";
                string? numInputSecondValue = "";
                double result = 0;

                Console.WriteLine("Type a number");
                numInputFirstValue = Console.ReadLine();

                double cleanFirstValue = 0;
                while (!double.TryParse(numInputFirstValue, out cleanFirstValue))
                {
                    Console.WriteLine("This is not a valid input.");
                    numInputFirstValue = Console.ReadLine();
                }

                Console.WriteLine("Type another number");
                numInputSecondValue = Console.ReadLine();

                double cleanSecondValue = 0;
                while (!double.TryParse(numInputSecondValue, out cleanSecondValue))
                {
                    Console.WriteLine("This is not a valid input.");
                    numInputSecondValue = Console.ReadLine();
                }

                Console.WriteLine("Choose an option");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Choice? ");

                string? op = Console.ReadLine();

                if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                {
                    Console.WriteLine("error: unrecognized input");
                }
                else
                {
                    try
                    {
                        result = calculator.DoOperation(cleanFirstValue, cleanSecondValue, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This result is mathematically impossible. \n");
                        }
                        else
                        {
                            Console.WriteLine("Your result: {0:0.##}\n", result);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                Console.WriteLine("------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
        }
    }
}
using Katas.InterviewQuestions;
using System;

namespace Katas
{
    public class KatasProgram
    {
        static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("Please select a kata to run:");
                Console.WriteLine("1 - An Even Spin on Fibonacci");
                Console.WriteLine("2 - Classic FizzBuzz");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        int upperLimit;
                        while (true)
                        {
                            Console.WriteLine("Please enter an int for upper limit:");
                            string upperLimitInput = Console.ReadLine();

                            if (int.TryParse(upperLimitInput, out upperLimit))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                            }
                        }

                        int method;
                        bool isValidMethod = false;
                        while (!isValidMethod)
                        {
                            Console.WriteLine("Please select the Fibonacci method you'd like to solve:");
                            string methodInput = Console.ReadLine();

                            if (int.TryParse(methodInput, out method))
                            {
                                // Call the EvenFibonacciNumbersSolution method
                                try
                                {
                                    var result = Fibonacci.EvenFibonacciNumbersSolution(upperLimit, method);
                                    isValidMethod = true; // Mark as valid if no exception is thrown

                                    if (result.IsList)
                                    {
                                        Console.WriteLine("Even Fibonacci numbers:");
                                        foreach (var number in result.FibonacciList)
                                        {
                                            Console.WriteLine(number);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"The sum of even Fibonacci numbers to {upperLimit} is: {result.Sum}");
                                    }
                                }
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid method number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("");
                        FizzBuzz.FizzBuzzSolution();
                        break;
                    default:
                        Console.WriteLine("Error: Invalid Choice");
                        break;
                }

                if (continueRunning)
                {
                    Console.WriteLine("Would you like to run another kata? (y/n)");
                    var continueInput = Console.ReadLine();

                    if (continueInput?.ToLower() != "y")
                    {
                        continueRunning = false;
                    }
                }
            }

            Console.WriteLine("Thank you for using the Katas Console App. Press any key to exit...");
            Console.ReadKey();
        }
    }
}

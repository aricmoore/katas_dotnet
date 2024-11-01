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
                int method;
                bool isValidMethod = false;

                switch (selection)
                {
                    case "1":
                        int upperLimit;

                        while (!isValidMethod)
                        {
                            FibonacciEven.DisplayEvenFibonacciMenu();
                            string methodInput = Console.ReadLine();

                            if (int.TryParse(methodInput, out method))
                            {
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
                                try
                                {
                                    var result = FibonacciEven.EvenFibonacciNumbersSolution(upperLimit, method);
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
                        int fizzBuzzInput;

                        while (true)
                        {
                            FizzBuzzSingleInput.DisplayFizzBuzzMenu();
                            string methodInput = Console.ReadLine();

                            if (int.TryParse(methodInput, out method))
                            {
                                try
                                {
                                    isValidMethod = true;
                                    break;
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine($"Error: {ex}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                            }
                        }

                        while (true)
                        {
                            Console.WriteLine("Please enter a value you'd like to be FizzBuzzed:");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out fizzBuzzInput))
                            {
                                string result = FizzBuzzSingleInput.FizzBuzzSingleInputSolution(fizzBuzzInput, method);
                                Console.WriteLine($"The result is in: {result}");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                            }
                        }
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

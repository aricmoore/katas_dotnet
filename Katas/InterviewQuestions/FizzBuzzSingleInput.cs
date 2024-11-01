using System;
using System.Collections.Generic;
using System.Text;

namespace Katas.InterviewQuestions
{
    public class FizzBuzzSingleInput
    {
        public static string FizzBuzzSingleInputSolution(int value, int method)
        {
            string result;

            switch (method)
            {
                case 1:
                    result = FizzBuzzSimple(value);
                    break;
                case 2:
                    result = FizzBuzzWithFeatures(value);
                    break;
                default:
                    throw new ArgumentException("Invalid method specified.");
            }

            return result;
        }

        public static void DisplayFizzBuzzMenu()
        {
            Console.WriteLine("Select a FizzBuzz method:");
            Console.WriteLine("1. FizzBuzz Single Input - Simple");
            Console.WriteLine("2. FizzBuzz Single Input - With Input Validation and Dictionary");
        }

        // Allows for efficient string concatenation to handle multiple conditions
        // Decoupled logic is easier to extend with additional conditions
        public static string FizzBuzzSimple(int value)
        {
            StringBuilder output = new StringBuilder();

            if (value % 3 == 0)
            {
                output.Append("Fizz");
            }

            if (value % 5 == 0)
            {
                output.Append("Buzz");
            }

            if (output.Length == 0)
            {
                output.Append($"Your original value of {value} is not divisible by 3 nor 5. Sorry!");
            }

            return output.ToString();
        }

        private static readonly Dictionary<int, string> fizzBuzzRules = new Dictionary<int, string>
        {
            {3, "Fizz" },
            {5, "Buzz" },
            {7, "Pop" }
        };

        public static string FizzBuzzWithFeatures(int value)
        {
            // Validate value input first
            if (value <= 0)
            {
                Console.WriteLine("Please enter a positive integer.");
                return null;
            }

            StringBuilder output = new StringBuilder();
            bool hasOutput = false;

            foreach (var rule in fizzBuzzRules)
            {
                if (value % rule.Key == 0)
                {
                    output.Append(rule.Value);
                    hasOutput = true;
                }
            }

            if (!hasOutput)
            {
                output.Append($"Your original value of {value.ToString()} is not divisible by 3, 5, or 7. Sorry!");
            }

            return output.ToString();
        }

        // TODO: print entire list for upperLimit and each int's output
    }
}

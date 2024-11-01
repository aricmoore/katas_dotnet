using Katas.Models;
using System;
using System.Collections.Generic;

namespace Katas.InterviewQuestions
{
    public class Fibonacci
    {
        public static FibonacciResult EvenFibonacciNumbersSolution(int upperLimit, int method)
        {
            var result = new FibonacciResult();

            // TODO: add other optimised methods

            switch (method)
            {
                case 1:
                    Console.WriteLine("(Fibonacci Sum - Iterative Approach)");
                    result.Sum = CalculateFibSumIterative(upperLimit);
                    return result;
                case 2:
                    Console.WriteLine("(Fibonacci Sum - Recursive Approach)");
                    result.Sum = CalculateFibSumRecursive(upperLimit);
                    return result;
                case 3:
                    Console.WriteLine("(Fibonacci Sum - Optimised Iterative Approach)");
                    result.Sum = CalculateFibSumOptimised(upperLimit);
                    return result;
                case 4:
                    Console.WriteLine("(Fibonacci List - Iterative Approach)");
                    result.FibonacciList = CalculateFibListIterative(upperLimit);
                    return result;
                case 5:
                    Console.WriteLine("(Fibonacci List - Recursive Approach)");
                    result.FibonacciList = CalculateFibListRecursive(upperLimit);
                    return result;
                default:
                    throw new ArgumentException("Invalid method specified.");
            }
        }

        #region Sum

        // Pros: Simple, efficient
        // Cons: Straightforward but not the fastest
        private static int CalculateFibSumIterative(int upperLimit)
        {
            int first = 0, second = 1, sum = 0;

            while (first <= upperLimit)
            {
                if (first % 2 == 0)
                {
                    sum += first;
                }

                var next = first + second;
                first = second;
                second = next;
            }

            return sum;
        }

        // Pros: Simple for small inputs
        // Cons: Inefficient for large inputs; rist of stack overflow
        private static int CalculateFibSumRecursive(int upperLimit)
        {
            int first = 0, second = 1;
            return CalculateFibSumRecursiveHelper(first, second, upperLimit);
        }

        private static int CalculateFibSumRecursiveHelper(int current, int next, int upperLimit)
        {
            if (current > upperLimit)
            {
                return 0;
            }

            var evenSum = current % 2 == 0 ? current : 0;
            var nextEvenFibSum = CalculateFibSumRecursiveHelper(next, current + next, upperLimit);

            return evenSum + nextEvenFibSum;
        }

        private static int CalculateFibSumOptimised(int upperLimit)
        {
            // Must know that every THIRD number in the sequence is even
            // 0 is not considered an even number 
            // Initialise sum with the first even number
            int evenFirst = 2, evenSecond = 8, sum = evenFirst;

            // evenSecond will always have the highest number
            while (evenSecond < upperLimit)
            {
                // F_(n+3) = 4*F_n + F_(n-3) || 4 * second + first
                sum += evenSecond;
                int nextEven = 4 * evenSecond + evenFirst;
                evenFirst = evenSecond;
                evenSecond = nextEven;
            }

            return sum;
        }

        private static int CalculateFibSumMatrix(int upperLimit)
        {
            int sum = 0;
            // TODO: Matrix Exponentiation for extra credit
            return sum;
        }

        #endregion

        #region List

        private static List<int> CalculateFibListIterative(int upperLimit)
        {
            int first = 0, second = 1;
            var list = new List<int>();

            while (first <= upperLimit)
            {
                if (first % 2 == 0)
                {
                    list.Add(first);
                }

                var next = first + second;
                first = second;
                second = next;
            }

            return list;
        }

        private static List<int> CalculateFibListRecursive(int upperLimit)
        {
            int first = 0, second = 1;
            var fibList = new List<int>();
            return CalculateFibListRecursiveHelper(first, second, fibList, upperLimit);
        }

        private static List<int> CalculateFibListRecursiveHelper(int current, int next, List<int> fibonacciList, int upperLimit)
        {
            if (current > upperLimit)
            {
                return fibonacciList;
            }

            if (current % 2 == 0)
            {
                fibonacciList.Add(current);
            }

            return CalculateFibListRecursiveHelper(next, current + next, fibonacciList, upperLimit);
        }

        #endregion
    }
}

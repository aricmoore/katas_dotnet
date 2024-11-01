using System.Collections.Generic;

namespace Katas.Models
{
    public class FibonacciResult
    {
        public List<int> FibonacciList {  get; set; }
        public int Sum {  get; set; }
        public bool IsList => FibonacciList != null;
    }
}

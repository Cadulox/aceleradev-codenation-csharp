using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> result = new List<int> { 0 };

            int previousNumber = 0;
            int nextNumber = 1;

            do
            {
                result.Add(nextNumber);
                nextNumber = nextNumber + previousNumber;
                previousNumber = nextNumber - previousNumber;
            } while (nextNumber < 350);

            return result;
        }

        public bool IsFibonacci(int numberToTest)
        {
            return Fibonacci().Contains(numberToTest);
        }
    }
}

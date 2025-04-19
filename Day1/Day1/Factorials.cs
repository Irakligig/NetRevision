using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Factorials
    {
        public static void ultraFactorial(int x)
        {
            Console.WriteLine($"factorial is {factorial(x)}");
            Console.WriteLine($"Double factorial is {doublefactorial(x)}");
            Console.WriteLine($"Superfactorial is {superfactorial(x)}");
        }

        public static int factorial(int x)
        {
            if (x == 0 || x == 1)
            {
                return 1;
            }
            else
            {
                return x * factorial(x - 1);
            }
        }

        public static int doublefactorial(int x)
        {
            int result = 1;
            for (int i = x; i > 0; i -= 2)
            {
                result *= i;
            }
            return result;
        }

        public static long superfactorial(int x)
        {
            long result = 1;
            int pointer = 1;
            while (pointer <= x)
            {
                result *= factorial(pointer);
                pointer++;
            }
            return result;
        }
    }
}

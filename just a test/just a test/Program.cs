using System;
using System.Numerics;

namespace just_a_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            BigInteger baseN = BigInteger.Parse(inputNumbers[0]);
            BigInteger input = BigInteger.Parse(inputNumbers[1]);
            BigInteger result = 0;
            BigInteger index = 0;
            BigInteger multiplier = 0;
            BigInteger res = 0;
            BigInteger remainder = 0;
            while (input > 0)
            {
                result = input / 10;
                remainder = input % 10;
                multiplier = remainder * MathPow(baseN, index);
                res += multiplier;
                input /= 10;
                index++;
            }
            Console.WriteLine(res);
        }
        static BigInteger MathPow(BigInteger baseN, BigInteger index)
        {
            BigInteger number = 1;

            for (int i = 0; i < index; i++)
            {
                number = number * baseN;
            }
            return number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Double_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            string binary = null;
            Stopwatch start = new Stopwatch();
            start.Start();
            //Console.WriteLine("Count - decimal -> binary");
            for(Int64 i = 0; count < n; i++)
            {
                if (isPalindrome(i) && isBinaryPalindrome(i, out binary))
                {
                    ++count;
                    Console.WriteLine($"{count} ---> {i} -> {binary}");
                }
            }
            
            start.Stop();
            Console.WriteLine("Estimated -> " + start.Elapsed);

        }
        public static bool isBinaryPalindrome(Int64 number, out string binary)
        {
            binary = Convert.ToString(number, 2);
            for(int i = 0; i <= binary.Length/2; i++)
            {                
                if (binary[i] != binary[binary.Length - i - 1])
                {
                    return false;
                }
            }            
            return true;
        }
        public static bool isPalindrome(Int64 number)
        {
            string num = Convert.ToString(number);
            for (int i = 0; i <= num.Length/2; i++)
            {
                if (num[i] != num[num.Length - i - 1])
                {
                    return false;
                }

            }            
            return true;
        }
    }
    
}

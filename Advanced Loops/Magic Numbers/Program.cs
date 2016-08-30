using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers
{
    class Program
    {
        static int[] num = new int[6];
        static int n = 0;
        static void Main(string[] args)
        {
            
            while (n <= 0)
            {
                try
                {
                    Console.Write("Input a number: ");
                    n = int.Parse(Console.ReadLine());
                }
                catch (System.IO.IOException)
                {
                    Console.Error.WriteLine("Invalid I/O");
                }
                catch (ArgumentNullException)
                {
                    continue;
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("Invalid or null input. Try again!");
                }
                catch (Exception err)
                {
                    Console.Error.WriteLine(err);
                }
            }
            
            for (int p = 0; p < num.Length; p++)
            {
                num[p] = 1;
            }
            rec(0);
                                                     
        }
        public static int mult(int[] num)
        {
            int mult = 1;
            for(int i = 0; i < num.Length; i++)
            {
                mult *= num[i];
            }
            return mult;
        }
        public static void rec(int idx)
        {            
            if (idx < 0 || idx > 5)
                return;
            while (num[idx] <= 9)
            {
                if (mult(num) == n)
                {
                    foreach (int el in num)
                        Console.Write(el);
                    Console.Write(" ");
                }
                else
                {   
                    if(idx >= 0 && idx < 5)                 
                        rec(idx + 1);
                }
                num[idx]++;
            }
            num[idx] = 1;
        }
    }
}

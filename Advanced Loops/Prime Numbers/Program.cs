using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Numbers
{
    class Program
    {
        static int n = 0;
        static void Main(string[] args)
        {
            bool err = true;
            while (err)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    err = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong Input! Try again!");
                    err = true;
                }
                catch (Exception)
                {
                    err = true;
                }
            }
            
            bool isPrime = true;
            if (n < 2)
            {
                Console.WriteLine("Not Prime");
                isPrime = false;
            }
            else
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        Console.WriteLine("Not Prime");
                        isPrime = false;
                        break;
                    }
                }
            }
            if (isPrime)
            {
                Console.WriteLine("Prime");
            }
        }
    }
}

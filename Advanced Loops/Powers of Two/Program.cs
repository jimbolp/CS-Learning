using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powers_of_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
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
            for(int i = 0; i <= n; i++)
            {
                try
                {
                    Console.WriteLine(Math.Pow(2, i));
                }
                catch(Exception err)
                {
                    Console.Error.WriteLine(err);
                }
            }
        }
    }
}

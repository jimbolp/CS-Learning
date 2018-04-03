using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_N_to_1
{
    class Program
    {
        static int Main(string[] args)
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
            while(n > 0)
            {
                try
                {
                    Console.WriteLine(n);
                    n--;
                }
                catch(Exception err)
                {
                    Console.Error.WriteLine(err);
                }
            }
            return 0;
        }
    }
}

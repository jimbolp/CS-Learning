using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly
{
    class Program
    {
        static int Main(string[] args)
        {
            int n = 0;
            while (n < 3 || n > 1000)
            {
                Console.Write("Input a number: ");
                n = int.Parse(Console.ReadLine());
                if (n < 3 || n > 1000)
                    Console.WriteLine("Invalid input. Try again.");
            }
            int rows = 2 * (n - 2) + 1;
            for (int i = 0; i < rows; i++)
            {
                if (i == n - 2)
                    try
                    {
                        Console.WriteLine(new string(' ', n - 1) + "@" + new string(' ', n));
                    }
                    catch (System.IO.IOException error)
                    {
                        Console.Error.WriteLine(error);
                    }
                else if (i > n - 2)
                {
                    try
                    {
                        Console.WriteLine((i % 2 == 0) ? new string('*', n - 2) + "/ \\" + new string('*', n - 2) : new string('-', n - 2) + "/ \\" + new string('-', n - 2));
                    }
                    catch (System.IO.IOException error)
                    {
                        Console.Error.WriteLine(error);
                    }
                }
                else
                {
                    try
                    {
                        Console.WriteLine((i % 2 == 0) ? new string('*', n - 2) + "\\ /" + new string('*', n - 2) : new string('-', n - 2) + "\\ /" + new string('-', n - 2));
                    }
                    catch (System.IO.IOException error)
                    {
                        Console.Error.WriteLine(error);
                    }
                }
            }
            return 0;
        }
    }
}

/*
int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= (2 * (n - 2) + 1) / 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(new string('*', n - 2) + @"\" + " " + "/" + new string('*', n - 2));
                }
                else
                    Console.WriteLine(new string('-', n - 2) + @"\" + " " + "/" + new string('-', n - 2));
            }
            Console.WriteLine(new string(' ', (n - 2) + 1) + "@" + new string(' ', (n - 2) + 1));

            for (int i = 1; i <= (2 * (n - 2) + 1) / 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(new string('*', n - 2) + "/" + " " + @"\" + new string('*', n - 2));
                }
                else
                    Console.WriteLine(new string('-', n - 2) + "/" + " " + @"\" + new string('-', n - 2));
            }
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortres
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while(n<3 || n > 1000)
            {
                Console.Write("Input a number: ");
                n = int.Parse(Console.ReadLine());
                if (n < 3 || n > 1000)
                    Console.WriteLine("Invalid input. Try again.");
            }
            for(int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("/" + new string('^', n / 2) + "\\" + new string('_', (n * 2 - ((n / 2) * 2 + 4))) + "/" + new string('^', n / 2) + "\\");
                }
                else if (i == n - 2)
                {
                    Console.WriteLine("|" + new string(' ', n / 2 + 1) + new string('_', (n * 2 - ((n / 2) * 2 + 4))) + new string(' ', n / 2 + 1) + "|");
                }
                else if (i == n - 1)
                {
                    Console.WriteLine("\\" + new string('_', n / 2) + "/" + new string(' ', (n * 2 - ((n / 2) * 2 + 4))) + "\\" + new string('_', n / 2) + "/");
                }
                else
                    Console.WriteLine("|" + new string(' ', n * 2 - 2) + "|");
            }
            
        }
    }
}

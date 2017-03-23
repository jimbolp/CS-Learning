using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional_Statements
{
    class ConditionalStatements
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            if (n%2 != 0)
            {
                Console.WriteLine("Weird");
            }
            else
            {
                if ((n >= 2 && n == 5) || n > 20)
                    Console.WriteLine("Not Weird");
                else if (n >= 6 && n <= 20)
                    Console.WriteLine("Weird");
            }
        }
    }
}

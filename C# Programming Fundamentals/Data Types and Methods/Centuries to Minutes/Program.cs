using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            byte centuries = byte.Parse(Console.ReadLine());
            int years = centuries * 100;
            long days = (long)(years * 365.2422);
            long hours = days * 24;
            ulong minutes = (ulong)(hours * 60);
            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes", centuries, years, days, hours, minutes);
        }
    }
}

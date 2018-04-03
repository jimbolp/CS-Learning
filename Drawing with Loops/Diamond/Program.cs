using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Program
    {
        static int Main(string[] args)
        {
            int n = 0;
            while(n<3 || n > 1000)
            {
                Console.Write("Input an integer: ");
                try{
                    n = int.Parse(Console.ReadLine());
                }catch(FormatException)
                {
                    Console.WriteLine("Input a number.");
                    continue;
                }
                catch(InvalidCastException)
                {
                    continue;
                }
                
                if (n < 3 || n > 1000)
                    Console.WriteLine("Invalid input. Try again!");
            }
            
            int leftRight = (n-1)/2;
            int mid;
            for(int i = 1; i < (n-1)/2; i++)
            {
                mid = n - 2 * leftRight - 2;
                try
                {
                    Console.WriteLine(new string('-', leftRight) + "*" + (mid >= 0 ? (new string('-', mid) + "*") : "") + new string('-', leftRight));
                    leftRight /= i;
                }
                catch(DivideByZeroException errDivision)
                {
                    Console.WriteLine("Cannot devide by zero! -> " + errDivision);
                    return -1;
                    
                }
                catch(System.IO.IOException dd)
                {
                    Console.WriteLine("An error occured -> " + dd.ToString());
                    continue;
                }
                
                
                leftRight --;
            }            
            for(int i = n; i > n/2; i--)
            {
                mid = n - 2 * leftRight - 2;
                Console.WriteLine(new string('-', leftRight) + "*" + (mid >= 0 ? (new string('-', mid) + "*") : "") + new string('-', leftRight));
                leftRight ++;
            }
            return 0;
        }
    }
}

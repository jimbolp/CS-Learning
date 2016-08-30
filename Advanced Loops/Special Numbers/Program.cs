using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers
{
    class Program
    {
        static int[] num = new int[4];
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
            anotherWay(n);
            

        }
        public static T Input<T>()
        {
            var num = Console.ReadLine();            
            try
            {
                int number;
                int.TryParse(num, out number);
                return (T)number;
            }
            catch(FormatException)
            {
                double number;
            }
            

            return number;
        }
        public static bool isSpecialNum(int num)
        {            
            for(int i = 0; i < 4; i++)
            {
                if(num%10 == 0)
                {
                    return false;
                }
                if (n % (num % 10) != 0)
                    return false;
                num /= 10;                
            }
                return true;
        }
        public static void anotherWay(int num)
        {
            int count = 0;
            int number = 1111;
            while (number <= 9999)
            {
                if (isSpecialNum(number))
                {
                    Console.Write(number + " ");
                    count++;
                }
                number++;
            }
            Console.WriteLine("\nNumber of results -> " + count);
        }
        
    }
}

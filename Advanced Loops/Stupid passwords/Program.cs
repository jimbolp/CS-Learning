using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stupid_passwords
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int l = 0;
            while (n <= 0 && l <= 0)
            {
                try
                {
                    Console.Write("Input number of digits: ");
                    n = int.Parse(Console.ReadLine());
                    Console.Write("Input number of letters: ");
                    l = int.Parse(Console.ReadLine());
                    if (n < 1 || n > 9 || l < 0 || l > 9)
                    {
                        n = 0;
                        l = 0;
                        throw new FormatException("The number of digits and letters cannot be lesser than 1 or greater than 9");
                    }
                }
                catch(System.IO.IOException)
                { 
                    Console.Error.WriteLine("Invalid I/O");
                }
                catch (ArgumentNullException)
                {
                    continue;
                }
                catch (FormatException err)
                {
                    Console.Error.WriteLine(err);
                }
                catch (Exception err)
                {
                    Console.Error.WriteLine(err);
                }
            }
            string letters = "abcdefghijklmnopqrstuvwxyz";
            for(int i = 1; i < n; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    for(int k = 0; k < l; k++)
                    {
                        for(int m = 0; m < l; m++)
                        {
                            int end = 0;
                            while(end <= i && end <= j)
                            {
                                end++;
                            }
                            try
                            {
                                Console.Write("{0}{1}{2}{3}{4} ", i, j, letters[k], letters[m], end);
                            }
                            catch(Exception err)
                            {
                                Console.Error.WriteLine(err);
                            }
                            
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}

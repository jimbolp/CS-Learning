using System;

namespace LoopByStep3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = 0;
            char end = 'y';
            while (end == 'y')
            {
                n = 0;
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
                for (int i = 1; i <= n; i += 3)
                {
                    Console.WriteLine(i);
                }
                end = 's';
                while (end != 'y' && end != 'n') {
                    try
                    {
                        Console.WriteLine("To continue with a different integer type 'y' else type 'n'.");
                        end = char.Parse(Console.ReadLine());
                        if (end != 'y' && end != 'n')
                        {
                            Console.Error.WriteLine("Invalid choice! Try \'y\' or \'n\'!");
                        }

                    }
                    catch (FormatException)
                    {
                        Console.Error.WriteLineAsync("The String must be exactly one character long!");
                    }
                    catch (Exception err)
                    {
                        Console.Error.WriteLine(err);
                        continue;
                    }
                }                    
            }
        }
    }
}

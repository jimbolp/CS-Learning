using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine();
            try
            {
                sbyte temp = sbyte.Parse(n);
                if(temp >= 0)
                Console.WriteLine("{0} can fit in:\n* sbyte\n* byte\n* short\n* ushort\n* int\n* uint\n* long", temp);
                else
                {
                    Console.WriteLine("{0} can fit in:\n* sbyte\n* short\n* int\n* long", temp);
                }
            }
            catch (Exception)
            {
                try
                {
                    byte temp = byte.Parse(n);
                    Console.WriteLine("{0} can fit in:\n* byte\n* short\n* ushort\n* int\n* uint\n* long", temp);
                }
                catch (Exception)
                {
                    try
                    {
                        short temp = short.Parse(n);
                        if (temp >= 0)
                            Console.WriteLine("{0} can fit in:\n* short\n* ushort\n* int\n* uint\n* long", temp);
                        else
                            Console.WriteLine("{0} can fit in:\n* short\n* int\n* long", temp);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            ushort temp = ushort.Parse(n);
                            Console.WriteLine("{0} can fit in:\n* ushort\n* int\n* uint\n* long", temp);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                int temp = int.Parse(n);
                                if (temp >= 0)
                                    Console.WriteLine("{0} can fit in:\n* int\n* uint\n* long", temp);
                                else
                                    Console.WriteLine("{0} can fit in:\n* int\n* long", temp);
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    uint temp = uint.Parse(n);
                                    Console.WriteLine("{0} can fit in:\n* uint\n* long", temp);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        long temp = long.Parse(n);
                                        Console.WriteLine("{0} can fit in:\n* long", temp);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("{0} can't fit in any type",n);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

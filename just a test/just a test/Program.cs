using System;
using System.Numerics;

namespace just_a_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1);
                }
            });
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("Another thread!!");
                }
            });
            t1.Start();
            t2.Start();
        }
    }
}

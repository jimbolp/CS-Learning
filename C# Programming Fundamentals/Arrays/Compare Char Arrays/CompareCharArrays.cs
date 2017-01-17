using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class CompareCharArrays
{
    static void Main(string[] args)
    {
        char[] first = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        char[] second = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        for (int i = 0; i < (first.Length < second.Length?first.Length:second.Length); i++)
        {
            if (first[i] == second[i])
            {
                if (i == (first.Length < second.Length ? first.Length - 1 : second.Length - 1))
                {
                    if(first.Length <= second.Length)
                        Console.WriteLine(string.Join("", first) + "\n" + string.Join("", second));
                    else
                        Console.WriteLine(string.Join("", second) + "\n" + string.Join("", first));
                    break;
                }
                continue;
            }
            else if (first[i] < second[i])
            {
                Console.WriteLine(string.Join("", first) + "\n" + string.Join("", second));
                break;
            }
            else
            {
                Console.WriteLine(string.Join("", second) + "\n" + string.Join("", first));
                break;
            }
        }
    }
}


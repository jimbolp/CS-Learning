using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Array
{
    class DynamicArray
    {
        static void Main(string[] args)
        {
            int[] tempArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = tempArr[0];
            int Q = tempArr[1];
            List<int>[] seqList = new List<int>[N];
            for (int i = 0; i < N; ++i)
            {
                seqList[i] = new List<int>();
            }
            int lastAns = 0;
            List<int> output = new List<int>();
            for (int i = 0; i < Q; ++i)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int seqType = input[0];
                int x = input[1];
                int y = input[2];
                switch (seqType)
                {
                    case 1:
                        seqList[(x^lastAns)%N].Add(y);
                        break;
                    case 2:
                        int index = (x ^ lastAns)%N;
                        lastAns = seqList[index][y % seqList[index].Count];
                        //Console.WriteLine(lastAns);
                        output.Add(lastAns);
                        break;
                    default:
                        break;
                }
            }
            foreach (var el in output)
            {
                Console.WriteLine(el);
            }
        }
    }
}

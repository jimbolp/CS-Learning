using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace The_Crazy_Helix
{
    class TheCrazyHelix
    {
        public unsafe class UnsafeArray
        {
            private readonly int* _start;
            public readonly int Length;

            public UnsafeArray(int* start, int enforceLength = 0)
            {
                this._start = start;
                this.Length = enforceLength > 0 ? enforceLength : int.MaxValue;
            }

            public int this[int index]
            {
                get { return _start[index]; }
                set
                {
                    if (index >= this.Length)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    _start[index] = value;
                }
            }

            public int IndexOf(int value)
            {
                for (int i = 0; i < Length; ++i)
                {
                    if (_start[i] == value)
                    {
                        return i + 1;
                    }
                }
                return -1;
            }

            public int[] ToArray()
            {
                int[] arr = new int[Length];
                for (int i = 0; i < Length; ++i)
                {
                    arr[i] = _start[i];
                }
                return arr;
            }
        }
        static unsafe void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = input[0]; //array length
            int Q = input[1]; //Number of orders

            fixed (int* arr = new int[N])
            {
                UnsafeArray uArr = new UnsafeArray(&arr[0], N);

                for (int i = 0; i < N; ++i)
                {
                    uArr[i] = i + 1;
                }
                for (int i = 0; i < Q; ++i)
                {
                    input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    switch (input[0])
                    {
                        case 1:
                            var start = input[1] - 1;
                            var end = input[2] - 1;
                            for (int j = 0; j < (input[2] - input[1] + 1)/2; ++j)
                            {
                                var temp = uArr[start + j];
                                uArr[start + j] = uArr[end - j];
                                uArr[end - j] = temp;
                            }//*/
                            reverse(uArr.ToArray());
                            break;
                        case 2:
                            //var a = arr.First(x => x == input[1]);
                            Console.WriteLine($"element {input[1]} is at position {uArr.IndexOf(input[1])}");
                            break;
                        case 3:
                            Console.WriteLine($"element at position {input[1]} is {arr[input[1] - 1]}");
                            break;
                        default:
                            break;
                    }
                }
                
            }
            Console.ReadLine();
        }

        static unsafe void reverse(int[] arr)
        {
            uint Temp;
            uint Temp2;

            fixed (int* arrPtr = arr)
            {
                uint* p, q;
                p = (uint*)(arrPtr);
                q = (uint*)(arrPtr + arr.LongLength-1);

                if (arr.LongLength == 2)
                {
                    Temp = *p;
                    *p = ((Temp & 0xFFFF0000) >> 16) | ((Temp & 0x0000FFFF) << 16);
                    return;
                }

                while (p < q)
                {
                    Temp = *p;
                    Temp2 = *q;

                    *p = ((Temp2 & 0xFFFF0000) >> 16) | ((Temp2 & 0x0000FFFF) << 16);
                    *q = ((Temp & 0xFFFF0000) >> 16) | ((Temp & 0x0000FFFF) << 16);

                    p++;
                    q--;
                }
            }
        }
        /*static int IndexOfElement(List<int> arr, int element)
        {
            for (int i = 0; i <= arr.Count; ++i)
            {
                if (arr[i] == element)
                    return i+1;
            }
            return -1;
        }//*/
        /*static Dictionary<int, int> RotateArr(Dictionary<int,int> arr, int startRange, int endRange)
        {
            List<int> tempArr = new List<int>();
            for (int i = startRange; i <= endRange; ++i)
            {
                tempArr.Add(arr[i]);
            }
            tempArr.Reverse();
            for (int i = 0; i < tempArr.Count; ++i)
            {
                arr[startRange + i] = tempArr[i];
            }
            return arr;
        }//*/
    }
}

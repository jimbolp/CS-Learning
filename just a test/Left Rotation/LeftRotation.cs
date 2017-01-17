using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_Rotation
{
    class LeftRotation
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //int numberOfIntegers = input[0];
            int numberOfRotations = input[1];
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (numberOfRotations != arr.Length)
                arr = RotateLeft(arr, numberOfRotations);
                
            foreach (var a in arr)
            {
                Console.Write(a + " ");
            }
        }

        static int[] RotateLeft(int[] arr, int rotations)
        {
            int[] elementsToRotate = new int[rotations];
            int[] tempArr = new int[arr.Length];
            for (int i = 0; (i + rotations) < arr.Length; ++i)
            {
                tempArr[i] = arr[i + rotations];
            }
            for (int i = arr.Length - rotations, j = 0; i < arr.Length; ++i)
            {
                tempArr[i] = arr[j++];
            }
            
            return tempArr;
        }
    }
}

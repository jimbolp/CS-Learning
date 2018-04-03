using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RotateAndSum
{
    static void Main(string[] args)
    {
        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var n = int.Parse(Console.ReadLine());
        var summed = Shift(arr);
        for (int i = 0; i < n-1; i++)
        {
            arr = Shift(arr);
            summed = Sum(summed, arr);
        }
        foreach (var i in summed)
        {
            Console.Write(i + " ");
        }
    }

    public static int[] Shift(int[] arr)
    {
        var temp = arr[arr.Length - 1];
        int[] shiftedArr = new int[arr.Length];
        shiftedArr[0] = temp;
        for (int i = 0; i < arr.Length-1; i++)
        {
            shiftedArr[i + 1] = arr[i];
        }
        return shiftedArr;
    }

    public static int[] Sum(int[] sum, int[] arr)
    {
        int[] shiftedArr = Shift(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            sum[i] += shiftedArr[i];
        }
        return sum;
    }
}

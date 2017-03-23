using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

class MatrixGenerator
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Trim().Split().ToArray();
        List<List<int>> matrix = new List<List<int>>();
        //int value = 1;
        switch (input[0])
        {
            case "A":
                CaseA(matrix, int.Parse(input[1]), int.Parse(input[2]));
                break;
            case "B":
                CaseB(matrix, int.Parse(input[1]), int.Parse(input[2]));
                break;
            case "C":
                CaseC(matrix, int.Parse(input[1]), int.Parse(input[2]));
                break;
            case "D":
                CaseD(matrix, int.Parse(input[1]), int.Parse(input[2]));
                break;
        }
    }

    public static void CaseA(List<List<int>> matrix, int rows, int cols )
    {
        
    }
    public static void CaseB(List<List<int>> matrix, int rows, int cols)
    {
        int value = 1;
        int row = 0;
        //int col = 0;
        int dir = 1;
        for (int i = 0; i < rows; i++)
        {
            matrix.Add(new List<int>());
        }
        while (value <= rows*cols)
        {
            if (row == 0)
            {
                dir = 1;
            }
            else if (row == rows)
            {
                dir = 2;
            }
            if (dir == 1)
            {
                matrix[row].Add(value++);
                row++;
            }
            else if (dir == 2)
            {
                row--;
                matrix[row].Add(value++);
            }
        }
        foreach (var list in matrix)
        {
            Console.WriteLine(string.Join(" ", list));
        }
    }
    public static void CaseC(List<List<int>> matrix, int rows, int cols)
    {
        int startRow = rows-1;
        int value = 1;
        //int col = 0;
        int row;
        for (int i = 0; i < rows; i++)
        {
            matrix.Add(new List<int>());
            matrix[i].Capacity = cols;
        }
        while (value <= rows*cols)
        {
            if (startRow < 0)
                startRow = 0;
            row = startRow;
            for (; row < rows; ++row)
            {
                if (matrix[row].Count < matrix[row].Capacity && value <= rows * cols)
                    matrix[row].Add(value++);
                else
                    break;
            }
            --startRow;
        }
        foreach (var list in matrix)
        {
            Console.WriteLine(string.Join(" ", list));
        }
    }
    public static void CaseD(List<List<int>> matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            matrix.Add(new List<int>());
            matrix[i].Capacity = cols;
            for (int j = 0; j < cols; j++)
            {
                matrix[i].Add(0);
            }
        }
        foreach (var i in matrix)
        {
            Console.WriteLine(string.Join(" ", i));
        }
        string direction = "down";
        int row = 0;
        int col = 0;
        int value = 1;


    }
}

using System;
using System.Collections.Generic;
using System.Linq;

class MaxElement
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> myStack = new Stack<int>();
        Stack<int> maxElements = new Stack<int>();
        maxElements.Push(Int32.MinValue);
        for (int i = 0; i < n; i++)
        {
            string[] commandArgs = Console.ReadLine().Split();
            string command = commandArgs[0];
            if (command == "1")
            {
                int num = int.Parse(commandArgs[1]);
                
                myStack.Push(num);
                if(num >= maxElements.Peek())
                    maxElements.Push(num);
            }
            else if (command == "2")
            {
                if (myStack.Peek() == maxElements.Peek())
                {
                    myStack.Pop();
                    maxElements.Pop();
                    if(maxElements.Count == 0)
                        maxElements.Push(Int32.MinValue);
                }
                else
                    myStack.Pop();
            }
            else //3
            {
                Console.WriteLine(maxElements.Peek());
            }
        }
    }
}

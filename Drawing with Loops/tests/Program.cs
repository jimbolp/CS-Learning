using System;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TenderPosition tp = new TenderPosition();
            try
            {
                tp.BranchNumber = 100;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine(tp.BranchNumber);
        }
    }
}
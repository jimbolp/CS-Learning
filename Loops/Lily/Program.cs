using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lily
{
    class Program
    {
        static void Main(string[] args)
        {            
            int numberOfToys = 0;            
            int moneyRecieved = 0;
            float moneyCollected = 0;
            int age = 0;
            try
            {
                age = int.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            float washingMachinePrice = float.Parse(Console.ReadLine());
            int toysPrice = int.Parse(Console.ReadLine());            
            for (int i = 0; i <= age; i++)
            {
                if (Gift(i) == "toy")
                {
                    numberOfToys++;
                }
                else if (Gift(i) == "money")
                {
                    moneyRecieved += 10;
                    moneyCollected += moneyRecieved - 1;
                }
            }
            moneyCollected += numberOfToys * toysPrice;
            if (moneyCollected >= washingMachinePrice)
                Console.WriteLine("Yes {0}", Math.Round(moneyCollected - washingMachinePrice, 2));
            else
                Console.WriteLine("No {0}", Math.Round(washingMachinePrice - moneyCollected,2));
        }
        public static string Gift(int years)
        {            
            if(years > 1 && years%2 == 0)
            {
                return "toy";
            }
            else if(years > 0 && years%2 != 0)
            {
                return "money";
            }
            else
                return "null";
        }
    }
}

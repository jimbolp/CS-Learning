using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Array
{
    public class Cat
    {
        public string name;        
        protected Cat() { }
        public override string ToString()
        {
            return "bla bla";
        }
    }
    public class Siamese : Cat
    {
        public double earSize;
        public Siamese(string n, double eSize)
        {
            name = n;
            earSize = eSize;
            Console.WriteLine("Derived class: Siamese");
        }
        public override string ToString()
        {
            return $"Siamese -> {name} -> {earSize:f2}\n";
        }//*/
    }
    public class Cymric : Cat
    {
        public double furLength;
        public Cymric(string n, double fSize)
        {
            name = n;
            furLength = fSize;
        }
        public override string ToString()
        {
            return $"Cymric -> {name} -> {furLength:f2}\n";
        }
    }
    public class StreetCat : Cat
    {
        public uint decibels;
        public StreetCat(string n, uint d)
        {
            name = n;
            decibels = d;
        }
        public override string ToString()
        {
            return $"StreetCat -> {name} -> {decibels}\n";
        }
    }
    class DynamicArray
    {
        static void Main(string[] args)
        {            
            List<Cat> cat = new List<Cat>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] catsInput = input.Split(' ');
                switch(catsInput[0])
                {
                    case "Siamese":
                        cat.Add(new Siamese(catsInput[1], float.Parse(catsInput[2])));
                        break;
                    case "Cymric":
                        cat.Add(new Cymric(catsInput[1], double.Parse(catsInput[2])));
                        break;
                    case "StreetExtraordinaire":
                        cat.Add(new StreetCat(catsInput[1], uint.Parse(catsInput[2])));
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            Console.WriteLine(cat.Where(c => c.name == input).FirstOrDefault());

            /*int[] tempArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
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
            }//*/
        }
    }
}

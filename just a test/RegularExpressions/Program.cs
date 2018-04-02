using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace RegularExpressions
{
    class Program
    {
        public class Tests
        {
            public int MyProperty { get; set; }
            public int OtherProp { get; set; }
            public override string ToString()
            {
                for (int i = 0; i< 100; ++i)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
                return "Done!";
            }
        }
        static async void Main(string[] args)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;


            /*
            string s1 = @"apple:green:3 banana:yellow:5";
            var myRegex = new Regex(@"(\w+):(\w+):(\d+)");

            ///////// The six main tasks we're likely to have ////////

            // Task 1: Is there a match?
            Console.WriteLine("*** Is there a Match? ***");
            if (myRegex.IsMatch(s1)) Console.WriteLine("Yes");
            else Console.WriteLine("No");

            // Task 2: How many matches are there?
            MatchCollection AllMatches = myRegex.Matches(s1);
            Console.WriteLine("\n" + "*** Number of Matches ***");
            Console.WriteLine(AllMatches.Count);

            // Task 3: What is the first match?
            Console.WriteLine("\n" + "*** First Match ***");
            Match OneMatch = myRegex.Match(s1);
            if (OneMatch.Success)
            {
                Console.WriteLine("Overall Match: " + OneMatch.Groups[0].Value);
                Console.WriteLine("Group 1: " + OneMatch.Groups[1].Value);
                Console.WriteLine("Group 2: " + OneMatch.Groups[2].Value);
                Console.WriteLine("Group 3: " + OneMatch.Groups[3].Value);
            }

            // Task 4: What are all the matches?
            Console.WriteLine("\n" + "*** Matches ***");
            if (AllMatches.Count > 0)
            {
                foreach (Match SomeMatch in AllMatches)
                {
                    Console.WriteLine("Overall Match: " + SomeMatch.Groups[0].Value);
                    Console.WriteLine("Group 1: " + SomeMatch.Groups[1].Value);
                    Console.WriteLine("Group 2: " + SomeMatch.Groups[2].Value);
                    Console.WriteLine("Group 3: " + SomeMatch.Groups[3].Value);
                }
            }

            // Task 5: Replace the matches
            // simple replacement: reverse groups
            string replaced = myRegex.Replace(s1,
                   delegate (Match m) {
                       return m.Groups[3].Value + ":" +
                  m.Groups[2].Value + ":" +
                  m.Groups[1].Value;
                   }
                    );
            Console.WriteLine("\n" + "*** Replacements ***");
            Console.WriteLine(replaced);

            // Task 6: Split
            // Let's split at colons or spaces
            string[] splits = Regex.Split(s1, @":|\s");
            Console.WriteLine("\n" + "*** Splits ***");
            foreach (string split in splits) Console.WriteLine(split);
            //*/
            Console.WriteLine("\nPress Any Key to Exit.");
            Console.ReadKey();
        }

        private static void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        static async Task<(int sum, int count)> Test(int[] values)
        {
            var result = (s: 0, c: 0);
            foreach (int i in values)
            {
                result = (result.s + i, ++result.c);
            }
            return result;
        }
        private static int Calculate(int number)
        {
            int result =
                6 * ((number / 1) % 10) +
                5 * ((number / 10) % 10) +
                4 * ((number / 100) % 10) +
                3 * ((number / 1000) % 10) +
                2 * ((number / 10000) % 10);
                    //((number / 10000) % 10);
            if ((result % 11) == 10)
                number = number * 10 + 0;
            else
                number = number * 10 + (result % 11);
            return number;

            //int result =
            //    //7 * ((number / 1) % 10) +
            //    6 * ((number / 10) % 10) +
            //    5 * ((number / 100) % 10) +
            //    4 * ((number / 1000) % 10) +
            //    3 * ((number / 10000) % 10) +
            //    2 * ((number / 100000) % 10) +
            //    ((number / 100000) % 10);
            //if ((result % 11) == 10)
            //    number = number * 10 + 0;
            //else
            //    number = number * 10 + (result % 11);
            //return number;
        }
    }
}

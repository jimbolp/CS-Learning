using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
//using Application = Microsoft.Office.Interop.Excel.Application;

namespace just_a_test
{
    class Program
    {
        static void Main(string[] args)
        {
            char str = 'a' < 'A' ? 'a' : 'A';

            //str = (char)Console.ReadLine()[0];
            using (FileStream fi = new FileStream(@"D:\Documents\GitHub\CS-Learning\just a test\just a test\bin\Debug\test.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fi, Encoding.Default))
                {
                    while (str <= ('а' > 'А' ? 'а' : 'А'))
                    {
                        if (str >= 'a' && str <= 'z')
                        {
                            sw.WriteLine(Environment.NewLine + "Lower case EN:");
                            while (str <= 'z')
                                sw.WriteLine(str + " => " + (int)str++);
                        }
                        else if (str >= 'A' && str <= 'Z')
                        {
                            sw.WriteLine(Environment.NewLine + "Upper case EN:");
                            while (str <= 'Z')
                                sw.WriteLine(str + " => " + (int)str++);
                        }
                        else if (str >= 'А' && str <= 'Я')
                        {
                            sw.WriteLine(Environment.NewLine + "Upper case BG/RU:");
                            while (str <= 'Я')
                                sw.WriteLine(str + " => " + (int)str++);
                        }
                        else if (str >= 'а' && str <= 'я')
                        {
                            sw.WriteLine(Environment.NewLine + "Lower case BG/RU:");
                            while (str <= 'я')
                                sw.WriteLine(str + " => " + (int)str++);
                        }
                        else
                            str++;
                    }
                }
            }
        }
    }
}

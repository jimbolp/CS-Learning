using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadFromAndWriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader text;
            string line;
            try
            {
                text = new StreamReader("palindromes.txt");
                
                //Create, open and write all the text to the file...
                System.IO.File.WriteAllText("Decimal palindromes.txt", "");

                //Start by streaming the first line from the file to a string
                line = text.ReadLine();
                while (line != null)
                {
                    string[] parts = new string[line.Length];
                    int j = 0;
                    for (int i = 0; i < line.Length; i++)
                    {

                        if (line[i] != ' ' && i < line.Length)
                        {
                            string temp = "";
                            while (i < line.Length && line[i] != ' ')
                            {
                                temp += line[i];
                                i++;
                            }
                            parts[j] = temp;
                            j++;
                        }

                    }

                    if ((line = text.ReadLine()) != null)
                        System.IO.File.AppendAllText("Decimal palindromes.txt", parts[3] + ", ");
                    else
                        System.IO.File.AppendAllText("Decimal palindromes.txt", parts[3]);
                    Console.WriteLine(parts[3] + " <-> " + parts[2]);
                    //Console.WriteLine(line);

                }

                text.Close();

            }
            catch (FileNotFoundException err)
            {
                Console.Error.WriteLine(err);
            }
            catch (Exception err)
            {
                Console.Error.WriteLine(err);
            }
            
            
        }
    }
}

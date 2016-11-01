//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class BookLibrary
{
    class Library
    {
        private string name;
        public string Name { get; set; }
        public List<Books> books = new List<Books>();
        public void combineAuthors()
        {
            List<string> combinedAuthors = new List<string>();
            for(int i = 0; i < books.Count; ++i)
            {
                if (!combinedAuthors.Contains(books[i].Author))
                {                   
                    combinedAuthors.Add(books[i].Author);
                }
            }
            for (int i = 0; i < combinedAuthors.Count; ++i)
            {
                double price = 0.0;
                for (int j = 0; j < books.Count; j++)
                {
                    if(books[j].Author == combinedAuthors[i])
                    {
                        price += books[j].Price;
                    }
                }
                Console.WriteLine($"{combinedAuthors[i]} -> {price:f2}");

            }           

        }
    }
    class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ISBN { get; set; }
        public double Price { get; set; }

    }
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Library myLibrary = new Library();
        for (int i = 0; i < n; i++)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            Books temp = new Books();
            temp.Title = input[0];
            temp.Author = input[1];
            temp.Publisher = input[2];
            temp.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            temp.ISBN = int.Parse(input[4]);
            temp.Price = double.Parse(input[5]);
            myLibrary.books.Add(temp);
        }        
        myLibrary.combineAuthors();
        //Console.WriteLine(myLibrary.books[0].ReleaseDate.ToShortDateString() + "\n" + myLibrary.books[0].ISBN.ToString("D10"));
    }    
}

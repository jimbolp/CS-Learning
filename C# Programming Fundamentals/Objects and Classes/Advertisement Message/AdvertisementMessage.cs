using System;
using System.Collections.Generic;
using System.Linq;

class AdvertisementMessage
{
    static void Main(string[] args)
    {
        List<string> phrases = new List<string>() { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."};
        List<string> events = new List<string>() {"Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
        List<string> authors = new List<string>() {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
        List<string> cities = new List<string>() {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};
        Random rnd = new Random();
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; ++i)
        {
            var phraseIndex = rnd.Next(0, phrases.Count);
            var eventIndex = rnd.Next(0, events.Count);
            var authorIndex = rnd.Next(0, authors.Count);
            var cityIndex = rnd.Next(0, cities.Count);
            Console.WriteLine($"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} - {cities[cityIndex]}");
        }
        
    }
}


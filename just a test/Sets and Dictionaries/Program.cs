using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace Sets_and_Dictionaries
{
    class Program
    {
        private static string[] validatedInput;
        private static List<Venue> Venues = new List<Venue>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (!ValidateInput(input, out validatedInput))
                {
                    input = Console.ReadLine();
                    continue;
                }
                InitializeVenue();
                input = Console.ReadLine();
            }

            foreach(Venue v in Venues)
            {
                v.SortSingers();
                Console.WriteLine(v.Name);
                foreach(Singer s in v.Singers)
                {
                    Console.WriteLine("#  " + s.Name.Trim() + " -> " + s.EarnedMoney);
                }
            }
            Console.ReadLine();
        }

        
        private static void InitializeVenue()
        {
            if (validatedInput == null)
                return;
            int money = int.Parse(validatedInput[2]) * int.Parse(validatedInput[3]);
            if(Venues.Count == 0 || !Venues.Any(ven => ven.Name == validatedInput[1]))
            {
                Venue venue = new Venue()
                {
                    Name = validatedInput[1],
                    Singers = new List<Singer>() { new Singer() { Name = validatedInput[0], EarnedMoney = (int.Parse(validatedInput[2]) * int.Parse(validatedInput[3])) } }
                };
                Venues.Add(venue);
            }
            else
            {
                Venue venue = Venues.Where(ven => ven.Name == validatedInput[1]).FirstOrDefault();
                Singer singer = new Singer() { Name = validatedInput[0], EarnedMoney = (int.Parse(validatedInput[2]) * int.Parse(validatedInput[3])) };
                if(venue.Singers.Any(a => a.Name == singer.Name))
                {
                    Singer changedSinger = venue.Singers.Where(s => s.Name == singer.Name).FirstOrDefault();
                    changedSinger.EarnedMoney += singer.EarnedMoney;
                }
                else
                {
                    venue.Singers.Add(singer);
                }
            }
        }

        private static bool ValidateInput(string input, out string[] validatedInput)
        {
            string[] tempInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool hasVenueSymbol = false;
            int venueIndex = 0;
            int? ticketCount = null;
            int? ticketPrice = null;
            string singerName = "";
            string venueName = "";
            int i = 0;
            List<int> numbers = new List<int>();
            foreach(string s in tempInput)
            {
                if (!hasVenueSymbol && s.StartsWith("@"))
                {
                    hasVenueSymbol = true;
                    venueIndex = i;
                    venueName = s;
                }
                else if (!hasVenueSymbol)
                {
                    singerName += s + " ";
                }
                else
                {
                    if (Int32.TryParse(s, out int num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        venueName += " " + s;
                    }
                }
                i++;
            }
            if (!hasVenueSymbol)
            {
                validatedInput = null;
                return false;
            }
            else if (venueIndex > 3 || venueIndex < 1)
            {
                validatedInput = null;
                return false;
            }
            if(numbers.Count == 2)
            {
                ticketPrice = numbers[0];
                ticketCount = numbers[1];
            }
            else
            {
                validatedInput = null;
                return false;
            }
            validatedInput = new string[]
            {
                singerName.Trim(),
                venueName.StartsWith("@")? venueName.Remove(0, 1) : venueName,
                ticketPrice.ToString(),
                ticketCount.ToString()
            };
            return true;
        }
    }

    class Venue
    {
        public string Name { get; set; }
        //public SortedDictionary<int, List<string>> Singers { get; set; } = new SortedDictionary<int, List<string>>();
        public List<Singer> Singers { get; set; } = new List<Singer>();

        public void SortSingers()
        {
            var sortedList = from singer in Singers
                             orderby singer.EarnedMoney descending
                             select singer;
            Singers = sortedList.ToList();
        }
    }
    class Singer
    {
        public string Name { get; set; }
        public int EarnedMoney { get; set; }
    }
}

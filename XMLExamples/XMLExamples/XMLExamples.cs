using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class XMLExamples
{
    static void Main(string[] args)
    {
        SaveDataToAnXmlFile("test.xml");
        XDocument doc = XDocument.Load("test.xml");
        QueryTheData(doc);
        XDocument ourBlog = XDocument.Load("http://www.stellman-greene.com/feed");
        Console.WriteLine(ourBlog.ToString());
        //Console.WriteLine(ourBlog.Element("rss").Element("channel").Element("title").Value);
        IEnumerable<Post> posts =
         from post in ourBlog.Descendants("item")
         select new Post(post);

        // Print each post to the console
        foreach (var post in posts)
            Console.WriteLine(post.ToString());
    }

    static XDocument GetStarbuzzData()
    {
        XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Starbuzz Customer Loyalty Data"),
                new XElement("starbuzzData",
                    new XAttribute("storeName", "Park Slope"),
                    new XAttribute("location", "Brooklyn, NY"),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Janet Venutian"),
                            new XElement("zip", 11215)),
                        new XElement("favouriteDrink", "Choco Macchiato"),
                        new XElement("moneySpent", 255),
                        new XElement("visits", 50)),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Liz Nelson"),
                            new XElement("zip", 11238)),
                        new XElement("favouriteDrink", "Double Cappuccino"),
                        new XElement("moneySpent", 150),
                        new XElement("visits", 35)),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Matt Franks"),
                            new XElement("zip", 11217)),
                        new XElement("favouriteDrink", "Zesty Lemon Chai"),
                        new XElement("moneySpent", 75),
                        new XElement("visits", 15)),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Joe Ng"),
                            new XElement("zip", 11217)),
                        new XElement("favouriteDrink", "Banana Split in a Cup"),
                        new XElement("moneySpent", 60),
                        new XElement("visits", 10)),
                    new XElement("person",
                         new XElement("personalInfo",
                             new XElement("name", "Sarah Kalter"),
                             new XElement("zip", 11215)),
                         new XElement("favouriteDrink", "Boring Coffee"),
                         new XElement("moneySpent", 110),
                         new XElement("visits", 15))));
        return doc;
    }
    static void SaveDataToAnXmlFile(string filename)
    {
        XDocument doc = GetStarbuzzData();
        doc.Save(filename);
        
        //Console.WriteLine(doc.ToString());
    }

    static void QueryTheData(XDocument doc)
    {
        var data = from item in doc.Descendants("person")
            select new
            {
                drink = item.Element("favouriteDrink").Value,
                moneySpent = item.Element("moneySpent").Value,
                zipCode = item.Element("personalInfo").Element("zip").Value
            };
        foreach (var p in data)
            Console.WriteLine(p.ToString());
        var zipCodeGroups = from item in doc.Descendants("person")
            group item.Element("favouriteDrink").Value
                by item.Element("personalInfo").Element("zip").Value
            into zipCodeGroup
            select zipCodeGroup;
        foreach (var group in zipCodeGroups)
        {
            Console.WriteLine($"{group.Distinct().Count()} favourite drinks in {group.Key}");
        }
    }

    class Post
    {
        public string Title { get; private set; }
        public DateTime? Date { get; private set; }
        public string Url { get; private set; }
        public string Description { get; private set; }
        public string Creator { get; private set; }
        public string Content { get; private set; }

        private static string GetElementValue(XContainer element, string name)
        {
            if ((element == null) || (element.Element(name) == null))
                return String.Empty;
            return element.Element(name).Value;
        }
        public Post(XContainer post)
        {
            // Get the string properties from the post's element values
            Title = GetElementValue(post, "title");
            Url = GetElementValue(post, "guid");
            Description = GetElementValue(post, "description");
            Creator = GetElementValue(post,
                "{http://purl.org/dc/elements/1.1/}creator");
            Content = GetElementValue(post,
                "{http://purl.org/dc/elements/1.0/modules/content}encoded");

            // The Date property is a nullable DateTime? -- if the pubDate element
            // can't be parsed into a valid date, the Date property is set to null
            DateTime result;
            if (DateTime.TryParse(GetElementValue(post, "pubDate"), out result))
                Date = (DateTime?)result;
        }
        public override string ToString()
        {
          return $"{Title ?? "no title"} by {Creator ?? "Unknown"}";
        }
}
}

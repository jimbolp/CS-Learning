using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace XmlTests
{
    class XmlTests
    {
        static void Main(string[] args)
        {
            XElement sitemap = XElement.Load("sitemap.xml");

            XName url = XName.Get("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XName loc = XName.Get("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            foreach (var urlElement in sitemap.Elements(url))
            {
                var locElement = urlElement.Element(loc);
                Console.WriteLine(locElement.Value);
            }
            XElement a = new XElement("a");
            XAttribute href = new XAttribute("href", "https://softuni.bg");
            a.Add(href);
            a.Add("", "SoftUni");
            Console.WriteLine(a);    
            Console.WriteLine(sitemap.Elements().Count());
        }
    }
}
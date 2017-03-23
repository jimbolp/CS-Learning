using System;
using System.Collections.Generic;
using System.Linq;

class Sales_Report
{
    static void Main(string[] args)
    {
        List<string> arr = new List<string>{ "fffas","a", "ab", "cccc", "ba", "aab", "baa", "bbbbb", "asdfwe", "ssss"};
        foreach (var a in arr)
        {
            Console.Write(a + " ");
        }
        Console.WriteLine();
        IEnumerable<string> arrLynq = from a in arr
            where a.Length > 2
            orderby a
            select a;
        foreach (var l in arrLynq)
        {
            Console.Write(l + " ");
        }
       /* 
        var numberOfSales = int.Parse(Console.ReadLine());
        var sales = new SortedDictionary<string, Sale>();
        for (int i = 0; i < numberOfSales; i++)
        {
            var sale = Console.ReadLine().Split(' ').ToArray();
            if (sales.ContainsKey(sale[0]))
            {
                sales[sale[0]].products.Add(new Product(sale[1], double.Parse(sale[2]), double.Parse(sale[3])));
            }
            else
            {
                sales.Add(sale[0], new Sale());
                sales[sale[0]].products.Add(new Product(sale[1], double.Parse(sale[2]), double.Parse(sale[3])));
            }
        }
        //sales = sales.OrderBy(x => x).ToDictionary();
        foreach (var town in sales)
        {
            Console.WriteLine($"{town.Key} -> {town.Value.TotalSales():f2}");
        }//*/
    }
}

class Sale
{
    public string Town { get; set; }
    //public string Product { get; set; }
    //public double Price { get; set; }
    public List<Product> products = new List<Product>();

    public double TotalSales()
    {
        double total = 0;
        for (int i = 0; i < products.Count; i++)
        {
            total += products[i].Price*products[i].Quantity;
        }
        return total;
    }
    
}

class Product
{
    public Product(){}

    public Product(string name, double price, double quantity)
    {
        product = name;
        Price = price;
        Quantity = quantity;
    }

    public string product { get; set; }
    public double Price { get; set; }
    public double Quantity { get; set; }

}

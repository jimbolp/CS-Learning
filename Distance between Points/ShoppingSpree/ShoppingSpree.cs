using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    class Person
    {
        string name = "";
        uint money;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public uint Money
        {
            get
            {
                return money;
            }
        }
        List<Product> Bag = new List<Product>();
        public Person(string name, uint money)
        {
            this.name = name;
            this.money = money;
        }
        public void Buy(Product prod)
        {
            if (prod.Price <= money)
            {
                Bag.Add(prod);
                money -= prod.Price;
                Console.WriteLine($"{Name} bought {prod.Name}");
            }
            else
            {
                throw new InvalidOperationException($"{name} can't afford {prod.Name}");
            }
        }
        public void CheckBag()
        {
            if(Bag.Count == 0)
            {
                Console.WriteLine($"{Name} - Nothing bought");
            }
            else
            {
                Console.WriteLine($"{Name} - {string.Join(", ", Bag)}");                
            }
        }
    }
    class Product
    {
        public string Name { get; }
        public uint Price { get; }
        
        public Product(string name, uint price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    class ShoppingSpree
    {
        static void Main(string[] args)
        {
            string[] inputPeople = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                people = InitializePeople(inputPeople);
                products = InitializeProducts(inputProducts);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            string shop = Console.ReadLine();
            while(shop != "END" && shop != Environment.NewLine )
            {
                string[] temp = shop.Split();
                try
                {
                    Person person = people.Where(p => p.Name == temp[0]).FirstOrDefault();
                    person.Buy(products.Where(pr => pr.Name == temp[1]).FirstOrDefault());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                shop = Console.ReadLine();
            }
            foreach(var person in people)
            {
                person.CheckBag();
            }
        }
        /// <summary>
        /// Разделя input-a, проверява дали Името и Парите са валидни стойности и създава обект за всеки input.
        /// Хвърля Exception ако стойностите не са валидни
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static List<Person> InitializePeople(string[] input)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < input.Length; ++i)
            {
                string[] temp = input[i].Split(new char[] { '=' });
                if(string.IsNullOrEmpty(temp[0]))
                {
                    throw new Exception("Name cannot be empty");
                }
                uint money;
                if (uint.TryParse(temp[1], out money))
                {
                    people.Add(new Person(temp[0], money));
                }
                else
                {
                    throw new Exception("Money cannot be negative");
                }
            }
            return people;
        }
        /// <summary>
        /// Разделя input-a, проверява дали Името и Цената са валидни стойности и създава обект за всеки input.
        /// Хвърля Exception ако стойностите не са валидни
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static List<Product> InitializeProducts(string[] input)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < input.Length; ++i)
            {
                string[] temp = input[i].Split(new char[] { '=' });
                if (string.IsNullOrEmpty(temp[0]))
                {
                    throw new Exception("Name cannot be empty");
                }
                uint price;
                if (uint.TryParse(temp[1], out price))
                {
                    products.Add(new Product(temp[0], price));
                }
                else
                {
                    throw new Exception("Money cannot be negative");
                }
            }
            return products.ToList();
        }
    }
}

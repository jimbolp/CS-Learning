using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FW
{
    class Program
    {
        static void Main(string[] args)
        {
            var BlogDB = new BlogDBContext();
            var posts = BlogDB.Posts.Select(p => new
            {
                ID = p.ID,
                Title = p.Title,
                Post = p.Body,
                Date = p.Date,
                Comments = p.Comments.ToList()
            });
            foreach (var p in posts)
            {
                Console.WriteLine($"Post ID - {p.ID} - {p.Date}\n\b {p.Title}\n\t {p.Post}\n {string.Join("\t ", p.Comments.ToList())}");
            }
            /*
            IQueryable query = BlogDB.Posts.Where(p => p.Date.Value.Year == 2016);
            //Console.WriteLine(query);
            Console.WriteLine("ID" + new string(' ', 3) + "| " + "UserName" + new string(' ', 7) + "| " + "FullName" + new string(' ', 7));
            foreach (var user in BlogDB.Users)
            {
                Console.WriteLine(user);
            }//*/
        }
    }
}

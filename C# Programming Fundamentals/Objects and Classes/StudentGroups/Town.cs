using System.Collections.Generic;
using System.Linq;

namespace StudentGroups
{
    public class Town
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public string Name { get; set; }

        public int NumberOfSeats { get; set; }

        public Town(string name, int seats)
        {
            Name = name;
            NumberOfSeats = seats;
        }

        public void SortStudents()
        {
            Students = Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Name).ThenBy(x => x.Email).ToList();
        }
        
    }
}
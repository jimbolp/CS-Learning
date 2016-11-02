using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups
{
    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public Group(Town town)
        {
            Town = town;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Xml;

namespace StudentGroups
{
    class StudentGroups
    {
        static void Main(string[] args)
        {
            string endOfInput;
            List<Town> towns = new List<Town>();
            Input(out endOfInput, ref towns);
            
            while (endOfInput != "End")
            {
                Input(out endOfInput, ref towns);
            }
            foreach (var t in towns)
            {
                t.SortStudents();
            }
            List<Group> groups = new List<Group>();
            DevideStudentsByGroups(ref towns, ref groups);
            groups = groups.OrderBy(x => x.Town.Name).ToList();
            
            Output(groups);
        }

        private static void Output(List<Group> groups )
        {
            Console.WriteLine($"Created {groups.Count} groups in {groups.Select(x => x.Town).Distinct().Count()} towns:");
            foreach (var g in groups)
            {
                Console.WriteLine($"{g.Town.Name} => {string.Join(", ", g.Students.Select(x => x.Email).ToArray())}");
            }
        }

        private static void DevideStudentsByGroups(ref List<Town> towns, ref List<Group> groups)
        {
            foreach (Town t in towns)
            {
                groups.Add(new Group(t));
                for (int i = 0; i < t.Students.Count; ++i)
                {
                    if (groups.Last().Students.Count < t.NumberOfSeats)
                        groups.Last().Students.Add(t.Students[i]);
                    else
                    {
                        groups.Add(new Group(t));
                        groups.Last().Students.Add(t.Students[i]);
                    }
                }
            }
        }

        private static void Input(out string end, ref List<Town> towns)
        {
            string unformatedInput = Console.ReadLine();
            if (unformatedInput.Contains("=>"))
            {
                end = null;
                string[] input = unformatedInput.Split(new[] {"=>"}, StringSplitOptions.RemoveEmptyEntries);
                AddTown(input, ref towns);
            }
            else if (unformatedInput.Contains("|"))
            {
                end = null;
                string[] input = unformatedInput.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                AddStudent(input, ref towns);
            }
            end = unformatedInput;
            
        }

        private static void AddStudent(string[] input, ref List<Town> towns )
        {
            DateTime register;
            if (DateTime.TryParseExact(input[2].Trim(), "dd-MMM-yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault,
                out register))
            {
                towns.Last().Students.Add(new Student(input[0].Trim(),
                input[1].Trim(), register));
            }
            else if(DateTime.TryParseExact(input[2].Trim(), "d-MMM-yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault,
                out register))
            {
                towns.Last().Students.Add(new Student(input[0].Trim(),
                input[1].Trim(), register));
            }
            
        }

        private static void AddTown(string[] input, ref List<Town> towns)
        {
            towns.Add(new Town(input[0].Trim(), int.Parse(input[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0])));
        }
      //Add the other classes for Judge Check HERE______________
        
        
    }
}

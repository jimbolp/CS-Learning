using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class MentorGroup
{
    static void Main(string[] args)
    {
        List<Mentor> mentors = new List<Mentor>();
        TakeInput(mentors, "mentor", "end of dates");
        TakeInput(mentors, "comment", "end of comments");
        
        mentors = mentors.OrderBy(x => x.MentorName).ToList();
        //Console.WriteLine();
        foreach (Mentor m in mentors)
        {
            m.OrderAttendingsByDate();
        }
       
        PrintFormatedOutput(mentors);
    }

    public static void TakeInput(List<Mentor> mentors, string inputType, string endString )
    {
        string temp = Console.ReadLine();
        if (inputType == "mentor")
        {
            while (temp != endString)
            {
                string[] input = temp.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                //if (input.Length < 2)
                //{
                    //temp = Console.ReadLine();
                    //continue;
                //}
                //else
                //{
                    AddMentor(input, mentors);
                    temp = Console.ReadLine();
                //}
            }
        }
        else if (inputType == "comment")
        {
            while (temp != endString)
            {
                string[] input = temp.Split( new [] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                if (input.Length < 2)
                {
                    temp = Console.ReadLine();
                    continue;
                }
                else
                    AddComment(input, mentors);
                //if (!AddComment(input, mentors))
                  //  Console.WriteLine($"{input[0]} is not in the list of attending mentors");
                temp = Console.ReadLine();
            }
        }
    }

    public static void PrintFormatedOutput(List<Mentor> listToPrint)
    {
        foreach (Mentor m in listToPrint)
        {
            Console.WriteLine($"{m.MentorName}{Environment.NewLine}Comments:");
            foreach (string comment in m.Comment)
            {
                Console.WriteLine($"- {comment}");
            }
            Console.WriteLine("Dates attended:");
            foreach (DateTime date in m.AttendingDateTimes)
            {
                Console.WriteLine($"-- {date.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture)}");
            }
        }
    }
    public static bool AddComment(string[] input, List<Mentor> mentors)
    {
        foreach (Mentor m in mentors)
        {
            if (m.MentorName == input[0])
            {
                m.Comment.Add(input[1]);
                return true;
            }
        }
        return false;
    }
    public static void AddMentor(string[] input, List<Mentor> mentors )
    {
        if (input.Length == 1)
            mentors.Add(new Mentor(input[0]));
        else
        {
            for (int i = 1; i < input.Length; i++)
            {
                bool exist = false;
                int mIndex = 0;
                foreach (Mentor m in mentors)
                {
                    if (m.MentorName == input[0])
                    {
                        mIndex = mentors.IndexOf(m);
                        exist = true;
                    }
                }
                if (exist)
                {
                    mentors[mIndex].AttendingDateTimes.Add(DateTime.ParseExact(input[i], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None));
                }
                else
                    mentors.Add(new Mentor(input[0], DateTime.ParseExact(input[i], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)));
            }
        }
        
    }
    public class Mentor
    {
        public string MentorName { get; set; }
        public List<DateTime> AttendingDateTimes { get; set; } = new List<DateTime>();
        public List<string> Comment { get; set; } = new List<string>();

        public Mentor(string name)
        {
            MentorName = name;
        }
        public Mentor(string name, DateTime attendingDateTimes)
        {
            MentorName = name;
            AttendingDateTimes.Add(attendingDateTimes);
        }

        public Mentor(string name, string comment)
        {
            MentorName = name;
            Comment.Add(comment);
        }

        public void OrderAttendingsByDate()
        {
            AttendingDateTimes = AttendingDateTimes.OrderBy(x => x).ToList();
        }

    }
}
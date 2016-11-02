using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class TeamworkProjects
{
    static void Main(string[] args)
    {
        //File.WriteAllText("output.txt", "");
        int numberOfTeams = int.Parse(Console.ReadLine());
        string tempInput = Console.ReadLine();
        List<Team> teams = new List<Team>();
        int inputCounter = 0;
        while (tempInput != "end of assignment")
        {
            if(inputCounter < numberOfTeams) { 
                string[] input = tempInput.Split('-');
                if (teams.Any(t => t.TeamName == input[1]))
                {
                    Console.Write($"Team {input[1]} was already created!{Environment.NewLine}");
                    inputCounter++;
                    tempInput = Console.ReadLine();
                    continue;
                }
                if (teams.Any(t => t.TeamCreatorName == input[0]))
                {
                    Console.Write($"{input[0]} cannot create another team!{Environment.NewLine}");
                    inputCounter++;
                    tempInput = Console.ReadLine();
                    continue;
                }
                teams.Add(new Team(input[0], input[1]));
                inputCounter++;
                tempInput = Console.ReadLine();
            }
            else
            {
                string[] input = tempInput.Split(new [] {"->"},StringSplitOptions.None);
                if (teams.All(x => x.MemberList.Contains(input[0])))
                {
                    Console.Write($"Member {input[0]} cannot join team {input[1]}!{Environment.NewLine}");
                    tempInput = Console.ReadLine();
                }
                else
                {
                    bool exists = false;
                    foreach (Team t in teams)
                    {
                        if (t.TeamName == input[1])
                        {
                            try
                            {
                                exists = true;
                                t.AddMember(input[0]);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine( $"{e.Message}");
                            }
                        }
                    }
                    if(!exists)
                        Console.Write($"Team {input[1]} does not exist!{Environment.NewLine}");
                    tempInput = Console.ReadLine();
                }
            }
        }
        
        teams = teams.OrderByDescending(x => x.MemberList.Count).ThenBy(x=>x.TeamName).ToList();
        //teams = teams.OrderBy(x => x.TeamName).ToList();
        foreach (Team t in teams)
        {
            t.SortMembers();
            if (t.MemberList.Count > 1)
            {
                Console.Write($"{t.TeamName}{Environment.NewLine}- {t.TeamCreatorName}\n");
                foreach (string m in t.MemberList)
                {
                    if (m != t.TeamCreatorName)
                        Console.Write($"-- {m}{Environment.NewLine}");
                }
            }
        }
        Console.Write($"Teams to disband:{Environment.NewLine}");
        //List<Team> disbandedTeams = new List<Team>();
        teams.All(x => x.SortMembers());
        foreach (Team t in teams)
        {
            if (t.MemberList.Count <= 1)
                Console.WriteLine($"{t.TeamName}");
        }
        
    }

    public class Team
    {
        string _teamName;
        string _teamCreatorName;
        List<string> _memberList = new List<string>();
        
        public List<string> MemberList => _memberList;
        //properties
        public string TeamName => _teamName;
        public string TeamCreatorName => _teamCreatorName;
        //constructor
        public Team(string creatorName, string name)
        {
            _teamName = name;
            _teamCreatorName = creatorName;
            MemberList.Add(_teamCreatorName);
            Console.WriteLine($"Team {TeamName} has been created by {TeamCreatorName}!");
        }
        public void AddMember(string memberToAdd)
        {
            if (_memberList.Contains(memberToAdd))
            {
                throw new ArgumentException($"Member {memberToAdd} cannot join team {TeamName}!");
            }
            _memberList.Add(memberToAdd);
        }

        public bool SortMembers()
        {
            _memberList = MemberList.OrderBy(x => x).ToList();
            return true;
        }
    }
}


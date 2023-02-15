using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Collections.Concurrent;

namespace AdvertismentMessage
{
    class TeamworkProjects
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 1; i <= lines; i++)
            {
                string[] teamCreateLine = Console.ReadLine()
                .Split("-")
                .ToArray();

                List<string> membersList = new List<string>();

                Team team = new Team
                {
                    Creator = teamCreateLine[0],
                    TeamName = teamCreateLine[1],
                    Members = membersList
                };
                if (!teams.Select(x => x.TeamName).Contains(team.TeamName))
                {
                    if (!teams.Select(x => x.Creator).Contains(team.Creator))
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {teamCreateLine[1]} has been created by {teamCreateLine[0]}!");
                    }
                    else
                    {
                        Console.WriteLine($"{team.Creator} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {team.TeamName} was already created!");
                }
            }

            string teamRegistration = Console.ReadLine();

            while (teamRegistration != "end of assignment")
            {
                string[] lineSplit = teamRegistration
                    .Split("->")
                    .ToArray();

                string newUser = lineSplit[0];
                string teamName = lineSplit[1];

                if (!teams.Select(x => x.TeamName).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Select(x => x.Members).Any(x => x.Contains(newUser)) || teams.Select(x => x.Creator).Contains(newUser))
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
                }
                else
                {
                    int teamToJoinIndex = teams.FindIndex(x => x.TeamName == teamName);
                    teams[teamToJoinIndex].Members.Add(newUser);
                }

                teamRegistration = Console.ReadLine();
            }

            var teamsToDisband = teams.OrderBy(x => x.TeamName)
                .Where(x => x.Members.Count == 0);

            var fullTeams = teams.OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .Where(x => x.Members.Count > 0);

            foreach (var team in fullTeams)
            {
                Console.WriteLine($"{team.TeamName}");

                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var item in teamsToDisband)
            {
                Console.WriteLine(item.TeamName);
            }
        }
    }

    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
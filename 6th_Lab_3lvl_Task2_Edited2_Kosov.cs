using System;
using System.Linq;
using System.Collections.Generic;

struct Team
{
    public string Name;
    public int Points;

    public Team(string name, int points)
    {
        Name = name;
        Points = points;
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();

        Team[] group1 = {
            new Team("Команда1", random.Next(10)),
            new Team("Команда2", random.Next(10)),
            new Team("Команда3", random.Next(10)),
            new Team("Команда4", random.Next(10)),
            new Team("Команда5", random.Next(10)),
            new Team("Команда6", random.Next(10)),
            new Team("Команда7", random.Next(10)),
            new Team("Команда8", random.Next(10)),
            new Team("Команда9", random.Next(10)),
            new Team("Команда10", random.Next(10)),
            new Team("Команда11", random.Next(10)),
            new Team("Команда12", random.Next(10))
        };

        Team[] group2 = {
            new Team("Команда13", random.Next(10)),
            new Team("Команда14", random.Next(10)),
            new Team("Команда15", random.Next(10)),
            new Team("Команда16", random.Next(10)),
            new Team("Команда17", random.Next(10)),
            new Team("Команда18", random.Next(10)),
            new Team("Команда19", random.Next(10)),
            new Team("Команда20", random.Next(10)),
            new Team("Команда21", random.Next(10)),
            new Team("Команда22", random.Next(10)),
            new Team("Команда23", random.Next(10)),
            new Team("Команда24", random.Next(10))
        };

        var orderedTeamsGroup1 = group1.OrderByDescending(t => t.Points);
        var orderedTeamsGroup2 = group2.OrderByDescending(t => t.Points);

        var combinedAndOrderedTeams = orderedTeamsGroup1.Concat(orderedTeamsGroup2);

        foreach (var team in combinedAndOrderedTeams)
        {
            Console.WriteLine($"{team.Name} – {team.Points}");
        }

        
        Console.ReadKey();
    }
}
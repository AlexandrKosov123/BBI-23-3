using System;
using System.Linq;

struct Team
{
    public readonly string Name;

    public Team(string name)
    {
        Name = name;
    }
}

class Program
{
    static void Main()
    {
        Team[] group1 = {
            new Team("Команда1"),
            new Team("Команда2"),
            new Team("Команда3"),
            new Team("Команда4"),
            new Team("Команда5"),
            new Team("Команда6"),
            new Team("Команда7"),
            new Team("Команда8"),
            new Team("Команда9"),
            new Team("Команда10"),
            new Team("Команда11"),
            new Team("Команда12")
        };

        Team[] group2 = {
            new Team("Команда13"),
            new Team("Команда14"),
            new Team("Команда15"),
            new Team("Команда16"),
            new Team("Команда17"),
            new Team("Команда18"),
            new Team("Команда19"),
            new Team("Команда20"),
            new Team("Команда21"),
            new Team("Команда22"),
            new Team("Команда23"),
            new Team("Команда24")
        };

        var bestTeamsGroup1 = group1.OrderByDescending(team => team.Name).Take(6);
        var bestTeamsGroup2 = group2.OrderByDescending(team => team.Name).Take(6);

        var finalTeams = bestTeamsGroup1.Concat(bestTeamsGroup2);

        int pageNumber = 1;
        foreach (var team in finalTeams)
            Console.WriteLine($"Страница {pageNumber++}: {team.Name}");

        Console.ReadKey();
    }
}

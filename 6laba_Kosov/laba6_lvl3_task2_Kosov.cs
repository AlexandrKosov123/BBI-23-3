using System;
using System.Linq; 

class Program
{
    static void Main()
    {
        
        string[] group1 = { "Команда1", "Команда2", "Команда3" , "Команда4" , "Команда5", "Команда6", "Команда7", "Команда8", "Команда9", "Команда10", "Команда11", "Команда12" };
        string[] group2 = { "Команда13", "Команда14", "Команда15", "Команда16", "Команда17", "Команда18", "Команда19", "Команда20", "Команда21", "Команда22", "Команда23", "Команда24" };

        
        var BestTeamsGroup1 = group1.OrderByDescending(team => team).Take(6);
        var BestTeamsGroup2 = group2.OrderByDescending(team => team).Take(6);

 
        var finalTeams = BestTeamsGroup1.Concat(BestTeamsGroup2);

        int pageNumber = 1;
        foreach (var team in finalTeams)
            Console.WriteLine($"Страница {pageNumber++}: {team}");

        Console.ReadKey();
    }
}
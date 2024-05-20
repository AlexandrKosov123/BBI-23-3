﻿using System;
using System.Collections.Generic;
using System.Linq;

// Задание: 1.	Добавить поле «дисквалификация» и метод, который позволяет дисквалифицировать участника. В итоговую таблицу такие участники входить не должны. 
public class Jumper
{
    public string Name { get; set; }
    public string Club { get; set; }
    public int FirstTry { get; set; }
    public int SecondTry { get; set; }
    public bool IsDisqualified { get; private set; }

    public Jumper(string name, string club, int firstTry, int secondTry)
    {
        Name = name;
        Club = club;
        FirstTry = firstTry;
        SecondTry = secondTry;
    }

    public void Disqualify()
    {
        IsDisqualified = true;
    }
}

public class Program
{
    public static void Main()
    {
        List<Jumper> jumpers = new List<Jumper>
        {
            new Jumper("Jesse Pinkman", "LosPolos", 10, 12),
            new Jumper("Walter White", "Hermanos", 15, 10)
        };

        var orderedJumpers = jumpers.OrderByDescending(j => j.FirstTry + j.SecondTry).Where(j => !j.IsDisqualified);

        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Place", "Name", "Club", "First Try", "Second Try");

        int place = 1;
        foreach (var jumper in orderedJumpers)
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", place++, jumper.Name, jumper.Club, jumper.FirstTry, jumper.SecondTry);
        }
    }
}
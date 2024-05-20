using System;
using System.Collections.Generic;
using System.Linq;

// Задание: 1.	Сделать класс «Человек». Класс студент должен наследоваться от него, и иметь дополнительное поле «№ студ. билета». При выводе в таблице должны быть ФИО, № студ. билета и средний балл.
class Person
{
    protected string _firstName;
    protected string _lastName;
    protected string _middleName;

    public string FullName
    {
        get
        {
            return $"{_lastName} {_firstName[0]} {_middleName[0]}.";
        }
    }

    public Person(string lastName, string firstName, string middleName)
    {
        _lastName = lastName;
        _firstName = firstName;
        _middleName = middleName;
    }
}

class Student : Person
{
    public int StudyTicketNumber { get; private set; }

    public double AverageScore { get; private set; }

    public Student(string lastName, string firstName, string middleName, int studyTicketNumber) : base(lastName, firstName, middleName)
    {
        StudyTicketNumber = studyTicketNumber;
        AverageScore = 88;
    }
}

class SessionResults
{
    public List<Person> Results { get; private set; }

    public SessionResults()
    {
        Results = new List<Person>();
    }

    public void AddGroupResults(Person result)
    {
        Results.Add(result);
    }

    public double GetAverageForGroup(Person p)
    {
        if (p is Student s)
        {
            return (double)s.AverageScore;
        }
        throw new InvalidCastException($"Unable to cast '{p}' to type 'Student'.");
    }

    public void PrintResults()
    {
        Console.WriteLine("{0,-20}{1,-10}{2,-10}", "ФИО", "# студ. билета", "Средний балл");

        foreach (var person in Results.OfType<Student>().OrderByDescending(p => GetAverageForGroup(p)))
        {
            Console.WriteLine("{0,-20}{1,-10}{2,-10:F2}", person.FullName, person.StudyTicketNumber, GetAverageForGroup(person));
        }
    }
}

class Program
{
    static void Main()
    {
        SessionResults sessionResults = new SessionResults();

        // Добавляем студентов в объект sessionResults
        sessionResults.AddGroupResults(new Student("Иванов", "Иван", "Иванович", 12345));
        sessionResults.AddGroupResults(new Student("Петров", "Пётр", "Петрович", 67890));
        sessionResults.AddGroupResults(new Student("Сидоров", "Сидр", "Сидорович", 11111));

        sessionResults.PrintResults();

        Console.ReadLine();
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

class GroupResult
{
    public string GroupName { get; private set; }
    public int SumOfGradePoints { get; private set; }
    public int StudentsCount { get; private set; }
    public int ExamsCount { get; private set; }
    public double AverageGradePoint { get; private set; }

    public GroupResult(string groupName, int sumOfGradePoints, int studentsCount, int examsCount)
    {
        GroupName = groupName;
        SumOfGradePoints = sumOfGradePoints;
        StudentsCount = studentsCount;
        ExamsCount = examsCount;
        CalculateAverageGradePoint();
    }

    private void CalculateAverageGradePoint()
    {
        AverageGradePoint = (double)SumOfGradePoints / (ExamsCount * StudentsCount);
    }
}

class SessionResults
{
    public List<GroupResult> Results { get; private set; }

    public SessionResults()
    {
        Results = new List<GroupResult>();
    }

    public void AddGroupResults(GroupResult result)
    {
        Results.Add(result);
    }

    public void PrintResults()
    {
        Console.WriteLine("{0,-20}{1,-10}", "Название группы", "Средний балл");

        GnomeSortResults();

        foreach (var gr in Results)
        {
            Console.WriteLine("{0,-20}{1,-10:F2}", gr.GroupName, gr.AverageGradePoint);
        }
    }

    private void GnomeSortResults()
    {
        int index = 0;
        while (index < Results.Count)
        {
            if (index == 0)
                index++;
            if (Results[index].AverageGradePoint <= Results[index - 1].AverageGradePoint)
            {
                index++;
            }
            else
            {
                SwapResults(index, index - 1);
                if (index > 1) 
                    index--; // Переходим к предыдущему индексу для проверки снова
            }
        }
    }

}

class Program
{
    static void Main()
    {
        SessionResults sessionResults = new SessionResults();

        // Группа 1
        int[] gradesGroup1 = Enumerable.Repeat(5, 30).ToArray(); // 30 студентов, все получат оценку 5
        sessionResults.AddGroupResults(new GroupResult("Группа 1", gradesGroup1.Sum(), 30, 5));

        // Группа 2
        Random rnd = new Random();
        int[] gradesGroup2 = new int[25]; // 25 студентов
        for (int i = 0; i < gradesGroup2.Length; i++)
        {
            gradesGroup2[i] = rnd.Next(2, 6);
        }
        sessionResults.AddGroupResults(new GroupResult("Группа 2", gradesGroup2.Sum(), 25, 5));

        // Группа 3
        int[] gradesGroup3 = { 4, 5, 4, 5, 3, 5, 4, 3, 5, 4, 4, 5, 4, 4, 5, 4, 3, 4, 5, 3, 4, 5, 5, 5, 4, 4 }; // 25 студентов
        sessionResults.AddGroupResults(new GroupResult("Группа 3", gradesGroup3.Sum(), 25, 5));

        sessionResults.PrintResults();

        Console.ReadLine();
    }
}


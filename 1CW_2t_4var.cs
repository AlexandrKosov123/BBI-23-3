/* Вариант 4.
   Задача 1.
*/

using System;
using System.Linq;

struct Triangle
{
    public double[] sides;

    public Triangle(double[] sides)
    {
        if (sides.Length != 3)
            throw new ArgumentException("Triangle must have exactly 3 sides");
        this.sides = sides;
    }

    public string Type()
    {
        if (sides[0] == sides[1] && sides[1] == sides[2])
            return "Равносторонний";
        else if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2])
            return "Равнобедренный";
        else
            return "Разносторонний";
    }

    public double Area()
    {
        double p = sides.Sum() / 2.0;
        return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Длины сторон: {sides[0]}, {sides[1]}, {sides[2]}");
        Console.WriteLine($"Площадь: {Area()}");
        Console.WriteLine($"Тип: {Type()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Triangle[] triangles = new Triangle[5];

        // Заполнение массива треугольников
        triangles[0] = new Triangle(new double[] { 3, 4, 5 });
        triangles[1] = new Triangle(new double[] { 5, 5, 5 });
        triangles[2] = new Triangle(new double[] { 4, 4, 3 });
        triangles[3] = new Triangle(new double[] { 6, 8, 10 });
        triangles[4] = new Triangle(new double[] { 7, 24, 25 });

        // Сортировка массива по уменьшению площади
        Array.Sort(triangles, (x, y) => x.Area().CompareTo(y.Area()));

        // Вывод информации о треугольниках в виде таблицы
        Console.WriteLine("Треугольники, отсортированные по уменьшению площади:");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("|   Длины сторон   |   Площадь   |   Тип   |");
        Console.WriteLine("--------------------------------------------------");
        foreach (var triangle in triangles)
        {
            Console.Write($"|   {triangle.sides[0]}, {triangle.sides[1]}, {triangle.sides[2]}   ");
            Console.Write($"|   {triangle.Area()}   ");
            Console.Write($"|   {triangle.Type()}   |\n");
        }
        Console.WriteLine("--------------------------------------------------");
    }
}

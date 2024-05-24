// КР1. Вариант 4. Задача 2.

using System;
using System.Linq;

abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

class Round : Shape
{
    private double radius;

    public Round(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
}

class Square : Shape
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public override double CalculateArea()
    {
        return side * side;
    }

    public override double CalculatePerimeter()
    {
        return 4 * side;
    }
}

class Triangle : Shape
{
    private double a, b, c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double CalculateArea()
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public override double CalculatePerimeter()
    {
        return a + b + c;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[]
        {
            new Round(5),
            new Round(3),
            new Round(7),
            new Round(2),
            new Round(4),
            new Square(4),
            new Square(3),
            new Square(5),
            new Square(2),
            new Square(6),
            new Triangle(3, 4, 5),
            new Triangle(6, 8, 10),
            new Triangle(5, 12, 13),
            new Triangle(8, 15, 17),
            new Triangle(7, 24, 25)
        };

        Console.WriteLine("Таблица: Название фигуры, Периметр, Площадь\n");

        var sortedByArea = shapes.OrderBy(s => s.CalculateArea()).ToList();

        PrintTable(sortedByArea);

        Console.ReadLine();
    }

    static void PrintTable(List<Shape> shapes)
    {
        Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Фигура", "Периметр", "Площадь");
        foreach (var shape in shapes)
        {
            Console.WriteLine("{0,-10} {1,-10:F2} {2,-10:F2}", shape.GetType().Name, shape.CalculatePerimeter(), shape.CalculateArea());
        }
    }
}

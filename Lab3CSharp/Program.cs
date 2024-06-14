using System;
using System.Collections.Generic;
using System.Linq;

// Завдання 1
class Point
{
    protected int x;
    protected int y;
    protected int c;

    // Конструктор з нульовими координатами
    public Point()
    {
        x = 0;
        y = 0;
        c = 0; // Default color value
    }

    // Конструктор із заданими координатами
    public Point(int x, int y, int c)
    {
        this.x = x;
        this.y = y;
        this.c = c;
    }

    // Властивості для координат точки
    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    // Властивість для кольору точки (тільки для читання)
    public int Color
    {
        get { return c; }
    }

    // Метод для виведення координат точки
    public void PrintCoordinates()
    {
        Console.WriteLine($"Point Coordinates: ({x}, {y}), Color: {c}");
    }

    // Метод для розрахунку відстані від початку координат до точки
    public double DistanceFromOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }

    // Метод для переміщення точки на вектор з координатами (x1, y1)
    public void Move(int x1, int y1)
    {
        x += x1;
        y += y1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Завдання 1
        List<Point> points = new List<Point>
        {
            new Point(3, 4, 1),
            new Point(6, 8, 2),
            new Point(1, 1, 3),
            new Point(0, 2, 4)
        };

        // Виведемо інформацію про кожну точку
        foreach (var point in points)
        {
            point.PrintCoordinates();
            Console.WriteLine($"Distance from Origin: {point.DistanceFromOrigin()}");
        }

        // Обчислимо середню відстань
        double averageDistance = points.Average(p => p.DistanceFromOrigin());
        Console.WriteLine($"Average Distance: {averageDistance}");

        // Перемістимо точки, які знаходяться більше середньої відстані, на вектор (1, 1)
        foreach (var point in points.Where(p => p.DistanceFromOrigin() > averageDistance))
        {
            point.Move(1, 1);
        }

        Console.WriteLine("\nAfter moving points:");
        foreach (var point in points)
        {
            point.PrintCoordinates();
        }

        // Завдання 2
        List<Person> people = new List<Person>
        {
            new Student("Alice", 20, "S12345"),
            new Teacher("Bob", 45, "Mathematics"),
            new HeadOfDepartment("Charlie", 50, "Physics", "Science Department"),
            new Student("Dave", 22, "S67890"),
            new Teacher("Eve", 38, "Chemistry")
        };

        // Виведемо інформацію про всіх людей
        foreach (var person in people)
        {
            person.Show();
            Console.WriteLine();
        }

        // Впорядкуємо масив за віком
        var sortedPeople = people.OrderBy(p => p.Age).ToList();
        Console.WriteLine("Sorted by Age:");
        foreach (var person in sortedPeople)
        {
            person.Show();
            Console.WriteLine();
        }
    }
}

// Завдання 2
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Student : Person
{
    public string StudentID { get; set; }

    public Student(string name, int age, string studentID) : base(name, age)
    {
        StudentID = studentID;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Student ID: {StudentID}");
    }
}

class Teacher : Person
{
    public string Subject { get; set; }

    public Teacher(string name, int age, string subject) : base(name, age)
    {
        Subject = subject;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Subject: {Subject}");
    }
}

class HeadOfDepartment : Teacher
{
    public string Department { get; set; }

    public HeadOfDepartment(string name, int age, string subject, string department)
        : base(name, age, subject)
    {
        Department = department;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Department: {Department}");
    }
}

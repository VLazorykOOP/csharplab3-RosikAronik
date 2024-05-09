using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Student : Person
{
    public string StudentID { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Student ID: {StudentID}, Name: {Name}, Age: {Age}");
    }
}

class Teacher : Person
{
    public string Subject { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Subject: {Subject}, Name: {Name}, Age: {Age}");
    }
}

class DepartmentHead : Teacher
{
    public string Department { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Department: {Department}, Subject: {Subject}, Name: {Name}, Age: {Age}");
    }
}

class Point
{
    protected int x;
    protected int y;
    protected readonly int color;

    public Point()
    {
        x = 0;
        y = 0;
        color = 0; 
    }

    public Point(int x, int y, int color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    public void DisplayCoordinates()
    {
        Console.WriteLine($"Coordinates: ({x}, {y}), Color: {color}");
    }

    public double DistanceToOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void Move(int x1, int y1)
    {
        x += x1;
        y += y1;
    }

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

    public int Color
    {
        get { return color; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        people.Add(new Student { Name = "John", Age = 20, StudentID = "S001" });
        people.Add(new Teacher { Name = "Jane", Age = 35, Subject = "Math" });
        people.Add(new DepartmentHead { Name = "David", Age = 45, Subject = "Physics", Department = "Science" });

        people.Sort((p1, p2) => string.Compare(p1.Name, p2.Name));

        Console.WriteLine("People:");
        foreach (var person in people)
        {
            person.Show();
        }

        Point point = new Point(3, 4, 255);
        Console.WriteLine("\nPoint:");
        point.DisplayCoordinates();
        Console.WriteLine($"Distance to origin: {point.DistanceToOrigin()}");
    }
}
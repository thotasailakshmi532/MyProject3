using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "D:\\Practices Exercise\\.net\\MyProject3\\studentdata.txt"; // Path of text file

        List<Student> students = ReadStudentData(filePath);

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display all students");
            Console.WriteLine("2. Search for a student by name");
            Console.WriteLine("3. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayStudents(students);
                    break;
                case 2:
                    Console.Write("Enter the name to search: ");
                    string searchName = Console.ReadLine();
                    SearchStudentByName(students, searchName);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }

    static List<Student> ReadStudentData(string filePath)
    {
        List<Student> students = new List<Student>();

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2)
            {
                string name = parts[0].Trim();
                string className = parts[1].Trim();
                students.Add(new Student(name, className));
            }
        }

        return students.OrderBy(s => s.Name).ToList();
    }

    static void DisplayStudents(List<Student> students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine($"{student.Name}, {student.Class}");
        }
    }

    static void SearchStudentByName(List<Student> students, string name)
    {
        var searchResults = students.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();
        if (searchResults.Any())
        {
            Console.WriteLine("Search results:");
            DisplayStudents(searchResults);
        }
        else
        {
            Console.WriteLine("No students found with the given name.");
        }
    }
}

class Student
{
    public string Name { get; }
    public string Class { get; }

    public Student(string name, string className)
    {
        Name = name;
        Class = className;
    }
}

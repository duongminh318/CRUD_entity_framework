using CRUD_entity_framework;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Update Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    UpdateStudent();
                    break;
                case "3":
                    DeleteStudent();
                    break;
                case "4":
                    ListStudents();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void AddStudent()
    {
        using (var context = new SchoolContext())
        {
            Console.Write("Enter student name: ");
            var name = Console.ReadLine();

            Console.Write("Enter student score: ");
            if (!double.TryParse(Console.ReadLine(), out var score))
            {
                Console.WriteLine("Invalid score. Please enter a valid number.");
                return;
            }

            var student = new Student { Name = name, Score = score };
            context.Students.Add(student);
            context.SaveChanges();

            Console.WriteLine("Student added successfully.");
        }
    }

    private static void UpdateStudent()
    {
        using (var context = new SchoolContext())
        {
            Console.Write("Enter student ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            var student = context.Students.Find(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter new name (leave blank to keep current): ");
            var newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                student.Name = newName;
            }

            Console.Write("Enter new score (leave blank to keep current): ");
            if (double.TryParse(Console.ReadLine(), out var newScore))
            {
                student.Score = newScore;
            }

            context.SaveChanges();
            Console.WriteLine("Student updated successfully.");
        }
    }

    private static void DeleteStudent()
    {
        using (var context = new SchoolContext())
        {
            Console.Write("Enter student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            var student = context.Students.Find(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            context.Students.Remove(student);
            context.SaveChanges();
            Console.WriteLine("Student deleted successfully.");
        }
    }

    private static void ListStudents()
    {
        using (var context = new SchoolContext())
        {
            var students = context.Students.ToList();
            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Score: {student.Score}");
            }
        }
    }
}

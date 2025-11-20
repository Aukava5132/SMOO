namespace Lab1;
using System;
using System.Linq;

public class StudentPrinter
{
    public void PrintStudents(Student[] students, string title = "Список студентов:")
    {
        Console.WriteLine($"\n=== {title} ===");
        
        if (students == null || students.Length == 0)
        {
            Console.WriteLine("Студенты не найдены");
            return;
        }

        foreach (var student in students)
        {
            Console.WriteLine($"ФИО: {student.FullName}");
            Console.WriteLine($"Группа: {student.GroupNumber}");
            Console.WriteLine($"Оценки: {string.Join(", ", student.Performance)}");
            Console.WriteLine($"Средний балл: {student.AveragePerformance:F2}");
            Console.WriteLine("---");
        }
    }

    public void PrintStudentSummary(Student[] students)
    {
        Console.WriteLine($"\nВсего студентов: {students.Length}");
        
        if (students != null && students.Length > 0)
        {
            var averageAll = students.Average(s => s.AveragePerformance);
            Console.WriteLine($"Общий средний балл: {averageAll:F2}");
        }
    }
}
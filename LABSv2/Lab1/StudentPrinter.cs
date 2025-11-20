namespace Lab1;
using System;
using System.Linq;

public class StudentPrinter
{
    public void PrintStudents(Student[] students, string title = "Список студентів:")
    {
        Console.WriteLine(title);
        
        if (students == null || students.Length == 0)
        {
            Console.WriteLine("Студенти не знайдені");
            return;
        }

        foreach (Student student in students)
        {
            Console.WriteLine("ПІБ: " + student.FullName);
            Console.WriteLine("Група: " + student.GroupNumber);
            Console.WriteLine("Оцінки: " + string.Join(", ", student.Performance));
            Console.WriteLine("Середній бал: " + student.AveragePerformance.ToString("F2"));
            Console.WriteLine("---");
        }
    }

    public void PrintStudentSummary(Student[] students)
    {
        Console.WriteLine("Всього студентів: " + students.Length);
        
        if (students != null && students.Length > 0)
        {
            double averageAll = students.Average(s => s.AveragePerformance);
            Console.WriteLine("Загальний середній бал: " + averageAll.ToString("F2"));
        }
    }
}
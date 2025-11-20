namespace Lab2;
using System;
using System.Collections.Generic;
using System.IO;

public class StudentCollectionManager
{
    private List<Student> students;

    public StudentCollectionManager()
    {
        students = new List<Student>();
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result >= 0)
                return result;
            Console.WriteLine("Неправильний ввід! Має бути ціле невід'ємне число.");
        }
    }

    private double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (double.TryParse(input, out double result) && result >= 0 && result <= 10)
                return result;
            Console.WriteLine("Неправильний ввід! Має бути число від 0 до 10.");
        }
    }

    private string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrEmpty(input))
                return input;
            Console.WriteLine("Поле не може бути порожнім!");
        }
    }

    public void ShowAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Колекція порожня. Спочатку додайте студентів.");
            return;
        }

        Console.WriteLine("ВСІ СТУДЕНТИ:");
        Console.WriteLine("Кількість: " + students.Count);
        
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"[{i}] {students[i].FullName}, Група: {students[i].GroupNumber}, Середній бал: {students[i].AveragePerformance:F2}");
        }
    }

    public void AddStudentsMenu()
    {
        Console.WriteLine("\n=== ДОДАВАННЯ СТУДЕНТІВ ===");
        Console.WriteLine("1 - Додати вручну");
        Console.WriteLine("2 - Додати випадково");
        Console.Write("Ваш вибір: ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                AddStudentsManually();
                break;
            case "2":
                AddStudentsRandomly();
                break;
            default:
                Console.WriteLine("Неправильний вибір!");
                break;
        }
    }

    private void AddStudentsManually()
    {
        int count = ReadInt("Скільки студентів додати? ");
        
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nСтудент {i + 1}:");
            string fullName = ReadNonEmptyString("ПІБ: ");
            string group = ReadNonEmptyString("Група: ");
            
            Console.Write("5 оцінок через пробіл: ");
            string[] gradesInput = Console.ReadLine().Split(' ');
            int[] grades = new int[5];
            
            for (int j = 0; j < 5; j++)
            {
                if (j < gradesInput.Length && int.TryParse(gradesInput[j], out int grade))
                    grades[j] = grade;
                else
                    grades[j] = 0;
            }
            
            students.Add(new Student(fullName, group, grades));
        }
        Console.WriteLine($"Додано {count} студентів вручну!");
    }

    private void AddStudentsRandomly()
    {
        int count = ReadInt("Скільки студентів згенерувати? ");
        
        List<Student> randomStudents = StudentGenerator.GenerateRandomStudents(count);
        students.AddRange(randomStudents);
        Console.WriteLine($"Додано {count} випадкових студентів!");
    }

    public void RemoveStudentsMenu()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Колекція порожня. Немає кого видаляти.");
            return;
        }

        Console.WriteLine("\n=== ВИДАЛЕННЯ СТУДЕНТІВ ===");
        Console.WriteLine("1 - Видалити за номером");
        Console.WriteLine("2 - Видалити за іменем");
        Console.WriteLine("3 - Видалити за групою");
        Console.WriteLine("4 - Видалити за середнім балом");
        Console.Write("Ваш вибір: ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                RemoveByIndex();
                break;
            case "2":
                RemoveByName();
                break;
            case "3":
                RemoveByGroup();
                break;
            case "4":
                RemoveByGrade();
                break;
            default:
                Console.WriteLine("Неправильний вибір!");
                break;
        }
    }

    private void RemoveByIndex()
    {
        ShowAllStudents();
        int index = ReadInt("Введіть номер студента для видалення: ");
        
        if (index >= 0 && index < students.Count)
        {
            students.RemoveAt(index);
            Console.WriteLine("Студента видалено успішно!");
        }
        else
        {
            Console.WriteLine("Неправильний номер!");
        }
    }

    private void RemoveByName()
    {
        string name = ReadNonEmptyString("Введіть ПІБ студента для видалення: ");
        
        int removedCount = students.RemoveAll(s => s.FullName == name);
        Console.WriteLine($"Видалено {removedCount} студентів!");
    }

    private void RemoveByGroup()
    {
        string group = ReadNonEmptyString("Введіть групу для видалення: ");
        
        int removedCount = students.RemoveAll(s => s.GroupNumber == group);
        Console.WriteLine($"Видалено {removedCount} студентів з групи {group}!");
    }

    private void RemoveByGrade()
    {
        Console.WriteLine("Видалити студентів з середнім балом:");
        Console.WriteLine("1 - Нижче вказаного");
        Console.WriteLine("2 - Вище вказаного");
        Console.Write("Ваш вибір: ");
        
        string choice = Console.ReadLine();
        double grade = ReadDouble("Введіть бал: ");
        
        int removedCount = 0;
        switch (choice)
        {
            case "1":
                removedCount = students.RemoveAll(s => s.AveragePerformance < grade);
                Console.WriteLine($"Видалено {removedCount} студентів з балом < {grade}!");
                break;
            case "2":
                removedCount = students.RemoveAll(s => s.AveragePerformance > grade);
                Console.WriteLine($"Видалено {removedCount} студентів з балом > {grade}!");
                break;
            default:
                Console.WriteLine("Неправильний вибір!");
                break;
        }
    }

    public void EditStudent()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Колекція порожня. Немає кого редагувати.");
            return;
        }

        Console.WriteLine("РЕДАГУВАННЯ СТУДЕНТА:");
        ShowAllStudents();
        
        int index = ReadInt("Введіть номер студента для редагування: ");
        
        if (index >= 0 && index < students.Count)
        {
            students[index].FullName = ReadNonEmptyString("Нове ПІБ: ");
            students[index].GroupNumber = ReadNonEmptyString("Нова група: ");
            
            Console.Write("Нові 5 оцінок через пробіл: ");
            string[] gradesInput = Console.ReadLine().Split(' ');
            
            for (int i = 0; i < 5; i++)
            {
                if (i < gradesInput.Length && int.TryParse(gradesInput[i], out int grade))
                    students[index].Performance[i] = grade;
            }
            
            Console.WriteLine("Студента відредаговано успішно!");
        }
        else
        {
            Console.WriteLine("Неправильний номер!");
        }
    }

    public void SearchStudentsMenu()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Колекція порожня. Немає даних для пошуку.");
            return;
        }

        Console.WriteLine("\n=== ПОШУК СТУДЕНТІВ ===");
        Console.WriteLine("1 - Знайти успішних студентів");
        Console.WriteLine("2 - Знайти за групою");
        Console.WriteLine("3 - Знайти за іменем");
        Console.Write("Ваш вибір: ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                FindSuccessfulStudents();
                break;
            case "2":
                FindByGroup();
                break;
            case "3":
                FindByName();
                break;
            default:
                Console.WriteLine("Неправильний вибір!");
                break;
        }
    }

    private void FindSuccessfulStudents()
    {
        double minAverage = ReadDouble("Введіть мінімальний середній бал: ");
        
        List<Student> successfulStudents = students.FindAll(s => s.AveragePerformance >= minAverage);
        
        Console.WriteLine($"Знайдено {successfulStudents.Count} успішних студентів:");
        foreach (Student student in successfulStudents)
        {
            Console.WriteLine($"{student.FullName}, Група: {student.GroupNumber}, Середній бал: {student.AveragePerformance:F2}");
        }
        
        SaveResultsToFile(successfulStudents, "successful_students.txt");
    }

    private void FindByGroup()
    {
        string group = ReadNonEmptyString("Введіть групу: ");
        
        List<Student> groupStudents = students.FindAll(s => s.GroupNumber == group);
        
        Console.WriteLine($"Знайдено {groupStudents.Count} студентів у групі {group}:");
        foreach (Student student in groupStudents)
        {
            Console.WriteLine($"{student.FullName}, Середній бал: {student.AveragePerformance:F2}");
        }
        
        SaveResultsToFile(groupStudents, $"group_{group}_students.txt");
    }

    private void FindByName()
    {
        string name = ReadNonEmptyString("Введіть ПІБ (або частину): ");
        
        List<Student> foundStudents = students.FindAll(s => s.FullName.Contains(name));
        
        Console.WriteLine($"Знайдено {foundStudents.Count} студентів:");
        foreach (Student student in foundStudents)
        {
            Console.WriteLine($"{student.FullName}, Група: {student.GroupNumber}, Середній бал: {student.AveragePerformance:F2}");
        }
        
        SaveResultsToFile(foundStudents, $"search_{name}_students.txt");
    }

    private void SaveResultsToFile(List<Student> studentsList, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Результати пошуку:");
            foreach (Student student in studentsList)
            {
                writer.WriteLine($"{student.FullName}, Група: {student.GroupNumber}, Середній бал: {student.AveragePerformance:F2}");
            }
        }
        Console.WriteLine($"Результати збережено у файл: {filename}");
    }

    public void ClearCollection()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Колекція вже порожня.");
            return;
        }

        Console.Write("Ви впевнені, що хочете очистити всю колекцію? (y/n): ");
        string answer = Console.ReadLine()?.ToLower();
        
        if (answer == "y" || answer == "так")
        {
            students.Clear();
            Console.WriteLine("Колекцію очищено!");
        }
        else
        {
            Console.WriteLine("Операцію скасовано.");
        }
    }
}
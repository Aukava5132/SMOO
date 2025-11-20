namespace Lab1;
using System;
using System.IO;

public class StudentSerializationManager
{
    private readonly StudentSerializer _serializer = new StudentSerializer();

    public void ManageSerialization(Student[] students, StudentPrinter printer)
    {
        Console.WriteLine("УПРАВЛІННЯ СЕРІАЛІЗАЦІЄЮ");
        
        while (true)
        {
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1 - Серіалізувати всіх студентів");
            Console.WriteLine("2 - Серіалізувати тільки успішних студентів");
            Console.WriteLine("3 - Десеріалізувати та показати дані");
            Console.WriteLine("4 - Показати інформацію про файли");
            Console.WriteLine("0 - Вийти з управління серіалізацією");
            Console.Write("Ваш вибір: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    SerializeAllStudents(students);
                    break;
                case "2":
                    SerializeSuccessfulStudents(students, printer);
                    break;
                case "3":
                    DeserializeAndShow(printer);
                    break;
                case "4":
                    ShowFileInfo();
                    break;
                case "0":
                    Console.WriteLine("Вихід з управління серіалізацією");
                    return;
                default:
                    Console.WriteLine("Неправильний вибір. Введіть число від 0 до 4");
                    break;
            }
        }
    }

    private void SerializeAllStudents(Student[] students)
    {
        if (students == null || students.Length == 0)
        {
            Console.WriteLine("Немає студентів для серіалізації");
            return;
        }

        Console.WriteLine("Оберіть формат:");
        Console.WriteLine("1 - XML");
        Console.WriteLine("2 - JSON");
        Console.WriteLine("3 - Обидва формати");
        Console.Write("Ваш вибір: ");
        
        string formatChoice = Console.ReadLine();
        
        switch (formatChoice)
        {
            case "1":
                _serializer.SerializeToXml(students, "students.xml");
                break;
            case "2":
                _serializer.SerializeToJson(students, "students.json");
                break;
            case "3":
                _serializer.SerializeToXml(students, "students.xml");
                _serializer.SerializeToJson(students, "students.json");
                break;
            default:
                Console.WriteLine("Неправильний вибір формату. Введіть 1, 2 або 3");
                break;
        }
    }

    private void SerializeSuccessfulStudents(Student[] students, StudentPrinter printer)
    {
        if (students == null || students.Length == 0)
        {
            Console.WriteLine("Немає студентів для серіалізації");
            return;
        }

        Console.Write("Введіть мінімальний середній бал для успішних студентів (0-10): ");
        string input = Console.ReadLine();
        
        if (!double.TryParse(input, out double minAverage) || minAverage < 0 || minAverage > 10)
        {
            Console.WriteLine("Неправильний ввід балу. Має бути число від 0 до 10");
            return;
        }

        Student[] successfulStudents = Array.FindAll(students, s => s.AveragePerformance >= minAverage);
        
        if (successfulStudents.Length == 0)
        {
            Console.WriteLine("Не знайдено студентів з середнім балом >= " + minAverage);
            return;
        }

        Console.WriteLine("Знайдено " + successfulStudents.Length + " успішних студентів");
        printer.PrintStudents(successfulStudents, "Успішні студенти (бал >= " + minAverage + ")");
        
        _serializer.SerializeToXml(successfulStudents, "successful_students.xml");
        _serializer.SerializeToJson(successfulStudents, "successful_students.json");
        Console.WriteLine("Успішні студенти серіалізовані");
    }

    private void DeserializeAndShow(StudentPrinter printer)
    {
        Console.WriteLine("Оберіть файл для десеріалізації:");
        Console.WriteLine("1 - students.xml (XML)");
        Console.WriteLine("2 - students.json (JSON)");
        Console.WriteLine("3 - successful_students.xml (Успішні XML)");
        Console.WriteLine("4 - successful_students.json (Успішні JSON)");
        Console.Write("Ваш вибір: ");
        
        string choice = Console.ReadLine();
        
        string filePath;
        switch (choice)
        {
            case "1":
                filePath = "students.xml";
                break;
            case "2":
                filePath = "students.json";
                break;
            case "3":
                filePath = "successful_students.xml";
                break;
            case "4":
                filePath = "successful_students.json";
                break;
            default:
                filePath = null;
                break;
        }

        if (filePath == null)
        {
            Console.WriteLine("Неправильний вибір. Введіть число від 1 до 4");
            return;
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл " + filePath + " не існує. Спочатку виконайте серіалізацію");
            return;
        }

        try
        {
            Student[] students;
            switch (choice)
            {
                case "1":
                case "3":
                    students = _serializer.DeserializeFromXml(filePath);
                    break;
                case "2":
                case "4":
                    students = _serializer.DeserializeFromJson(filePath);
                    break;
                default:
                    students = null;
                    break;
            }

            if (students != null && students.Length > 0)
            {
                string title;
                switch (choice)
                {
                    case "1":
                        title = "Студенти з XML";
                        break;
                    case "2":
                        title = "Студенти з JSON";
                        break;
                    case "3":
                        title = "Успішні студенти з XML";
                        break;
                    case "4":
                        title = "Успішні студенти з JSON";
                        break;
                    default:
                        title = "Десеріалізовані студенти";
                        break;
                }
                
                printer.PrintStudents(students, title);
            }
            else
            {
                Console.WriteLine("Не вдалося десеріалізувати дані або файл порожній");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при десеріалізації: " + ex.Message);
        }
    }

    private void ShowFileInfo()
    {
        Console.WriteLine("ІНФОРМАЦІЯ ПРО ФАЙЛИ");
        
        ShowFileStatus("students.xml");
        ShowFileStatus("students.json");
        ShowFileStatus("successful_students.xml");
        ShowFileStatus("successful_students.json");
    }

    private void ShowFileStatus(string filename)
    {
        if (File.Exists(filename))
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filename);
                string created = fileInfo.CreationTime.ToString("dd.MM.yyyy HH:mm");
                Console.WriteLine(filename + ": розмір " + fileInfo.Length + " байт, створений " + created);
            }
            catch
            {
                Console.WriteLine(filename + ": існує, але недоступний для читання інформації");
            }
        }
        else
        {
            Console.WriteLine(filename + ": не існує");
        }
    }
}
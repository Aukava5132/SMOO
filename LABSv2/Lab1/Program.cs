namespace Lab1;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var library = new StudentLibrary();
        var serializer = new StudentSerializer();
        var printer = new StudentPrinter();
        
        InitializeStudents(library);

        // Получаем всех студентов
        var allStudents = library.GetAllStudents();
        
        // Выводим всех студентов
        printer.PrintStudents(allStudents, "Все студенты");
        printer.PrintStudentSummary(allStudents);

        // Сериализация в XML
        serializer.SerializeToXml(allStudents, "students.xml");
        
        // Десериализация из XML
        var xmlStudents = serializer.DeserializeFromXml("students.xml");
        printer.PrintStudents(xmlStudents, "Студенты из XML");

        // Сериализация в JSON
        serializer.SerializeToJson(allStudents, "students.json");
        
        // Десериализация из JSON
        var jsonStudents = serializer.DeserializeFromJson("students.json");
        printer.PrintStudents(jsonStudents, "Студенты из JSON");

        // Выводим успешных студентов
        var successfulStudents = library.GetSuccessfulStudents(8.0);
        printer.PrintStudents(successfulStudents, "Успешные студенты (средний балл >= 8)");

        Console.ReadLine();
    }

    static void InitializeStudents(StudentLibrary library)
    {
        library.AddStudent(new Student("Иванов Иван Иванович", "ГР-01", new int[] { 9, 8, 9, 10, 8 }));
        library.AddStudent(new Student("Петров Петр Петрович", "ГР-02", new int[] { 7, 6, 8, 7, 6 }));
        library.AddStudent(new Student("Сидорова Анна Михайловна", "ГР-01", new int[] { 10, 9, 10, 9, 10 }));
        library.AddStudent(new Student("Козлов Алексей Сергеевич", "ГР-03", new int[] { 8, 8, 9, 8, 9 }));
    }
}
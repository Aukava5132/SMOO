namespace Lab1;
using System;

public class StudentGenerator
{
    private static readonly string[] _firstNames = { "Олександр", "Андрій", "Володимир"};
    private static readonly string[] _lastNames = { "Ткацький", "Вірушин", "Колотило"};
    private static readonly string[] _middleNames = { "Олексійович", "Сергійович", "Владиславович"};
    private static readonly string[] _groups = { "КН-01", "КН-02", "АКІТ-01", "АКІТ-02"};

    private static Random _random = new Random();

    public static Student GenerateRandomStudent()
    {
        string firstName = _firstNames[_random.Next(_firstNames.Length)];
        string lastName = _lastNames[_random.Next(_lastNames.Length)];
        string middleName = _middleNames[_random.Next(_middleNames.Length)];
        
        string fullName = lastName + " " + firstName + " " + middleName;
        string group = _groups[_random.Next(_groups.Length)];
        
        int gradesCount = _random.Next(3, 6);
        int[] grades = new int[gradesCount];
        
        for (int i = 0; i < gradesCount; i++)
        {
            grades[i] = _random.Next(5, 11);
        }

        return new Student(fullName, group, grades);
    }

    public static void GenerateRandomStudents(StudentLibrary library, int count)
    {
        for (int i = 0; i < count; i++)
        {
            library.AddStudent(GenerateRandomStudent());
        }
    }
}
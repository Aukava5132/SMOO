namespace Lab1;
using System.Collections.Generic;
using System.Linq;

public class StudentCollection
{
    private List<Student> _students;

    public StudentCollection()
    {
        _students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public Student[] GetAllStudents()
    {
        return _students.ToArray();
    }

    public Student[] GetSuccessfulStudents(double minAverage = 8.0)
    {
        return _students.Where(s => s.AveragePerformance >= minAverage).ToArray();
    }
}
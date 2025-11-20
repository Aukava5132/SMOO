namespace Lab2;
using System.Collections.Generic;
using System.Linq;

public class StudentCollection
{
    private List<Student> students;

    public StudentCollection()
    {
        students = new List<Student>();
    }

    public int Count => students.Count;

    public void Add(Student student)
    {
        students.Add(student);
    }

    public void AddRange(List<Student> newStudents)
    {
        students.AddRange(newStudents);
    }

    public void Insert(int index, Student student)
    {
        students.Insert(index, student);
    }

    public void RemoveAt(int index)
    {
        students.RemoveAt(index);
    }

    public int RemoveAll(System.Predicate<Student> match)
    {
        return students.RemoveAll(match);
    }

    public void Clear()
    {
        students.Clear();
    }

    public Student GetStudent(int index)
    {
        return students[index];
    }

    public void SetStudent(int index, Student student)
    {
        students[index] = student;
    }

    public List<Student> GetAllStudents()
    {
        return new List<Student>(students);
    }

    public List<Student> FindAll(System.Predicate<Student> match)
    {
        return students.FindAll(match);
    }

    public bool IsEmpty()
    {
        return students.Count == 0;
    }
}
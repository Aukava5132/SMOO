namespace Lab2;
using System;

[Serializable]
public class Student
{
    public const int PerformanceCount = 5; 
    public string FullName { get; set; }
    public string GroupNumber { get; set; }
    public int[] Performance { get; set; } = new int[PerformanceCount];
    
    public Student() { }
    
    public Student(string fullName, string groupNumber, int[] performance)
    {
        FullName = fullName;
        GroupNumber = groupNumber;
        
        if (performance != null)
        {
            int elementsToCopy = Math.Min(performance.Length, PerformanceCount);
            Array.Copy(performance, Performance, elementsToCopy);
        }
    }
    
    public double AveragePerformance
    {
        get
        {
            if (Performance == null || Performance.Length == 0)
                return 0;
            
            double sum = 0;
            foreach (int mark in Performance)
            {
                sum += mark;
            }
            return sum / Performance.Length;
        }
    }
}
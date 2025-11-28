namespace Lab3
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public int WorkExperience { get; set; }
        public bool HasHigherEducation { get; set; }
    }

    public class Worker : Employee { }
    public class Manager : Employee { }
    public class President : Employee { }
}
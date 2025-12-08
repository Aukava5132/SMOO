namespace Lab3;

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public double Salary { get; set; }

    public int Age => DateTime.Now.Year - BirthDate.Year;

    public abstract string GetPosition();
}

public class President : Person
{
    public int TermYears { get; set; }
    public override string GetPosition() => "Президент";
}

public class Manager : Person
{
    public string Department { get; set; }
    public int TeamSize { get; set; }
    public override string GetPosition() => $"Менеджер ({Department})";
}

public class Worker : Person
{
    public string Specialization { get; set; }
    public DateTime HireDate { get; set; }
    public bool HasHigherEducation { get; set; }

    public int ExperienceYears => DateTime.Now.Year - HireDate.Year;
    public int ExperienceDays => (DateTime.Now - HireDate).Days;

    public override string GetPosition() => $"Робочий ({Specialization})";
}
namespace Lab3;
using System;
public class CompanyGenerator
{
    private static readonly string[] _name = { "Food", "White", "CarsLogistics"};
    private static readonly string[] _directorNames = { "Black", "White", "Steven"};
    private static readonly string[] _country = { "Ukraine", "London", "Poland"};
    private static readonly string[] _businessProfile = { "IT", "Marketing", "News"};
    private static readonly int[]  _employeeCount = { 10, 200, 300 };
    private static DateTime[] _foundationDate = {
        new DateTime(2022, 1, 15),
        new DateTime(2015, 10, 20),
        new DateTime(2018, 6, 10)
    };

    private static Random _random = new Random();

    public static Company GenerateRandomCompany()
    {
        string name = _name[_random.Next(_name.Length)];
        string directorName = _directorNames[_random.Next(_directorNames.Length)];
        string country = _country[_random.Next(_country.Length)];
        int employeeCount = _employeeCount[_random.Next(_employeeCount.Length)];
        string businessProfile = _businessProfile[_random.Next(_businessProfile.Length)];
        DateTime foundationDate = _foundationDate[_random.Next(_foundationDate.Length)];
        
        return new Company(name, foundationDate, businessProfile,employeeCount,country,directorName);
    }

    public static void GenerateRandomCompanies(CompanyCollection collection, int count)
    {
        for (int i = 0; i < count; i++)
        {
            collection.AddCompany(GenerateRandomCompany());
        }
    }
}
namespace Lab3;

public class Printer
{
    public static void PrintCompanies(List<Company> companies, string title = "Компании")
    {
        if (companies == null || !companies.Any())
        {
            Console.WriteLine($"{title}: список пуст");
            return;
        }

        Console.WriteLine($"=== {title} ===");
        Console.WriteLine($"Найдено компаний: {companies.Count}");
        Console.WriteLine(new string('-', 60));
        
        foreach (var company in companies)
        {
            PrintCompany(company);
            Console.WriteLine(new string('-', 40));
        }
        Console.WriteLine();
    }

    public static void PrintCompany(Company company)
    {
        if (company == null)
        {
            Console.WriteLine("Компания: null");
            return;
        }

        Console.WriteLine($"Название: {company.Name}");
        Console.WriteLine($"Директор: {company.DirectorName}");
        Console.WriteLine($"Профиль: {company.BusinessProfile}");
        Console.WriteLine($"Сотрудников: {company.EmployeeCount}");
        Console.WriteLine($"Страна: {company.Country}");
        Console.WriteLine($"Основана: {company.FoundationDate:dd.MM.yyyy}");
        Console.WriteLine($"Возраст компании: {(DateTime.Now - company.FoundationDate).Days} дней");
    }

    public static void PrintAllInfo(CompanyCollection collection)
    {
        Console.WriteLine("=== ВСЯ ИНФОРМАЦИЯ О КОМПАНИЯХ ===");
        
        PrintCompanies(collection.GetAll(), "Все компании");
        /*PrintCompanies(collection.GetAllFood(), "Компании с названием 'Food'");
        PrintCompanies(collection.GetAllBusinessProfileMarketing(), "Маркетинговые компании");
        PrintCompanies(collection.GetAllBusinessProfileMarketingOrIT(), "IT или Маркетинг компании");
        PrintCompanies(collection.GetAllEmployeeCountGreaterThan100(), "Компании >100 сотрудников");
        PrintCompanies(collection.GetAllEmployeeCountBetween100And300(), "Компании 100-300 сотрудников");
        PrintCompanies(collection.GetAllCountryIsLondon(), "Компании в Лондоне");
        PrintCompanies(collection.GetAllDirectorNameIsWhite(), "Директор White");
        PrintCompanies(collection.GetAllFoundationDateSubstract2Years(), "Моложе 2 лет");
        PrintCompanies(collection.GetAllFoundationDateSubstract150Days(), "Моложе 150 дней");*/
        PrintCompanies(collection.GetAllDirectorNameIsBlackAndNameIsWhite(), "Директор Black + название White");
    }
}
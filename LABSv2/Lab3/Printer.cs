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

    public static void PrintAllInfoCompanies(CompanyCollection collection)
    {
        Console.WriteLine("=== ВСЯ ИНФОРМАЦІЯ ПРО КОМПАНІЇ ===");
        
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

    public static void PrintTelephone(Telephone telephone)
    {
        if (telephone == null)
        {
            Console.WriteLine("Телефон: null");
            return;
        }
        Console.WriteLine($"Назва: {telephone.Name}");
        Console.WriteLine($"Дата виробництва: {telephone.Price}");
        Console.WriteLine($"Ціна: {telephone.ManufactureDate:dd.MM.yyyy}");
    }

    public static void PrintTelephones(List<Telephone> telephones)
    {
        foreach (Telephone telephone in telephones)
        {
            PrintTelephone(telephone);
        }
    }
    
    public static void PrintTelephonesGroup(List<IGrouping<string, Telephone>> telephones)
    {
        foreach (IGrouping<string, Telephone> telephone in telephones)
        {
            Console.WriteLine($"Назва: {telephone.Key} - {telephone.Count()}");
        }
    }
    
    public static void PrintTelephonesGroupModel(List<IGrouping<string, Telephone>> telephones)
    {
        foreach (IGrouping<string, Telephone> telephoneNames in telephones)
        {
            foreach (IGrouping<string, Telephone> telephoneModels in telephoneNames.GroupBy(t => t.Model).ToList())
            {
                Console.WriteLine($"Назва: {telephoneNames.Key} {telephoneModels.Key} - {telephoneModels.Count()}");
            }
        }
    }
    
    public static void PrintTelephonesGroupMufacturingDate(List<IGrouping<string, Telephone>> telephones)
    {
        foreach (IGrouping<string, Telephone> telephoneNames in telephones)
        {
            foreach (IGrouping<DateTime,Telephone> telephoneDate in telephoneNames.GroupBy(t => t.ManufactureDate).ToList())
            {
                Console.WriteLine($"Назва: {telephoneNames.Key} {telephoneDate.Key.Year} - {telephoneDate.Count()}");
            }
        }
    }

    public static void PrintAllInfoTelephones(TelephoneCollection collection)
    {
        Console.WriteLine("=== ВСЯ ИНФОРМАЦІЯ ПРО Телефони ===");
        // все телефонеси
        /*PrintTelephones(collection.GetAll());*/
        // 5 самих дорогих телефонесов 
        /*PrintTelephones(collection.GetMaxPrice5Count());*/
        // вывод марок телефонов по их количеству 
        /*PrintTelephonesGroup(collection.GetAllStatistic());*/
        // вывод марок и моделей телефонов и их колво
        /*PrintTelephonesGroupModel(collection.GetAllStatistic());*/
        PrintTelephonesGroupMufacturingDate(collection.GetAllStatistic());

    }
}
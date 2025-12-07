namespace Lab3;

using System.Linq;

public class CompanyCollection
{
    private List<Company> _companies;
    
    public CompanyCollection()
    {
        _companies = new List<Company>();
    }
    
    public void AddCompany(Company company)
    { 
        _companies.Add(company);
    }

    /*
     * Отримати інформацію про всі фірми
     */
    public List<Company> GetAll()
    {
        return _companies.ToList();
    }
    
    /*
     * Отримати фірми, які мають назву Food
     */
    public List<Company> GetAllFood()
    {
        return _companies.Where(c => c.Name == "Food").ToList();
    }
    
    /*
     * Отримати фірми, що працюють у галузі маркетингу
     */
    public List<Company> GetAllBusinessProfileMarketing()
    {
        return _companies.Where(c => c.BusinessProfile is "Marketing").ToList();
    }
    
    /*
     * отримати фірми, що працюють у галузі маркетингу або IT;
     */
    public List<Company> GetAllBusinessProfileMarketingOrIT()
    {
        return _companies.Where(c => c.BusinessProfile is "Marketing" or "IT").ToList();
    }
    
    private IEnumerable<Company> GetAllEmployeeCountGreaterThan(int count)
    {
        return _companies.Where(c => c.EmployeeCount > count);
    }
    
    private IEnumerable<Company> GetAllEmployeeCountLessThan(int count, IEnumerable<Company>? companies)
    { 
        return (companies ?? _companies).Where(c => c.EmployeeCount < count);
    }
    
    /*
     * отримати фірми з кількістю співробітників більше 100;
     */
    public List<Company> GetAllEmployeeCountGreaterThan100()
    {
        return GetAllEmployeeCountGreaterThan(100).ToList();
    }
    
    /*
     * отримати фірми з кількістю співробітників більше 100;
     */
    public List<Company> GetAllEmployeeCountBetween100And300()
    {
        var companies = GetAllEmployeeCountGreaterThan(100);
        return GetAllEmployeeCountLessThan(300, companies).ToList();
    }
    
    /*
     * отримати фірми, що знаходяться у Лондоні;
     */
    public List<Company> GetAllCountryIsLondon()
    {
        return _companies.Where(c => c.Country is "London").ToList();
    }
    
    /*
     * отримати фірми, які мають прізвище директора White;
     */
    public List<Company> GetAllDirectorNameIsWhite()
    {
        return _companies.Where(c => c.DirectorName is "White").ToList();
    }
    
    /*
     * отримати фірми, які засновані понад два роки тому;
     */
    public List<Company> GetAllFoundationDateSubstract2Years()
    {
        return _companies.Where(c => c.FoundationDate >= DateTime.Now.AddYears(-2)).ToList();
    }
    
    /*
     * отримати фірми, з дня заснування яких минуло більше 150 днів;
     */
    public List<Company> GetAllFoundationDateSubstract150Days()
    {
        return _companies.Where(c => c.FoundationDate >= DateTime.Now.AddDays(-150)).ToList();
    }
    
    /*
     * отримати фірми, які мають прізвище директора White;
     */
    public List<Company> GetAllDirectorNameIsBlackAndNameIsWhite()
    {
        return _companies.Where(c => (c is { DirectorName: "Black", Name: "White" })).ToList();
    }
    
    public Company First()
    {
        return _companies.First();
    }
}

namespace Lab3;
using System.Collections.Generic;
using System.Linq;

public class CompanyCollection
{
    private readonly List<Company> _companies;

    public CompanyCollection(List<Company> companies)
    {
        _companies = companies;
    }

    public List<Company> AllCompanies()
    {
        return _companies.ToList();
    }

    public void AddCompany(Company company)
    {
        _companies.Add(company);
    }

    public List<Company> CompaniesByName(string name)
    {
        return _companies.Where(c => c.Name.Equals(name)).ToList();
    }

    public List<Company> MarketingCompanies()
    {
        return _companies.Where(c => c.BusinessProfile.Equals("Marketing")).ToList();
    }

    public List<Company> MarketingOrITCompanies()
    {
        return _companies.Where(c => c.BusinessProfile.Equals("Marketing") || c.BusinessProfile.Equals("IT")).ToList();
    }

    public List<Company> CompaniesMoreThan(int count)
    {
        return _companies.Where(c => c.EmployeeCount > count).ToList();
    }

    public List<Company> CompaniesWithEmployeesBetween(int min, int max)
    {
        return _companies.Where(c => c.EmployeeCount >= min && c.EmployeeCount <= max).ToList();
    }

    public List<Company> CompaniesInCity(string country)
    {
        return _companies.Where(c => c.Address.Contains(country)).ToList();
    }

    public List<Company> CompaniesByDirectorLastName(string lastName)
    {
        return _companies.Where(c => c.DirectorName.EndsWith(lastName)).ToList();
    }

    public List<Company> CompaniesOlderThanYears(int years)
    {
        DateTime thresholdDate = DateTime.Now.AddYears(-years);
        return _companies.Where(c => c.FoundationDate <= thresholdDate).ToList();
    }

    public List<Company> CompaniesOlderThanDays(int days)
    {
        DateTime thresholdDate = DateTime.Now.AddDays(-days);
        return _companies.Where(c => c.FoundationDate <= thresholdDate).ToList();
    }

    public List<Company> CompaniesComplexQuery()
    {
        return _companies.Where(c => c.DirectorName.EndsWith("Black") && c.Name.Contains("White")).ToList();
    }
}
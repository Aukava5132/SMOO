namespace Lab3;
using System.Collections.Generic;
using System.Linq;
public class TelephoneCollection
{
    private readonly List<Telephone> _telephones;

    public TelephoneCollection(List<Telephone> telephones)
    {
        _telephones = telephones;
    }

    public void Add(Telephone telephone)
    {
        _telephones.Add(telephone);
    }

    public int Count()
    {
        return _telephones.Count;
    }

    public int CountPriceGreaterThan(int count)
    {
        return _telephones.Count(t => t.Price > count);
    }

    public int CountPriceBetween(int min, int max)
    {
        return _telephones.Count(t => t.Price > min && t.Price < max);
    }

    public int CountName(string brand)
    {
        return _telephones.Count(t => t.Brand.Equals(brand));
    }

    public Telephone MinPrice()
    {
        return _telephones.OrderBy(t => t.Price).First();
    }

    public Telephone MaxPrice()
    {
        return _telephones.OrderByDescending(t => t.Price).First();
    }

    public Telephone Oldest()
    {
        return _telephones.OrderBy(t => t.ManufactureDate).First();
    }

    public Telephone Newest()
    {
        return _telephones.OrderByDescending(t => t.ManufactureDate).First();
    }

    public double AveragePrice()
    {
        return _telephones.Average(t => t.Price);
    }

    public List<Telephone> MaxPriceTop5()
    {
        return _telephones.OrderByDescending(t => t.Price).Take(5).ToList();
    }

    public List<Telephone> MinPriceTop5()
    {
        return _telephones.OrderBy(t => t.Price).Take(5).ToList();
    }

    public List<Telephone> Top3Oldest()
    {
        return _telephones.OrderBy(t => t.ManufactureDate).Take(3).ToList();
    }

    public List<Telephone> Top3Newest()
    {
        return _telephones.OrderByDescending(t => t.ManufactureDate).Take(3).ToList();
    }

    public Dictionary<string, int> BrandStatistics()
    {
       return _telephones.GroupBy(t => t.Brand).ToDictionary(b => b.Key, b => b.Count());
    }

    public Dictionary<string, int> ModelStatistics() 
    {
        return _telephones.GroupBy(t => t.Brand).ToDictionary(m => m.Key, g => g.Count());
    }

    public Dictionary<DateTime, int> ManufactureDateStatistics()
    {
        return _telephones.GroupBy(t => t.ManufactureDate).ToDictionary(d => d.Key, d => d.Count());
    }
}
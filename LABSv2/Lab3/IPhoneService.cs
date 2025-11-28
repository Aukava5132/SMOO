using System.Collections.Generic;
using Lab3;

namespace Lab3
{
    public interface IPhoneService
    {
        int GetPhoneCount();
        int GetPhonesByPriceRange(decimal min, decimal max);
        Phone GetCheapestPhone();
        Phone GetMostExpensivePhone();
        decimal GetAveragePrice();
        Dictionary<string, int> GetManufacturerStats();
        Dictionary<string, int> GetModelStats();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;
using Lab3.Interfaces;

namespace Lab3.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly List<Phone> _phones;
        
        public PhoneService(List<Phone> phones)
        {
            _phones = phones;
        }
        
        public int GetPhoneCount() => _phones.Count;
        
        public int GetPhonesByPriceRange(decimal min, decimal max)
        {
            return _phones.Count(p => p.Price >= min && p.Price <= max);
        }
        
        public Phone GetCheapestPhone()
        {
            return _phones.OrderBy(p => p.Price).FirstOrDefault();
        }
        
        public Phone GetMostExpensivePhone()
        {
            return _phones.OrderByDescending(p => p.Price).FirstOrDefault();
        }
        
        public decimal GetAveragePrice()
        {
            return _phones.Average(p => p.Price);
        }
        
        public Dictionary<string, int> GetManufacturerStats()
        {
            return _phones.GroupBy(p => p.Manufacturer)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        
        public Dictionary<string, int> GetModelStats()
        {
            return _phones.GroupBy(p => p.Model)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
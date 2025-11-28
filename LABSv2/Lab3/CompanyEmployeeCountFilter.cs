using System.Collections.Generic;
using System.Linq;
using Lab3.Models;
using Lab3.Interfaces;

namespace Lab3.Filters
{
    public class CompanyEmployeeCountFilter : IFilter<Company>
    {
        private readonly int _min, _max;
        
        public CompanyEmployeeCountFilter(int min, int max)
        {
            _min = min;
            _max = max;
        }
        
        public IEnumerable<Company> Filter(IEnumerable<Company> companies)
        {
            return companies.Where(c => c.EmployeeCount >= _min && c.EmployeeCount <= _max);
        }
    }
}
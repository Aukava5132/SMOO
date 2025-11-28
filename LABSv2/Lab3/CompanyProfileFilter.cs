using System.Collections.Generic;
using System.Linq;
using Lab3.Models;
using Lab3.Interfaces;

namespace Lab3.Filters
{
    public class CompanyProfileFilter : IFilter<Company>
    {
        private readonly string _profile;
        
        public CompanyProfileFilter(string profile)
        {
            _profile = profile;
        }
        
        public IEnumerable<Company> Filter(IEnumerable<Company> companies)
        {
            return companies.Where(c => c.BusinessProfile.Equals(_profile, StringComparison.OrdinalIgnoreCase));
        }
    }
}
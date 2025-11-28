namespace Lab3
{
    public class Company
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorName { get; set; }
        public int EmployeeCount { get; set; }
        public string Country { get; set; }

        public Company(string name, DateTime foundationDate, string businessProfile, int employeeCount, string country,
            string directorName)
        {
            Name = name;
            FoundationDate = foundationDate;
            BusinessProfile = businessProfile;
            EmployeeCount = employeeCount;
            Country = country;
            DirectorName = directorName;
        }
    }
}
namespace Lab3
{
    public class Company
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorName { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }
        
        public President President { get; set; }
        public List<Manager> Managers { get; set; } = new List<Manager>();
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public Company(string name, DateTime foundationDate, string businessProfile, int employeeCount, string address,
            string directorName)
        {
            Name = name;
            FoundationDate = foundationDate;
            BusinessProfile = businessProfile;
            EmployeeCount = employeeCount;
            Address = address;
            DirectorName = directorName;
        }
        public override string ToString()
        {
            return $"{Name} ({BusinessProfile}) - Директор: {DirectorName}, " +
                   $"Співробітників: {EmployeeCount}, Адреса: {Address}, " +
                   $"Заснована: {FoundationDate:dd.MM.yyyy}";
        }
    }
}
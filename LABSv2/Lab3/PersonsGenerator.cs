namespace Lab3
{
    public class PersonsGenerator
    {
        private static readonly Random _random = new Random();

        private static readonly string[] _firstNames = { "Іван", "Петро", "Микола", "Володимир" };
        private static readonly string[] _lastNames = { "Петренко", "Коваленко", "Шевченко" };

        public static President CreatePresident()
        {
            return new President
            {
                FirstName = _firstNames[_random.Next(_firstNames.Length)],
                LastName = _lastNames[_random.Next(_lastNames.Length)],
                BirthDate = RandomBirthDate(),
                Salary = _random.Next(40000, 80000),
                TermYears = _random.Next(2, 6)
            };
        }


        public static Manager CreateManager()
        {
            string[] departments = { "Продажі", "Виробництво", "Логістика", "HR", "Фінанси" };
            return new Manager
            {
                FirstName = _firstNames[_random.Next(_firstNames.Length)],
                LastName = _lastNames[_random.Next(_lastNames.Length)],
                BirthDate = RandomBirthDate(),
                Salary = _random.Next(15000, 35000),
                Department = departments[_random.Next(departments.Length)],
                TeamSize = _random.Next(5, 25)
            };
        }


        public static Worker CreateWorker()
        {
            string[] specializations = { "Інженер", "Технік", "Електрик" };
            return new Worker
            {
                FirstName = _firstNames[_random.Next(_firstNames.Length)],
                LastName = _lastNames[_random.Next(_lastNames.Length)],
                BirthDate = RandomBirthDate(),
                Salary = _random.Next(8000, 20000),
                Specialization = specializations[_random.Next(specializations.Length)],
                HireDate = RandomHireDate(),
                HasHigherEducation = _random.Next(0, 2) == 0
            };
        }

        public static List<Manager> CreateManagers(int count)
        {
            return Enumerable.Range(0, count).Select(_ => CreateManager()).ToList();
        }

        public static List<Worker> CreateWorkers(int count)
        {
            return Enumerable.Range(0, count).Select(_ => CreateWorker()).ToList();
        }

        public static (President president, List<Manager> managers, List<Worker> workers)
            CreateEnterprisePersonnel(int managerCount, int workerCount)
        {
            return (
                CreatePresident(),
                CreateManagers(managerCount),
                CreateWorkers(workerCount)
            );
        }

        public static DateTime RandomBirthDate()
        {
            int year = _random.Next(1960, 1995);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTime(year, month, day);
        }

        public static DateTime RandomHireDate()
        {
            int yearsAgo = _random.Next(1, 30);
            int daysAgo = _random.Next(0, 365);
            return DateTime.Now.AddYears(-yearsAgo).AddDays(-daysAgo);
        }
    }
}
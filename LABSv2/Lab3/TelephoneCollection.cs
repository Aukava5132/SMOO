namespace Lab3;

public class TelephoneCollection
{
        private List<Telephone> _telephones;
    
        public TelephoneCollection()
        {
            _telephones = new List<Telephone>();
        }

        public void Add(Telephone telephone)
        {
            _telephones.Add(telephone);
        }

        public int Count()
        {
         return _telephones.Count;   
        }
        
        public int CountGreaterThanPrice(int count)
        {
            return _telephones.Count(t => t.Price > count);
        }
        
        public int CountGreaterBetween(int min, int max)
        {
            return _telephones.Count(t => t.Price > min && t.Price < max);
        }
        
        public int CountName()
        {
            return _telephones.Count(t => t.Name == "Samsung");
        }

        public Telephone GetMinPriceTelephone()
        {
            return _telephones.OrderBy(t => t.Price).First();
        }
        
        public Telephone GetMaxPrice()
        {
            return _telephones.OrderByDescending(t => t.Price).First();
        }
        
        public Telephone GetMaxManufactureDate()
        {
            return _telephones.OrderBy(t => t.ManufactureDate).First();
        }
        
        public Telephone GetMinManufactureDate()
        {
            return _telephones.OrderByDescending(t => t.ManufactureDate).First();
        }
        
        public double AveragePrice()
        {
            return _telephones.Average(t => t.Price);
        }
        
        public List<Telephone> GetMaxPrice5Count()
        {
            return _telephones.OrderByDescending(t => t.Price).Take(5).ToList();
        }

        public List<Telephone> GetMinPrice5Count()
        {
            return _telephones.OrderBy(t => t.Price).Take(5).ToList();
        }
        
        public List<Telephone> GetMinManufacturingDate3Count()
        {
            return _telephones.OrderBy(t => t.ManufactureDate).Take(3).ToList();
        }
        
        public List<Telephone> GetMaxManufacturingDate3Count()
        {
            return _telephones.OrderByDescending(t => t.ManufactureDate).Take(3).ToList();
        }
        
        public List<Telephone> GetAll()
        {
            return _telephones.ToList();
        }

        public List<IGrouping<string, Telephone>> GetAllStatistic()
        {
            return _telephones.GroupBy(t => t.Name).ToList();
        }
}
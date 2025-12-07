namespace Lab3;

public class Telephone
{
    public string Name { get; set; }
    public DateTime ManufactureDate { get; set; }
    public double Price { get; set; }
    
    public string Model { get; set; }
    
    public Telephone(string name, DateTime manufactureDate, int price, string model)
    {
        Name = name;
        ManufactureDate = manufactureDate; ;
        Price = price;
        Model = model;
    }
}



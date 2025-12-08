namespace Lab3;

public class Telephone
{
    public string Brand { get; set; }
    public DateTime ManufactureDate { get; set; }
    public double Price { get; set; }
    
    public string Model { get; set; }
    
    public Telephone(string brand, DateTime manufactureDate, int price, string model)
    {
        Brand = brand;
        ManufactureDate = manufactureDate; ;
        Price = price;
        Model = model;
    }

    public override string ToString()
    {
        return $"{Brand} ({Model}) - {Price}, Дата виготовлення: {ManufactureDate:dd.MM.yyyy}";
    }
}



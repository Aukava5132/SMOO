namespace Lab3;

public class TelephoneGenerator
{
    private static readonly string[] _name = { "Samsung", "Xiaomi", "Iphone"};
    private static readonly int[]  _price = { 10, 200, 500 };
    private static DateTime[] _manufactureDate = {
        new DateTime(2020, 1, 15),
        new DateTime(2025, 10, 20),
        new DateTime(2022, 6, 10)
    };
    private static readonly string[] _model = { "X", "F4", "S3"};
    
    private static Random _random = new Random();

    public static Telephone GenerateRandomTelephone()
    {
        string name = _name[_random.Next(_name.Length)];
        int price = _price[_random.Next(_price.Length)];
        DateTime foundationDate = _manufactureDate[_random.Next(_manufactureDate.Length)];
        string model = _model[_random.Next(_model.Length)];
        return new Telephone(name, foundationDate, price, model);
    }

    public static void GenerateRandomTelephone(TelephoneCollection collection, int count)
    {
        for (int i = 0; i < count; i++)
        {
            collection.Add(GenerateRandomTelephone());
        }
    }
}
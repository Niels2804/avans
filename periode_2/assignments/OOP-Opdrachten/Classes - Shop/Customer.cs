
public class Customer
{
    public string Name { get; private set; }
    public List<Product> PurchasedProducts { get; private set; }

    public Customer(string name)
    {
        Name = name;
        PurchasedProducts = new List<Product>();
    }

    // Voeg gekochte producten toe aan de lijst
    public void BuyProduct(Product product)
    {
        PurchasedProducts.Add(product);
        Console.WriteLine($"{Name} now has a {product.Name}");
    }

    public void DisplayProducts()
    {
        Console.WriteLine($"{Name} now has the following products:");
        foreach (Product product in PurchasedProducts)
        {
            Console.WriteLine($" - {product.Name}");
        }
    }
}

public class Shop
{
    public List<Product> Products { get; private set; } = new();
    public List<Customer> Customers { get; private set; } = new();

    private List<Stock> stock = new();

    public void AddProduct(Product product)
    {
        Products.Add(product);
        Console.WriteLine($"{product} has been added to the shop");
    }

    public void AddStock(Product product, int quantity)
    {
        var item = stock.FirstOrDefault(s => s.Product.Code == product.Code);
        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            stock.Add(new Stock(product, quantity));
        }
    }

    public bool SellProduct(Customer customer, Product product)
    {
        var item = stock.FirstOrDefault(s => s.Product.Code == product.Code);
        if (item != null && item.Quantity > 0)
        {
            item.Quantity--;
            customer.BuyProduct(product);
            Console.WriteLine($"{customer.Name} has bought {product.Name}.");
            return true;
        }
        Console.WriteLine($"{product} is not available");
        return false;
    }

    public void DisplayStock()
    {
        foreach (var item in stock)
        {
            Console.WriteLine($"{item.Quantity,4}x {item.Product}");
        }
    }
}

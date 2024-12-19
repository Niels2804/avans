public class Stock
{
    public Product Product { get; private set; }
    public int Quantity { get; set; }

    public Stock(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
}

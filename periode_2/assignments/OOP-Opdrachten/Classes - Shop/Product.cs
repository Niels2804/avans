using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Product
{
    public string Name { get; private set; }
    public double Price { get; private set; }
    public string Code { get; private set; }

    public Product(string name, double price, string code)
    {
        Name = name;
        Price = price;
        Code = code;
    }

    public override string ToString()
    {
        return $"{Name} ({Code}) - €{Price}";
    }
}

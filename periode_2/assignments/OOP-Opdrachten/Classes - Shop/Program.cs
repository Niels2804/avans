// Create store, products, and customers
Shop shop = new Shop();

Product laptop = new Product("Laptop", 999.99, "P001");
Product phone = new Product("Smartphone", 499.99, "P002");
Product book = new Product("Book", 19.99, "P003");

// Add products to the store
shop.AddProduct(laptop);
shop.AddProduct(phone);
shop.AddProduct(book);

// Add stock to the store
shop.AddStock(laptop, 5);
shop.AddStock(phone, 10);
shop.AddStock(book, 20);

// Create customers
Customer customer1 = new Customer("John");
Customer customer2 = new Customer("Sophie");

// Sell products to customers
shop.SellProduct(customer1, laptop);
shop.SellProduct(customer2, phone);
shop.SellProduct(customer1, book);

Console.WriteLine("Left in store:");
// Display current stock
shop.DisplayStock();


customer1.DisplayProducts();

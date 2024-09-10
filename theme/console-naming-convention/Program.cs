// Assignment 1: Improving the Naming Convention 
public interface IDisplay
{
    void display();
}


public class Customer : IDisplay
{
    public int id;
    public string name;

    public Customer(int a, string b)
    {
        id = a;
        name = b;
    }

    public void display()
    {
        Console.WriteLine("ID: " + id + ", Name: " + name);
    }
}
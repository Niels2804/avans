public class Fighter 
{
    private string _name;
    private int _health;
    public Fighter(string name)
    {
        this._name = name;
    }

    public void SayName() 
    {
        Console.WriteLine($"Name {this._name} is succesfully set");
    }

    public bool IsAlive() 
    {
        return this._health > 0;
    }

    public void SetHealth(int newHealth) 
    {
        if(newHealth > 100)
        {
            Console.WriteLine("Dit mag niet");
        }
        else 
        {
            this._health = newHealth;
        }
    }
}
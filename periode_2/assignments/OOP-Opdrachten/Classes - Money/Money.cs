public class Money
{
    public int Euros { get; set; }
    public int Cents { get; set; }
    
    public Money(int euros, int cents)
    {
        this.Euros = euros;
        this.Cents = cents;
    }
}

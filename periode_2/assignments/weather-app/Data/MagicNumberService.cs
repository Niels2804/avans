public class MagicNumberService 
{
    public List<int> GetMagicNumberList(int numberOfMagicInts) 
    {
        List<int> magicNumbers = [];
        Random random = new Random();

        for(int i = 0; i < numberOfMagicInts; i++) 
        {
            magicNumbers.Add(random.Next(1, 100));
        }

        return magicNumbers;
    }
}

LoopingCounter hours = new LoopingCounter(24);
LoopingCounter minutes = new LoopingCounter(60);
LoopingCounter seconds = new LoopingCounter(60);

for(int i = 0; i < 50; i++)
{
    if(seconds.Increase())
    {
        if(minutes.Increase())
        {
            hours.Increase();
        }
    }
    Console.WriteLine($"{hours.Value:00}:{minutes.Value:00}:{seconds.Value:00}");
}

/*extra
LoopingCounter hours = new LoopingCounter(24);
LoopingCounter minutes = new LoopingCounter(60, hours);
LoopingCounter seconds = new LoopingCounter(60, minutes);


for(int i = 0; i < 100000; i++)
{
    Console.WriteLine($"{hours.Value:00}:{minutes.Value:00}:{seconds.Value:00}");
    seconds.Increase();
}
*/

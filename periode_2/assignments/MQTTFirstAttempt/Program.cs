
if(await SendService.SendMessage("jow", "jow")) 
{
    Console.WriteLine("Bericht is verzonden");
} else {
    Console.WriteLine("Bericht is niet verzonden");
}

Console.ReadLine();

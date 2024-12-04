using MessageService;

ResponseService ResponseService = new();
SendService SendService = new();

if(await ResponseService.ReceiveMessage("jow", "jow")) 
{
    Console.WriteLine("Bericht is verzonden");
} else {
    Console.WriteLine("Bericht is niet verzonden");
}

Console.ReadLine();

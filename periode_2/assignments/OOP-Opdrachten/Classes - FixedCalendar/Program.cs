FixedCalendarDate date = new FixedCalendarDate(2024, 1, 1);

for(int i = 0; i < 400; i++)
{
    Console.WriteLine(date);
    date.AddDay();
}

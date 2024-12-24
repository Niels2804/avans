namespace Speaker.Library
{
    public class SoundLibrary 
    {
        public enum Driving
        {
            Start, // "Robot gaat rijden."
            Stop, // "Robot stopt met rijden."
            ObstacleDetected, // "Er is een obstakel gedetecteerd!"
        }

        public enum Motionsensor
        {
            Active, // "De bewegingssensor is actief en de robot start met het scannen van de omgeving."
            Stopped, // "De bewegingssensor is inactief en de robot stopt met het scannen van de omgeving."
            Detected, // "Er is beweging gedetecteerd!"
            NothingDetected, // "Gedurende de scanperiode is er geen beweging waargenomen."
        }

        public enum GeneralMentions
        {
            Welcome, // "Hallo, mijn naam is Walli!" (Wall-E)
            Warning, // "Waarschuwing!"
            Shutdown, // "Robot schakelt zich nu uit; opnieuw opstarten is vereist. Vraag desnoods uw zorgverlener om hulp."
            CountDown321, // "3, 2, 1."
            Remaining30, // "U heeft nog 30 seconden om de robot te heractiveren. Druk opnieuw op de rode knop om de robot te heractiveren."
            Paused, // "Robot is gepauzeerd!"
            RobotActive, // "Robot is geheractiveerd!"
            TutorialMention, // "Ik leg u uit wat ik voor u kan betekenen"
            TutorialStep1, // "De robot rijdt zelfstandig rond en stopt op verschillende plekken om activiteiten te meten."
            TutorialStep2, // "Op de robot zit een rode knop die knippert wanneer de robot actief is. Als u op het knipperende lampje drukt, pauzeert de robot en heeft u 60 seconden om de robot weer te heractiveren." 
            TutorialStep3, // "U kunt de robot ook opnieuw activeren door opnieuw op de rode knop te drukken. Tussendoor kan de robot u herinneringen geven als uw zorgverlener deze heeft ingesteld."
            TutorialStep4 // "Wanneer u een herinnering ontvangt, zal het rode lampje knipperen. Druk op het lampje om aan te geven dat u de herinnering heeft ontvangen."
        }

        public enum Mentions
        {
            Hi, // "Hoi!"
            Hello, // "Hallo!"
            GoodMorning, // "Goedemorgen!"
            GoodMidday, // "Goedemiddag!"
            GoodEvening, // "Goedenavond!"
            Bye_1, // "Tot ziens!"
            Bye_2, // "Doei!"
            TimeToEat, // "Het is tijd om te eten."
            TimeToBrushTeeth, // "Het is tijd om uw tanden te poetsen."
            TimeToSleep, // "Het is tijd om te slapen."
            TimeToWakeUp, // "Het is tijd om op te staan."
            TurnOffLivingRoomLight, // "Vergeet niet de huiskamerverlichting uit te schakelen."
            TimeForMedication, // "Het is tijd voor uw medicatie."
            TimeToRest, // "Het is tijd om uit te rusten."
            TimeForExercise, // "Laten we een korte wandeling maken."
            TimeToDrink, // "Vergeet niet om wat water te drinken."
            TimeToCheckBloodSugar, // "Vergeet niet om uw bloedsuiker te controleren."
            TimeForAppointment, // "U heeft een afspraak, controleer uw agenda."
            TimeToRelax, // "Laten we wat ontspannen."
            TimeToRead, // "Laten we samen een boek lezen."
            TimeToListenMusic, // "Laten we naar wat muziek luisteren."
            TimeToCallHealthCareProvider, // "Het is tijd om uw zorgverlener te bellen."
            TimeToCheckMail, // "Vergeet niet uw post te controleren."
            TimeToWaterPlants, // "Laten we de planten water geven."
            TimeToFeedPet, // "Het is tijd om uw huisdier te voeren."
            TimeToShower, // "Het is tijd om een douche te nemen."
            TimeToChangeClothes, // "Laten we uw kleding verwisselen."
            TimeToCheckCalendar, // "Bekijk uw agenda voor de komende afspraken."
            TimeToDoExercise, // "Laten we wat lichte oefeningen doen."
            TimeToDoBreathingExercise, // "Laten we een ademhalingsoefening doen."
            TimeToDoStretching, // "Laten we wat rek- en strekoefeningen doen."
            TimeToDoMemoryGame, // "Laten we een geheugenspel spelen."
            TimeToDoPuzzle, // "Laten we samen een puzzel maken."
            TimeToDoCraft, // "Laten we wat knutselen."
            TimeToDoGardening, // "Laten we wat tuinieren."
            TimeToDoCooking, // "Het is tijd om te koken."
            TimeToDoCleaning, // "Laten we wat opruimen."
            TimeToDoShopping, // "Het is tijd om de boodschappen te doen."
            TimeToDoLaundry, // "Laten we de was doen."
            TimeToDoIroning, // "Laten we strijken."
            TimeToDoDishes, // "Vergeet de afwas niet te doen."
            TimeToDoReading, // "Laten we samen een boek lezen."
            TimeToDoWriting, // "Laten we samen schrijven."
            TimeToDoDrawing, // "Laten we samen tekenen."
            TimeToDoPainting, // "Laten we samen schilderen."
            TimeToDoSinging, // "Laten we samen zingen."
        }

        public enum Music {
            FrancisWells, // Classic music
            Portal // 1 minute countdown...
        }
    }
}

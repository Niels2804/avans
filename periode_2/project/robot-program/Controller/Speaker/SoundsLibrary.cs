namespace SoundLibrary
{
    public enum Mentions
    {
        // Driving

        Start, // "Robot gaat rijden."
        Stop, // "Robot stopt met rijden."
        ObstacleDetected, // "Er is een obstakel gedetecteerd!"
        
        // Motionsensor

        Active, // "De bewegingssensor is actief en de robot start met het scannen van de omgeving."
        Stopped, // "De bewegingssensor is inactief en de robot stopt met het scannen van de omgeving."
        Detected, // "Er is beweging gedetecteerd!"
        NothingDetected, // "Gedurende de scanperiode is er geen beweging waargenomen."

        // Mentions

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

        // General Mentions

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
        TutorialStep4, // "Wanneer u een herinnering ontvangt, zal het rode lampje knipperen. Druk op het lampje om aan te geven dat u de herinnering heeft ontvangen."

        // Music

        FrancisWells, // Classic music
        Portal // 1 minute countdown...
    }  
    public class MusicLibrary 
    {
        private static readonly string _mainRoot = "/mnt/usb/SoundLibrary";
        protected static readonly Dictionary<Mentions, string> soundLibrary = new()
        {
            // Driving

            { Mentions.Stop, $"{_mainRoot}/stop.wav" },
            { Mentions.Start, $"{_mainRoot}/start.wav" },
            { Mentions.ObstacleDetected, $"{_mainRoot}/obstacle-detected.wav" },

            // Motionsensor

            { Mentions.Active, $"{_mainRoot}/active.wav" },
            { Mentions.Stopped, $"{_mainRoot}/stopped.wav" },
            { Mentions.Detected, $"{_mainRoot}/detected.wav" },
            { Mentions.NothingDetected, $"{_mainRoot}/nothing-detected.wav" },

            // General

            { Mentions.Welcome, $"{_mainRoot}/welcome.wav" },
            { Mentions.Warning, $"{_mainRoot}/warning.wav" },
            { Mentions.Shutdown, $"{_mainRoot}/shutdown.wav" },
            { Mentions.CountDown321, $"{_mainRoot}/countdown-321.wav" },
            { Mentions.Remaining30, $"{_mainRoot}/remaining-30.wav" },
            { Mentions.Paused, $"{_mainRoot}/paused.wav" },
            { Mentions.RobotActive, $"{_mainRoot}/robot-active.wav" },
            { Mentions.TutorialMention, $"{_mainRoot}/tutorial-mention.wav" },
            { Mentions.TutorialStep1, $"{_mainRoot}/tutorial-step-1.wav" },
            { Mentions.TutorialStep2, $"{_mainRoot}/tutorial-step-2.wav" },
            { Mentions.TutorialStep3, $"{_mainRoot}/tutorial-step-3.wav" },
            { Mentions.TutorialStep4, $"{_mainRoot}/tutorial-step-4.wav" },

            // Mentions

            { Mentions.Hi, $"{_mainRoot}/hi.wav" },
            { Mentions.Hello, $"{_mainRoot}/hello.wav" },
            { Mentions.GoodMorning, $"{_mainRoot}/goodmorning.wav" },
            { Mentions.GoodMidday, $"{_mainRoot}/goodmidday.wav" },
            { Mentions.GoodEvening, $"{_mainRoot}/goodevening.wav" },
            { Mentions.Bye_1, $"{_mainRoot}/bye-1.wav" },
            { Mentions.Bye_2, $"{_mainRoot}/bye-2.wav" },
            { Mentions.TimeToEat, $"{_mainRoot}/time-to-eat.wav" },
            { Mentions.TimeToBrushTeeth, $"{_mainRoot}/time-to-bursh-teeth.wav" }, // Woops, type but the file is like this in the robot
            { Mentions.TimeToSleep, $"{_mainRoot}/time-to-sleep.wav" },
            { Mentions.TimeToWakeUp, $"{_mainRoot}/time-to-wake-up.wav" },
            { Mentions.TurnOffLivingRoomLight, $"{_mainRoot}/turn-off-living-room-light.wav" },
            { Mentions.TimeForMedication, $"{_mainRoot}/time-for-medication.wav" },
            { Mentions.TimeToRest, $"{_mainRoot}/time-to-rest.wav" },
            { Mentions.TimeForExercise, $"{_mainRoot}/time-for-exercise.wav" },
            { Mentions.TimeToDrink, $"{_mainRoot}/time-to-drink.wav" },
            { Mentions.TimeToCheckBloodSugar, $"{_mainRoot}/time-to-check-blood-sugar.wav" },
            { Mentions.TimeForAppointment, $"{_mainRoot}/time-for-appointment.wav" },
            { Mentions.TimeToRelax, $"{_mainRoot}/time-to-relax.wav" },
            { Mentions.TimeToRead, $"{_mainRoot}/time-to-read.wav" },
            { Mentions.TimeToListenMusic, $"{_mainRoot}/time-to-listen-music.wav" },
            { Mentions.TimeToCallHealthCareProvider, $"{_mainRoot}/time-to-call-health-care-provider.wav" },
            { Mentions.TimeToCheckMail, $"{_mainRoot}/time-to-check-mail.wav" },
            { Mentions.TimeToWaterPlants, $"{_mainRoot}/time-to-water-plants.wav" },
            { Mentions.TimeToFeedPet, $"{_mainRoot}/time-to-feed-pet.wav" },
            { Mentions.TimeToShower, $"{_mainRoot}/time-to-shower.wav" },
            { Mentions.TimeToChangeClothes, $"{_mainRoot}/time-to-change-clothes.wav" },
            { Mentions.TimeToCheckCalendar, $"{_mainRoot}/time-to-check-calendar.wav" },
            { Mentions.TimeToDoExercise, $"{_mainRoot}/time-to-do-exercise.wav" },
            { Mentions.TimeToDoBreathingExercise, $"{_mainRoot}/time-to-do-breathing-exercise.wav" },
            { Mentions.TimeToDoStretching, $"{_mainRoot}/time-to-do-stretching.wav" },
            { Mentions.TimeToDoMemoryGame, $"{_mainRoot}/time-to-do-memory-game.wav" },
            { Mentions.TimeToDoPuzzle, $"{_mainRoot}/time-to-do-puzzle.wav" },
            { Mentions.TimeToDoCraft, $"{_mainRoot}/time-to-do-craft.wav" },
            { Mentions.TimeToDoGardening, $"{_mainRoot}/time-to-do-gardening.wav" },
            { Mentions.TimeToDoCooking, $"{_mainRoot}/time-to-do-cooking.wav" },
            { Mentions.TimeToDoCleaning, $"{_mainRoot}/time-to-do-cleaning.wav" },
            { Mentions.TimeToDoShopping, $"{_mainRoot}/time-to-do-shopping.wav" },
            { Mentions.TimeToDoLaundry, $"{_mainRoot}/time-to-do-laundry.wav" },
            { Mentions.TimeToDoIroning, $"{_mainRoot}/time-to-do-ironing.wav" },
            { Mentions.TimeToDoDishes, $"{_mainRoot}/time-to-do-dishes.wav" },
            { Mentions.TimeToDoReading, $"{_mainRoot}/time-to-do-reading.wav" },
            { Mentions.TimeToDoWriting, $"{_mainRoot}/time-to-do-writing.wav" },
            { Mentions.TimeToDoDrawing, $"{_mainRoot}/time-to-do-drawing.wav" },
            { Mentions.TimeToDoPainting, $"{_mainRoot}/time-to-do-painting.wav" },
            { Mentions.TimeToDoSinging, $"{_mainRoot}/time-to-do-singing.wav" },

            // Music

            { Mentions.FrancisWells, $"{_mainRoot}/Francis-Wells-Live-a-Little.wav" },
            { Mentions.Portal, $"{_mainRoot}/Portal-4000-Degrees-Kelvin.wav" }
        };
    }
}

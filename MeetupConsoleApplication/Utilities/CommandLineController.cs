using System;

namespace SemihCelekBarisKilic.MeetupConsoleApplication.Utilities
{
    public class CommandLineController
    {
        public void InitCommandLine()
        {
            var argumentSelection = Console.ReadKey();
        
            switch (argumentSelection.Key)
            {
                case ConsoleKey.C:
                    Console.WriteLine("c key is pressed");
                    break;
                case ConsoleKey.A:
                    Console.WriteLine("a key is pressed");
                    break;
            }
        }
    }
}
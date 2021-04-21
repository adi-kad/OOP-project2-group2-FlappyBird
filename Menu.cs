using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    //Storing menu alternatives/options in enum
    enum MenuOption
    {
        Start, HighScores, Quit
    }

    class Menu
    {
        public MenuOption option; 

        //Used for reading user keypress
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey consoleKey = new ConsoleKey();         

        public Menu()
        {
        }
      
        public MenuOption RunMenu()
        {
            PrintFlappyBird();
            Console.WriteLine("             Press [Spacebar] to start game\n\n" +
                              "             Press [H] to view high scores\n\n" +
                              "             Press [Escape] to exit program\n\n");

            keyInfo = Console.ReadKey(true);
            consoleKey = keyInfo.Key;

            //Set menu option depending on user keypress
            switch (consoleKey)
            {
                case ConsoleKey.Spacebar:
                    option = MenuOption.Start;
                    break;
                case ConsoleKey.H:
                    option = MenuOption.HighScores;
                    break;
                case ConsoleKey.Escape:
                    option = MenuOption.Quit;
                    break;
                default:
                    break;
            }

            return option;
        }

        //Printing out "logo"
        public void PrintFlappyBird()
        {
            string[] bird = new string[]
            {
                "             ───────────▄██████████████▄───────",
                "             ───────▄████░░░░░░░░█▀────█▄──────",
                "             ──────██░░░░░░░░░░░█▀──────█▄─────",
                "             ─────██░░░░░░░░░░░█▀────────█▄────",
                "             ────██░░░░░░░░░░░░█──────────██───",
                "             ───██░░░░░░░░░░░░░█──────██──██───",
                "             ──██░░░░░░░░░░░░░░█▄─────██──██───",
                "             ─████████████░░░░░░██────────██───",
                "             ██░░░░░░░░░░░██░░░░░█████████████",
                "             ██░░░░░░░░░░░██░░░░█▓▓▓▓▓▓▓▓▓▓▓▓▓█",
                "             ██░░░░░░░░░░░██░░░█▓▓▓▓▓▓▓▓▓▓▓▓▓▓█",
                "             ─▀███████████▒▒▒▒█▓▓▓███████████▀─",
                "             ────██▒▒▒▒▒▒▒▒▒▒▒▒█▓▓▓▓▓▓▓▓▓▓▓▓█──",
                "             ─────██▒▒▒▒▒▒▒▒▒▒▒▒██▓▓▓▓▓▓▓▓▓▓█──",
                "             ──────█████▒▒▒▒▒▒▒▒▒▒██████████───",
                "             ────────▀███████████▀────────────"
            };

            Console.WriteLine();
            for (int i = 0; i < bird.Length; i++)
            {
                //Console.SetCursorPosition(); TDB- place in a better position?
                Console.WriteLine(bird[i]);
            }
            Console.WriteLine();
        }

    }
}
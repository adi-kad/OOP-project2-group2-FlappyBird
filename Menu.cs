using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    enum MenuOption
    {
        Start, HighScores, Quit
    }

    class Menu
    {
        public MenuOption option;
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
                //Console.SetCursorPosition(); Placera i mitten kanske?
                Console.WriteLine(bird[i]);
            }
            Console.WriteLine();

        }

    }
}

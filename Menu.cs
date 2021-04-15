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

        public Menu()
        {

        }

        public MenuOption Start()
        {
            PrintFlappyBird();
            Console.WriteLine("1. Start   2. Highscores   3.Quit");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    option = MenuOption.Start;
                    break;
                case "2":
                    option = MenuOption.HighScores;
                    break;
                case "3":
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
                "───────────▄██████████████▄───────",
                "───────▄████░░░░░░░░█▀────█▄──────",
                "──────██░░░░░░░░░░░█▀──────█▄─────",
                "─────██░░░░░░░░░░░█▀────────█▄────",
                "────██░░░░░░░░░░░░█──────────██───",
                "───██░░░░░░░░░░░░░█──────██──██───",
                "──██░░░░░░░░░░░░░░█▄─────██──██───",
                "─████████████░░░░░░██────────██───",
                "██░░░░░░░░░░░██░░░░░█████████████",
                "██░░░░░░░░░░░██░░░░█▓▓▓▓▓▓▓▓▓▓▓▓▓█",
                "██░░░░░░░░░░░██░░░█▓▓▓▓▓▓▓▓▓▓▓▓▓▓█",
                "─▀███████████▒▒▒▒█▓▓▓███████████▀─",
                "────██▒▒▒▒▒▒▒▒▒▒▒▒█▓▓▓▓▓▓▓▓▓▓▓▓█──",
                "─────██▒▒▒▒▒▒▒▒▒▒▒▒██▓▓▓▓▓▓▓▓▓▓█──",
                "──────█████▒▒▒▒▒▒▒▒▒▒██████████───",
                "────────▀███████████▀────────────"
            };

            for (int i = 0; i < bird.Length; i++)
            {
                //Console.SetCursorPosition(); Placera i mitten kanske?
                Console.WriteLine(bird[i]);
            }
            Console.WriteLine();

        }

    }
}

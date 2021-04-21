using System;
using System.Threading;

namespace FlappyBird
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Game game = new Game();

            try
            {
                game.highScore.LoadFile(); //Function which loads the file with saved high scores
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            while (menu.option != MenuOption.Quit) 
            {
                Console.Clear();
                menu.RunMenu();
                game.highScore.WriteToFile();
                if (menu.option == MenuOption.Start)
                {                  
                    game.SetUp();

                    while (!game.isOver)
                    {
                        game.Run();
                    }
                    if (game.isOver)
                    {
                        game.highScore.CheckTopHighScore();
                    }
                }
                if (menu.option.Equals(MenuOption.HighScores))
                {
                    game.highScore.PrintHighScore();
                }
            }
        }
    }
}
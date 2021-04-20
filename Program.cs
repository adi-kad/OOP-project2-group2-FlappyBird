using System;
using System.Threading;

namespace FlappyBird
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(); 
            
            while (menu.option != MenuOption.Quit)
            {
                Console.Clear();
                menu.RunMenu();
                if (menu.option == MenuOption.Start)
                {
                    Game game = new Game();
                    game.SetUp();

                    while (!game.isOver/*is.Exited*/)
                    {
                        game.Run();
                    }
                    if (game.isOver)
                    {
                        //checkIfScoreIsOnHighscoreList();
                    }
                }
                if (menu.option.Equals(MenuOption.HighScores))
                {
                    HighScore scoreBoard = new HighScore();
                    scoreBoard.PrintHighScore();
                }
            }
        }

    }
}

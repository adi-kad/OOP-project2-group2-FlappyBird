using System;
using System.Threading;

namespace FlappyBird
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();          
            menu.RunMenu();

            while (menu.option != MenuOption.Quit)
            {
                if (menu.option == MenuOption.Start)
                {
                    Game game = new Game();
                    game.SetUp();

                    while (!game.isOver/*is.Exited*/)
                    {
                        game.Run();
                    }
                }
            }
        }

    }
}

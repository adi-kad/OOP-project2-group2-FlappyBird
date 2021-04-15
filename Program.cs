using System;
using System.Threading;

namespace FlappyBird
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();          
            menu.Start();

            if (menu.option == MenuOption.Start)
            {
                Game game = new Game();
                game.SetUp();

                while (!game.isOver)
                {
                    game.Run();
                }
            }


        }

    }
}

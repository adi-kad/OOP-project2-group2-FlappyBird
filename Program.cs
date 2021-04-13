using System;
using System.Threading;

namespace FlappyBird
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            bool gameIsRunning = true;
            while (gameIsRunning)
            {
                //Game.Run();
                Console.Clear();
                board.DrawBoard();
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }

    }
}

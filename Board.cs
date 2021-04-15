using System;
using System.Linq;
using System.Collections;
namespace FlappyBird
{
    class Board : Game
    {
        int height;
        private int width = Console.WindowWidth;
        int obsheight = 10;
        int obswidth = 4;
        int gate = 8;
        int obsFloor;
        int score = 0;
        public Board()
        {
            this.height = 25;
        }

        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void Draw(Bird bird)
        {
            bird.DrawBird();
        }

        public void Draw(int x /*Obstacle x*/)
        {
            //Obstacle Obstacle1 = new Obstacle("Obstacle1", 10, 40);
            //Obstacle Obstacle2 = new Obstacle("Obstacle2", 8, 60);
            //Obstacle Obstacle3 = new Obstacle("Obstacle3", 14, 70);
            //Obstacle Obstacle4 = new Obstacle("Obstacle4", 18, 80);
            //Obstacle[] obstacles = { Obstacle1, Obstacle2, Obstacle3, Obstacle4};
            obsFloor = obsheight + gate;
            for (int i = 1; i < height /*Obstacle Height NYI*/; i++)
            {
                if (i < obsheight | i >= obsFloor)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(x, i);
                    Console.Write(String.Concat(Enumerable.Repeat(" ", obswidth /*width*/)));
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void DrawBoard()
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("_");
            }

            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, height);
                Console.Write("_");
            }
            Console.SetCursorPosition(width/2 - 10 , height + 2);
            Console.WriteLine($"Score: {score}");
        }

    }
}

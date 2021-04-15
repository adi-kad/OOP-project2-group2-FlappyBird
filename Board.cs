using System;
using System.Linq;

namespace FlappyBird
{

    class Board : Game , IDimensions
    {
        
        public int width { get ; set ; }
        public int height { get ; set ; }

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

        public void Draw(int x /*Obstacle[] obstacles*/)
        {
            for (int i = 1; i < 10 /*Obstacle Height NYI*/; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, i);
                Console.Write(String.Concat(Enumerable.Repeat(" ", 4 /*width*/)));
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

        }

    }
}

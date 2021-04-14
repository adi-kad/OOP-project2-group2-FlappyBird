using System;

namespace FlappyBird
{
    class Board
    {
        int height;
        int width = Console.WindowWidth;
        
        public Board()
        {
            this.height = 25;
        }

        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;
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

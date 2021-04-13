using System;

namespace FlappyBird
{
    partial class Program
    {
        class Board
        {
            int height;
            int width;
            Bird bird;

            public Board()
            {
                this.height = 30;
                this.width = 100;
                this.bird = new Bird();
            }

            public Board(int height, int width)
            {
                this.height = height;
                this.width = width;
            }

            public void DrawBoard()
            {

                for (int x = 0; x < width; x++)
                {
                    
                    if (x == width-1)
                    {
                        Console.WriteLine("─");
                    }
                    else { 
                        Console.Write("─"); 
                    }
                    
                }

                for (int y = 0; y < height; y++)
                {
                    bird.DrawBird();
                }


                for (int x = 0; x < width; x++)
                {

                    if (x == width - 1)
                    {
                        Console.WriteLine("─");
                    }
                    else
                    {
                        Console.Write("─");
                    }

                }
             
            }

        }

    }
}

using System;
using System.Linq;
using System.Collections;
namespace FlappyBird
{
    class Board : Game
    {

        private int height;
        public int Height { get { return height; }}
        private int width = Console.WindowWidth;
        int defaultObsWidth = 0;
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

        public void Draw(Obstacle[] obstacles)
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                defaultObsWidth = obstacles[i].SetObstacleWidth();
                if (obstacles[i].xpos == 0)
                {
                    Random rnd = new Random();
                    obstacles[i].height = rnd.Next(0, 23);
                    obstacles[i].xpos = Console.WindowWidth - 1;
                    obstacles[i].obsFloor = obstacles[i].height + obstacles[i].gate;
                    obstacles[i].width = 1;
                }
                else if (obstacles[i].xpos <= obstacles[i].width)
                {
                    obstacles[i].width--;
                }
                else if (obstacles[i].xpos >= width - defaultObsWidth)
                {
                    obstacles[i].width++;
                }
                for (int j = 1; j <= height; j++)
                {

                    if (j < obstacles[i].height | j >= obstacles[i].obsFloor)
                    {
                        if (i == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (i == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        else if (i == 2)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        else if (i == 3)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        }
                        Console.SetCursorPosition(obstacles[i].xpos, j);
                        Console.Write(String.Concat(Enumerable.Repeat(" ", obstacles[i].width)));
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void DrawBoard(HighScore highScore)
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("_");
            }

            for (int i = 0; i < width; i++)
            {
                //Console.BackgroundColor = ConsoleColor.Green;

                Console.SetCursorPosition(i, height);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("/");
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.BackgroundColor = ConsoleColor.Blue;
            }
            Console.SetCursorPosition(width / 2 - 10, height + 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Score: {highScore.Score}");
        }
        public void DrawPaused()
        {
            Console.SetCursorPosition(width / 2 - 10, height / 2);
            Console.WriteLine("Game is paused...press any key to continue");
        }
        public void DrawCollision()
        {
            Console.SetCursorPosition(width / 2 - 10, height / 2);
            Console.WriteLine("You crashed...");
        }
    }
}

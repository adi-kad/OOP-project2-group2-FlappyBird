using System;
using System.Linq;
using System.Collections;
namespace FlappyBird
{

    class Board : Game , IDimensions
    {
        //int obsheight = 10;
        //int obswidth = 4;
        //int gate = 8;
        int obsFloor;
        //int score = 0;

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

        public void Draw(Obstacle[] obstacles)
        {
            //Obstacle Obstacle1 = new Obstacle("Obstacle1", 10, 50);
            //Obstacle Obstacle2 = new Obstacle("Obstacle2", 8, 70);
            //Obstacle Obstacle3 = new Obstacle("Obstacle3", 14, 90);
            //Obstacle Obstacle4 = new Obstacle("Obstacle4", 18, 110);
            //Obstacle[] obstacles = { Obstacle1, Obstacle2, Obstacle3, Obstacle4};
            for (int i = 0; i < obstacles.Length; i++)
            {
                obsFloor = obstacles[i].height + obstacles[i].gate;
                for (int j = 1; j < height /*Obstacle Height NYI*/; j++)
                {
                    if (obstacles[i].xpos == 5)
                    {
                        Random rnd = new Random();
                        obstacles[i].height = rnd.Next(0, 23);
                        obstacles[i].xpos = Console.WindowWidth - 4;
                        //obstacles[i].width = 4;
                    }
                    
                    else
                    {
                        if (j < obstacles[i].height | j >= obsFloor)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(obstacles[i].xpos, j);
                            Console.Write(String.Concat(Enumerable.Repeat(" ", 4 /*obstacles[i].width*/ /*width*/)));
                            
                        }
                        //obstacles[i].xpos--;
                    }
                    //if (obstacles[i].width <= obstacles[i].xpos)
                    //{
                    //    obstacles[i].width--;
                    //    obstacles[i].xpos--;
                    //}
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FlappyBird
{
    class Game
    {
        Board board;
        public Bird bird;
        
        protected Obstacle[] obstacles;
        protected int score;
        public bool isPaused;
        public bool isOver;
        

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey consoleKey = new ConsoleKey();

        public Game()
        {
            
        }

        public void SetUp()
        {
            bird = new Bird();
            //obstacles = new Obstacle[5];
            score = 0;
            board = new Board();
            isOver = false;
            isPaused = false;
            Obstacle Obstacle1 = new Obstacle("Obstacle1", 10, 50);
            Obstacle Obstacle2 = new Obstacle("Obstacle2", 8, 70);
            Obstacle Obstacle3 = new Obstacle("Obstacle3", 14, 90);
            Obstacle Obstacle4 = new Obstacle("Obstacle4", 18, 110);
            obstacles = new Obstacle[] { Obstacle1, Obstacle2, Obstacle3, Obstacle4 };
        }

        //int x = 25;
        public void Run()
        {     
            Console.Clear();
            CheckKeyPress();

            board.DrawBoard();
            board.Draw(bird);       
            board.Draw(obstacles);
            // kommer inte åt obstacles[i].xpos
            for (int i = 0; i < 4; i++)
            {
                obstacles[i].xpos--;
            }

            Thread.Sleep(100);          
        }

        public void CheckKeyPress()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }

            if (consoleKey == ConsoleKey.Spacebar)
            {
                bird.Jump();
            }
            else if (consoleKey == ConsoleKey.Escape)
            {
                isOver = true;
            }
            else
            {
                bird.Fall();
            }
            consoleKey = ConsoleKey.A;
        }



    }
   
}

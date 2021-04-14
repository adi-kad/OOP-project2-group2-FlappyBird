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
            obstacles = new Obstacle[5];
            score = 0;
            board = new Board();
            isOver = false;
            isPaused = false;
        }
    
        public void Run()
        {
            Console.Clear();
            
            board.DrawBoard();
            board.Draw(bird);
            //board.Draw(Hinder) - TBD/NYI
            CheckKeyPress();
            
            //Någon keypress check för pause/exit/gå tillbaka till menyn/starta om? //TBD
            
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
                this.isOver = true;
            }
            else
            {
                bird.Fall();
            }
            consoleKey = ConsoleKey.A;
        }



    }
   
}

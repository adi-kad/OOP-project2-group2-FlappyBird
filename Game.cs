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
            bird.DrawBird();
            bird.CheckKeyPress();
           
            Thread.Sleep(100);          
        }       
        
    }
   
}

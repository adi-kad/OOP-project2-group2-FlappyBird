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
        public HighScore highScore = new HighScore();
        protected Obstacle[] obstacles;
        public bool isOver;
        public bool isPaused;
        bool collision = false;
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey consoleKey = new ConsoleKey();

        public Game()
        {
        }

        public void SetUp()
        {
            bird = new Bird();
            board = new Board();          
            isOver = false;
            isPaused = false;
            Obstacle Obstacle1 = new Obstacle("Obstacle1", 10, 33);
            Obstacle Obstacle2 = new Obstacle("Obstacle2", 8, 65);
            Obstacle Obstacle3 = new Obstacle("Obstacle3", 14, 89);
            Obstacle Obstacle4 = new Obstacle("Obstacle4", 18, 113);
            obstacles = new Obstacle[] { Obstacle1, Obstacle2, Obstacle3, Obstacle4 };
        }
        public void Run()
        {
            Console.Clear();
            CheckKeyPress();
            board.DrawBoard(highScore);
            board.Draw(bird);
            board.Draw(obstacles);
            for (int i = 0; i < obstacles.Length; i++)
            {
                collision = CheckCollision(i);
                if (!collision)
                {
                    UpdatePosition(i);
                    highScore.Update(obstacles, bird, i);
                }
                else
                {
                    GameOver();
                }
            }
            // higher speed if you get longer in the game
            if (highScore.Score < 3)
            {
                Thread.Sleep(100);
            }
            else if (highScore.Score < 6)
            {
                Thread.Sleep(80);
            }
            else if (highScore.Score < 10)
            {
                Thread.Sleep(50);
            }
            else
            {
                Thread.Sleep(30);
            }
            if (isPaused)
            {
                board.DrawPaused();
                bird.Fall();
                bird.Jump();
                Console.ReadKey();
                isPaused = false;
            }
        }
        private void GameOver()
        {
            board.DrawCollision();
            isOver = true;
        }

        //Moving obstacle to the left
        private void UpdatePosition(int i)
        {
            obstacles[i].xpos--;
        }

        //Checking if objects collide or out of bounds
        private bool CheckCollision(int i)
        {
            if (obstacles[i].xpos == bird.X
                                || obstacles[i].xpos + obstacles[i].width == bird.X
                                || obstacles[i].xpos == bird.X + bird.BirdType.Length
                                || obstacles[i].xpos + obstacles[i].width == bird.X + bird.BirdType.Length
                                || obstacles[i].xpos == bird.X + bird.BirdType.Length - 1
                                || obstacles[i].xpos == bird.X + bird.BirdType.Length - 2
                                || obstacles[i].xpos == bird.X + bird.BirdType.Length - 3
                                )
            {
                if (bird.Y < obstacles[i].height)
                {
                    return true;
                }
                else if (bird.Y >= obstacles[i].obsFloor)
                {
                    return true;
                }
                else
                    return false;
            }
            else if (bird.Y == 0 || bird.Y == board.height)
            {
                return true;
            }
            else
                return false;
        }

        public void CheckKeyPress()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }

            //if user presses up arrow key or spacebar key, then bird will move up
            if (consoleKey == ConsoleKey.UpArrow || consoleKey == ConsoleKey.Spacebar)
            {
                bird.Jump();
            }
            else if (consoleKey == ConsoleKey.DownArrow) // if user presses key down then bird will move down
            {
                for (int i = 0; i < 2; i++)
                {
                    bird.Fall();
                }
            }
            else if (consoleKey == ConsoleKey.P) // Game will be paused if user presses P key
            {
                isPaused = true;
            }
            else if (consoleKey == ConsoleKey.Escape) //Game over if user presses Escape key
            {
                isOver = true;
            }
            else //else bird will fall down to gravity
            {
                bird.Fall(); 
            }
            consoleKey = ConsoleKey.A; // Resetting console key
        }
    }
}
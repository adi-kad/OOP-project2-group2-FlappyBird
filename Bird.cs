using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class Bird
    {
        public int X;
        public int Y;
        public string FlyingBird { get; set; }

        public Bird(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Bird()
        {
            X = 20;
            Y = 5;
            FlyingBird = "/^v^\\";
        }

        public void Jump() 
        {
            Y-=2;
        }

        public void Fall() 
        {
            Y++;
        }
    
        public void DrawBird()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(FlyingBird);
        }
       
    }
}

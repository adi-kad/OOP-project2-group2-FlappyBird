﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class Bird
    {
        public int X;
        public int Y;
        public string BirdType { get; set; }

        public Bird(int x, int y)
        {
            X = x;
            Y = y;
            BirdType = "<>?<>";
        }

        public Bird()
        {
            X = 20;
            Y = 5;
            BirdType = "<>?<>";
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
            Console.WriteLine(BirdType);
        }
       
    }
}

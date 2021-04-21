using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class Bird
    {

        public int X { get; set; } //position on the x-axis. Increased value moves object to the right
        public int Y { get; set; } //position on the y-axis. Increased value moves object downwards
        public string BirdType { get; set; } = "<>?<>";
        public bool flapping; //true if object is moving up
      
        public Bird(int x, int y)
        {
            X = x;
            Y = y;
            BirdType = "<>?<>";
        }

        public Bird()
        {
            X = 16;
            Y = 12;
            BirdType = "<>?<>";
        }

        public void Jump() 
        {
            Y-=2;
            flapping = true;
        }

        public void Fall() 
        {
            Y++;
            flapping = false;
        }
            
        public void DrawBird()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            if (flapping)
            {
                Console.WriteLine(@"//?\\");
            }
            else
                Console.WriteLine(@"\\?//");
        }     
    }
}

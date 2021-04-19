using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class Bird
    {

        public int X { get; set; }
        public int Y { get; set; }
        public string BirdType { get; set; } = "<>?<>";
        public bool flapping;
      
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

            //Console.WriteLine(birdType);
            if (flapping)
            {
                Console.WriteLine(@"//?\\");
            }
            else
                Console.WriteLine(@"\\?//");

        }
       
    }
}

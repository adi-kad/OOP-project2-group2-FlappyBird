using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class Bird
    {
        public int x;
        public int y;
        int fallSpeed;

        public Bird(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Bird()
        {
            this.x = 25;
            this.y = 15;
        }

        public void Jump() 
        {
        }

        public void Fall() 
        {
        }
    
        public void DrawBird()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.WriteLine("<>?<>");
        }

    }
}

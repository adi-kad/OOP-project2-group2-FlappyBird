using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class Bird
    {
        public int X;
        public int Y;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey consoleKey = new ConsoleKey();

        public Bird(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Bird()
        {
            X = 25;
            Y = 5;
        }

        public void Jump() 
        {
            Y--;
        }

        public void Fall() 
        {
            Y++;
        }
    
        public void DrawBird()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("<>?<>");
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
                this.Jump();
            }
            else
            {
                this.Fall();
            }
            consoleKey = ConsoleKey.A;
        }

    }
}

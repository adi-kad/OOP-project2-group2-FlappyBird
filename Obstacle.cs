﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    class Obstacle
    {
        public string name { get; set; }
        public int height{ get; set; }
        public int width { get; set; }
        public int gate { get; set; }
        public int xpos { get; set; }
        public Obstacle(string name, int height, int xpos)
        {
            this.height = height;
            this.width = 4;
            this.gate = 8;
            this.name = name;
        }
    }
}

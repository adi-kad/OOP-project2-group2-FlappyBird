using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    public class Obstacle : IDimensions
    {
        public string name { get; set; }
        public int height{ get; set; }
        public int width { get; set; }
        public int gate { get; set; }
        public int xpos { get; set; }
        public int obsFloor { get; set; }
        public Obstacle(string name, int height, int xpos)
        {
            this.height = height;
            this.width = 6;
            this.gate = 8;
            this.name = name;
            this.xpos = xpos;
            this.obsFloor = this.height + this.gate;
        }
        public int SetObstacleWidth()
        {
            int defaultWidth = 6;
            return defaultWidth;
        }
    }  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class Board
    {
        /// <summary>
        /// Initialize the board by defining its dimension
        /// </summary>
        /// <param name="width">Width of the board</param>
        /// <param name="height">Height of the board</param>
        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        
    }
}

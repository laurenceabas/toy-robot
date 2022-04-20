using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class Position
    {
        /// <summary>
        /// Empty constructor for the class
        /// </summary>
        public Position()
        {
            ErrorMessage = string.Empty;
        }


        /// <summary>
        /// Initialize the position of the toy robot.
        /// </summary>
        /// <param name="x">Initial location on x-axis on the board</param>
        /// <param name="y">Initial location on y-axix on the board</param>
        /// <param name="direction">Initial direction of the robot where it is facing</param>
        public Position(int x, int y, string direction) : this()
        {
            X = x;
            Y = y;

            Direction = ConvertToDirection(direction);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Direction Direction { get; set; }

        public string ErrorMessage { get; set; }

        /// <summary>
        /// Compare the position and direction the object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var objPost = (Position)obj;

            return objPost.Direction == Direction &&
                    objPost.X == X &&
                    objPost.Y == Y;

        }

        /// <summary>
        /// Convert the string direction to a numerical value based from enum.
        /// </summary>
        /// <param name="direction">Defined direction in string data type.</param>
        /// <returns></returns>
        private Direction ConvertToDirection(string direction)
        {
            switch (direction.ToLowerInvariant())
            {
                case "north":
                    return Direction.North;
                case "east":
                    return Direction.East;
                case "south":
                    return Direction.South;
                case "west":
                default:
                    return Direction.West;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

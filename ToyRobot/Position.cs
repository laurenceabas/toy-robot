using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class Position
    {

        public Position()
        {
            ErrorMessage = string.Empty;
        }

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


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var objPost = (Position)obj;

            return objPost.Direction == Direction &&
                    objPost.X == X &&
                    objPost.Y == Y;

        }

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

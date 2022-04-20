using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    public class Robot
    {
        private readonly Position m_currentPosition;
        private readonly Board m_currentBoard;

        /// <summary>
        /// Initialize the robot's position based on the board's dimension
        /// </summary>
        /// <param name="currentPosition">Initial position of the robot</param>
        /// <param name="board">Board's dimension</param>
        public Robot(Position currentPosition, Board board)
        {
            m_currentPosition = currentPosition;
            m_currentBoard = board;
        }

        /// <summary>
        /// Move the robot forward where it is currently facing.
        /// </summary>
        /// <returns></returns>
        public bool MoveForward()
        {
            int newX = m_currentPosition.X;
            int newY = m_currentPosition.Y;

            switch (m_currentPosition.Direction)
            {
                case Direction.North:
                    newY++;
                    break;
                case Direction.East:
                    newX++;
                    break;
                case Direction.South:
                    newY--;
                    break;
                case Direction.West:
                    newX--;
                    break;
            }

            if(IsInBounds(newX, newY))
            {
                m_currentPosition.X = newX;
                m_currentPosition.Y = newY;

                m_currentPosition.ErrorMessage = string.Empty;
            }
            else
            {
                m_currentPosition.ErrorMessage = "Robot will fall off the board";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate if the robot is still in the board and checks if moving forward would make it fall.
        /// </summary>
        /// <param name="x">New value of the x-axis</param>
        /// <param name="y">New value of the y-axis</param>
        /// <returns></returns>
        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x <= m_currentBoard.Width && y <= m_currentBoard.Height;
        }

        /// <summary>
        /// Returns the current position and the direction where the robot is located and facing.
        /// </summary>
        /// <returns></returns>
        public Position GetCurrentPosition()
        {
            return m_currentPosition;
        }

        /// <summary>
        /// Reports the robot's current position.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            if (m_currentPosition == null)
                return base.ToString();

            return $"{m_currentPosition.X},{m_currentPosition.Y},{m_currentPosition.Direction.ToString().ToUpper()}";
        }

        /// <summary>
        /// Before moving forward, the robot needs to turn based on the direction.
        /// </summary>
        /// <param name="turn">Rotation to turn to.</param>
        public void Rotate(Rotation turn)
        {
            switch (turn)
            {
                case Rotation.Left:
                    RotateLeft();
                    break;
                case Rotation.Right:
                    RotateRight();
                    break;
            }
        }

        private void RotateRight()
        {
            switch (m_currentPosition.Direction)
            {
                case Direction.North:
                    m_currentPosition.Direction = Direction.East;
                    break;
                case Direction.East:
                    m_currentPosition.Direction = Direction.South;
                    break;
                case Direction.South:
                    m_currentPosition.Direction = Direction.West;
                    break;
                case Direction.West:
                    m_currentPosition.Direction = Direction.North;
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (m_currentPosition.Direction)
            {
                case Direction.North:
                    m_currentPosition.Direction = Direction.West;
                    break;
                case Direction.East:
                    m_currentPosition.Direction = Direction.North;
                    break;
                case Direction.South:
                    m_currentPosition.Direction = Direction.East;
                    break;
                case Direction.West:
                    m_currentPosition.Direction = Direction.South;
                    break;
                default:
                    break;
            }
        }
    }
}

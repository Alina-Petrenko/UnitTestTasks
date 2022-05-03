using System;
using System.Text;

namespace SecondTask
{
    /// <summary>
    /// Class represents point
    /// </summary>
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Compares two values
        /// </summary>
        /// <param name="obj">Compared value</param>
        /// <returns>Returns true, if values are the same and false if values are different</returns>
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        /// <summary>
        /// Gets hash code of value
        /// </summary>
        /// <returns>Returns Hash Code of value</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        /// <summary>
        /// Converts the value as a string
        /// </summary>
        /// <returns>Returns converted value</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Point: X = {X}, Y = {Y}.");
            return stringBuilder.ToString();
        }
        public static Point operator +(Point firstPoint, Point secondPoint)
        {
            return new Point { X = firstPoint.X + secondPoint.X, Y = firstPoint.Y + secondPoint.Y };
        }
        public static Point operator -(Point firstPoint, Point secondPoint)
        {
            return new Point { X = firstPoint.X - secondPoint.X, Y = firstPoint.Y - secondPoint.Y };
        }
        public static bool operator ==(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X == secondPoint.X && firstPoint.Y == secondPoint.Y)
                return true;
            else
                return false;
        }
        public static bool operator !=(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X != secondPoint.X || firstPoint.Y != secondPoint.Y)
                return true;
            else
                return false;
        }
    }

}

using System;
using System.Collections.Generic;

namespace SecondTask
{
    /// <summary>
    /// Class represents Segment
    /// </summary>
    public struct Segment
    {
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
        public Segment(Point firstPoint, Point secondPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
        }

        /// <summary>
        /// Calculates length of segment
        /// </summary>
        /// <returns>Returns length of segment</returns>
        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(SecondPoint.X - FirstPoint.X, 2) + Math.Pow(SecondPoint.Y - FirstPoint.Y, 2));
        }

        /// <summary>
        /// Compares two values
        /// </summary>
        /// <param name="obj">Compared value</param>
        /// <returns>Returns true, if values are the same and false if values are different</returns>
        public override bool Equals(object obj)
        {
            return obj is Segment segment &&
                   EqualityComparer<Point>.Default.Equals(FirstPoint, segment.FirstPoint) &&
                   EqualityComparer<Point>.Default.Equals(SecondPoint, segment.SecondPoint);
        }

        /// <summary>
        /// Gets hash code of value
        /// </summary>
        /// <returns>Returns Hash Code of value</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstPoint.GetHashCode(), SecondPoint.GetHashCode());
        }
    }
}

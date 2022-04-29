using System;
using System.Linq;
using System.Text;

namespace SecondTask
{
    /// <summary>
    /// Class represents triangle
    /// </summary>
    public sealed class Triangle : Polygon, ICloneable, IComparable
    {
        public Triangle(Segment[] segments, int Id): base(segments, Id)
        {
            if (segments.Length != 3)
            {
                throw new InvalidOperationException("Wrong count of sides.");
            }
            this.Segments = new Segment[3];
            for (var i = 0; i < segments.Length; i++)
            {
                this.Segments[i] = segments[i];
            }
            this.Id = Id;
        }

        /// <summary>
        /// Calculates the area of triangle
        /// </summary>
        /// <returns>Returns the area of triangle</returns>
        public sealed override double GetArea()
        {
            var sumOfSegments = 0d;
            for (int i = 0; i < Segments.Length; i++)
            {
                sumOfSegments += Segments[i].GetLength();
            }
            var p = sumOfSegments / 2;
            return (double)Math.Round(Math.Sqrt(Math.Abs(p * (p - Segments[0].GetLength()) * (p - Segments[1].GetLength()) * (p - Segments[2].GetLength()))), 2);
        }

        /// <summary>
        /// Generates random coordinates for triangle
        /// </summary>
        /// <returns>Returns array with random points</returns>
        public static Segment[] GetRandomCoordinatesForTriangle()
        {
            var random = new Random();
            Point[] points = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                var randomPoint = new Point();
                randomPoint.X = random.GetRandomPoint().X;
                randomPoint.Y = random.GetRandomPoint().Y;
                if (i < 3 && !points.Contains(randomPoint))
                {
                    points[i].X = random.GetRandomPoint().X;
                    points[i].Y = random.GetRandomPoint().Y;
                }
            }

            var newSegments = GetSegments(points);
            return newSegments;
        }

        /// <summary>
        /// Compares two values
        /// </summary>
        /// <param name="obj">Compared value</param>
        /// <returns>Returns true, if values are the same and false if values are different</returns>
        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                   Id == triangle.Id &&
                   Segments.SequenceEqual(triangle.Segments);
        }

        /// <summary>
        /// Gets hash code of value
        /// </summary>
        /// <returns>Returns Hash Code of value</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var segments in Segments)
            {
                hash ^= segments.GetHashCode();
            }
            return HashCode.Combine(Id, Segments);
        }

        /// <summary>
        /// Converts the value as a string
        /// </summary>
        /// <returns>Returns converted value</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {nameof(Triangle)}");
            for (int i = 0; i < this.Segments.Length; i++)
            {
                stringBuilder.AppendLine($"Point #{i + 1}: X = {this.Segments[i].FirstPoint.X}, Y = {this.Segments[i].FirstPoint.Y}.");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="obj">Object for comparison</param>
        /// <returns>Returns result of comparison</returns>
        /// <exception cref="ArgumentException">Object is not a Triangle</exception>
        public new int CompareTo(object obj)
        {
            if (!(obj is Triangle))
                throw new ArgumentException("Object is not a Triangle");
            Triangle triangle = (Triangle)obj;
            var firstTriangle = this.GetArea();
            var secondTriangle = triangle.GetArea();
            if (firstTriangle > secondTriangle)
                return 1;
            else if (secondTriangle > firstTriangle)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Clones an object
        /// </summary>
        /// <returns>Returns the cloned object</returns>
        public new object Clone()
        {
            var newTriangle = (Triangle)this.MemberwiseClone();
            var segments = new Segment[this.Segments.Length];
            for (int i = 0; i < this.Segments.Length; i++)
            {
                segments[i].FirstPoint = this.Segments[i].FirstPoint;
                segments[i].SecondPoint = this.Segments[i].SecondPoint;
            }
            newTriangle.Segments = segments;
            return newTriangle;
        }

        /// <summary>
        /// Converts an array of segments to a Triangle object
        /// </summary>
        /// <param name="segments">Array of segments</param>
        public static implicit operator Triangle(Segment[] segments)
        {
            return new Triangle(segments, 4);
        }

        /// <summary>
        /// Converts a Hexagon object to an array of segments
        /// </summary>
        /// <param name="triangle">Hexagon</param>
        public static explicit operator Segment[](Triangle triangle)
        {
            return triangle.Segments;
        }
    }
}



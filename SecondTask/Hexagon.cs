using System;
using System.Linq;
using System.Text;

namespace SecondTask
{
    /// <summary>
    /// Class represents hexagon
    /// </summary>
    public class Hexagon : Polygon, IComparable, ICloneable
    {
        // TODO: parameter "Id" should be renamed into "id".
        // TODO: all the input parameters should always be in camel case 
        public Hexagon(Segment[] segments, int Id) : base(segments, Id)
        {
            if (segments.Length != 6)
            {
                // TODO: not covered by unit tests
                throw new InvalidOperationException("Wrong count of sides.");
            }

            this.Segments = new Segment[6];
            for (var i = 0; i < segments.Length; i++)
            {
                this.Segments[i] = segments[i];
            }
            this.Id = Id;
        }

        /// <summary>
        /// Calculates the area of hexagon
        /// </summary>
        /// <returns>Returns the area of hexagon</returns>
        public override double GetArea()
        {
            double sum = 0;
            for (var iterator = 0; iterator < this.Segments.Length; iterator++)
            {
                sum += (this.Segments[iterator].FirstPoint.X + this.Segments[iterator].SecondPoint.X) *
                       (this.Segments[iterator].FirstPoint.Y - this.Segments[iterator].SecondPoint.Y);
            }
            return (double)(0.5f * Math.Abs(sum));
        }

        /// <summary>
        /// Generates random coordinates for hexagon
        /// </summary>
        /// <returns>Returns array with random points</returns>
        public static Segment[] GetRandomCoordinatesForHexagon()
        {
            var random = new Random();
            Point[] points = new Point[6];
            for (int i = 0; i < points.Length; i++)
            {
                var randomTuple = random.GetRandomPoint();
                var randomPoint = new Point(randomTuple.X, randomTuple.Y);
                if (i < 3 && !points.Contains(randomPoint))
                {
                    points[i].X = randomPoint.X;
                    points[i].Y = randomPoint.Y;
                }
                else if (i == 3)
                {
                    Point point = new Point();
                    var isSuccess = false;
                    while (!isSuccess)
                    {
                        point.X = random.GetRandomPoint().X;
                        point.Y = random.GetRandomPoint().Y;
                        if (!points.Contains(point)
                            && !LineIntersectionCheck(points[0], points[1], points[2], point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            isSuccess = true;
                        }
                        else
                            isSuccess = false;
                    }
                }
                else if (i == 4)
                {
                    Point point = new Point();
                    var isSuccess = false;
                    while (!isSuccess)
                    {
                        point.X = random.GetRandomPoint().X;
                        point.Y = random.GetRandomPoint().Y;
                        if (!points.Contains(point)
                            && !LineIntersectionCheck(points[0], points[1], points[3], point)
                            && !LineIntersectionCheck(points[1], points[2], points[3], point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            isSuccess = true;
                        }
                        else
                            isSuccess = false;
                    }
                }
                else if (i == 5)
                {
                    Point point = new Point();
                    var isSuccess = false;
                    while (!isSuccess)
                    {
                        point.X = random.GetRandomPoint().X;
                        point.Y = random.GetRandomPoint().Y;
                        if (!points.Contains(point)
                            && !LineIntersectionCheck(points[0], points[1], points[4], point)
                            && !LineIntersectionCheck(points[1], points[2], points[4], point)
                            && !LineIntersectionCheck(points[2], points[3], points[4], point)
                            && !LineIntersectionCheck(points[1], points[2], points[0], point)
                            && !LineIntersectionCheck(points[2], points[3], points[0], point)
                            && !LineIntersectionCheck(points[3], points[4], points[0], point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            isSuccess = true;
                        }

                        else
                            isSuccess = false;
                    }
                }
            }
            var newSegments = GetSegments(points);
            return newSegments;
        }

        /// <summary>
        /// Checks segments for intersections
        /// </summary>
        /// <param name="firstPointFirstSegment">First point of first segment</param>
        /// <param name="secondPointFirstSegment">Second point of first segment</param>
        /// <param name="firstPointSecondSegment">First point of second segment</param>
        /// <param name="secondPointSecondSegment">Second point of second segment</param>
        /// <returns>Returns a value based on the presence of an intersection</returns>
        private static bool LineIntersectionCheck(Point firstPointFirstSegment, Point secondPointFirstSegment, Point firstPointSecondSegment, Point secondPointSecondSegment)
        {
            if (secondPointFirstSegment.X < firstPointFirstSegment.X)
            {
                Point tmp = firstPointFirstSegment;
                firstPointFirstSegment = secondPointFirstSegment;
                secondPointFirstSegment = tmp;
            }
            if (secondPointSecondSegment.X < firstPointSecondSegment.X)
            {
                Point tmp = firstPointSecondSegment;
                firstPointSecondSegment = secondPointSecondSegment;
                secondPointSecondSegment = tmp;
            }
            if (secondPointFirstSegment.X < firstPointSecondSegment.X)
            {
                return false;
            }
            if ((firstPointFirstSegment.X - secondPointFirstSegment.X == 0) && (firstPointSecondSegment.X - secondPointSecondSegment.X == 0))
            {
                if (firstPointFirstSegment.X == firstPointSecondSegment.X)
                {
                    if (!((Math.Max(firstPointFirstSegment.Y, secondPointFirstSegment.Y) < Math.Min(firstPointSecondSegment.Y, secondPointSecondSegment.Y)) || (Math.Min(firstPointFirstSegment.Y, secondPointFirstSegment.Y) > Math.Max(firstPointSecondSegment.Y, secondPointSecondSegment.Y))))
                    {
                        return true;
                    }
                }
                return false;
            }
            if (firstPointFirstSegment.X - secondPointFirstSegment.X == 0)
            {
                double firstPointFirstSegmentX = firstPointFirstSegment.X;
                double firstAFirstVertical = ((double)(firstPointSecondSegment.Y - secondPointSecondSegment.Y)) / (firstPointSecondSegment.X - secondPointSecondSegment.X);
                double secondBFirstVertical = firstPointSecondSegment.Y - (firstAFirstVertical * firstPointSecondSegment.X);
                double Ya = (firstAFirstVertical * firstPointFirstSegmentX) + secondBFirstVertical;
                if (firstPointSecondSegment.X <= firstPointFirstSegmentX && secondPointSecondSegment.X >= firstPointFirstSegmentX && Math.Min(firstPointFirstSegment.Y, secondPointFirstSegment.Y) <= Ya && Math.Max(firstPointFirstSegment.Y, secondPointFirstSegment.Y) >= Ya)
                {
                    return true;
                }
                return false;
            }
            if (firstPointSecondSegment.X - secondPointSecondSegment.X == 0)
            {
                double firstPointSecondSegmentX = firstPointSecondSegment.X;
                double firstASecondVertical = ((double)(firstPointFirstSegment.Y - secondPointFirstSegment.Y)) / (firstPointFirstSegment.X - secondPointFirstSegment.X);
                double firstBSecondVertical = firstPointFirstSegment.Y - (firstASecondVertical * firstPointFirstSegment.X);
                double Ya = (firstASecondVertical * firstPointSecondSegmentX) + firstBSecondVertical;
                if (firstPointFirstSegment.X <= firstPointSecondSegmentX && secondPointFirstSegment.X >= firstPointSecondSegmentX
                    && Math.Min(firstPointSecondSegment.Y, secondPointSecondSegment.Y) <= Ya && Math.Max(firstPointSecondSegment.Y,
                    secondPointSecondSegment.Y) >= Ya)
                {
                    return true;
                }
                return false;
            }
            double firstA = Math.Round(((double)(firstPointFirstSegment.Y - secondPointFirstSegment.Y)) / (firstPointFirstSegment.X - secondPointFirstSegment.X), 2);
            double secondA = Math.Round(((double)(firstPointSecondSegment.Y - secondPointSecondSegment.Y)) / (firstPointSecondSegment.X - secondPointSecondSegment.X), 2);
            double firstB = firstPointFirstSegment.Y - (firstA * firstPointFirstSegment.X);
            double secondB = firstPointSecondSegment.Y - (secondA * firstPointSecondSegment.X);
            if (firstA == secondA)
            {
                return false;
            }
            double Xa = ((double)(secondB - firstB)) / (firstA - secondA);
            if ((Xa < Math.Max(firstPointFirstSegment.X, firstPointSecondSegment.X)) || (Xa > Math.Min(secondPointFirstSegment.X, secondPointSecondSegment.X)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Compares two values
        /// </summary>
        /// <param name="obj">Compared value</param>
        /// <returns>Returns true, if values are the same and false if values are different</returns>
        public override bool Equals(object obj)
        {
            return obj is Hexagon hexagon &&
                   Id == hexagon.Id &&
                   Segments.SequenceEqual(hexagon.Segments);
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
            stringBuilder.AppendLine($"Name: {nameof(Hexagon)}");
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
        /// <exception cref="ArgumentException">Object is not a Hexagon</exception>
        public new int CompareTo(object obj)
        {
            if (!(obj is Hexagon))
                throw new ArgumentException("Object is not a Hexagon");
            Hexagon hexagon = (Hexagon)obj;
            var firstHexagon = this.GetArea();
            var secondHexagon = hexagon.GetArea();
            if (firstHexagon > secondHexagon)
                return 1;
            else if (secondHexagon > firstHexagon)
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
            var newPolygon = (Hexagon)this.MemberwiseClone();
            newPolygon.Segments = (Segment[])this.Segments.Clone();
            return newPolygon;
        }

        /// <summary>
        /// Converts an array of segments to a Hexagon object
        /// </summary>
        /// <param name="segments">Array of segments</param>
        public static implicit operator Hexagon(Segment[] segments)
        {
            return new Hexagon(segments, 4);
        }

        /// <summary>
        /// Converts a Hexagon object to an array of segments
        /// </summary>
        /// <param name="hexagon">Hexagon</param>
        public static explicit operator Segment[](Hexagon hexagon)
        {
            return hexagon.Segments;
        }
    }
}

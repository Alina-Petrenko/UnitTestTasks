using System;
using System.Linq;
using System.Text;

namespace SecondTask
{
    /// <summary>
    /// Class represents polygon
    /// </summary>
    public class Polygon : GeometricFigure, ICloneable, IComparable
    {
        public Polygon(Segment[] segments, int Id)
        {
            this.Segments = new Segment[segments.Length];
            for (var i = 0; i < segments.Length; i++)
            {
                this.Segments[i] = segments[i];
            }
            this.Id = Id;
        }

        /// <summary>
        /// Clones an object
        /// </summary>
        /// <returns>Returns the cloned object</returns>
        public object Clone()
        {
            var newPolygon = (Polygon)this.MemberwiseClone();
            var segments = new Segment[this.Segments.Length];
            for (int i = 0; i < this.Segments.Length; i++)
            {
                segments[i].FirstPoint = this.Segments[i].FirstPoint;
            }
            newPolygon.Segments = segments;
            return newPolygon;
        }

        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="obj">Object for comparison</param>
        /// <returns>Returns result of comparison</returns>
        /// <exception cref="ArgumentException">Object is not a Polygon</exception>
        public int CompareTo(object obj)
        {
            if (!(obj is Polygon))
                throw new ArgumentException("Object is not a Polygon");
            Polygon polygon = (Polygon)obj;
            var firstPolygon = GetArea();
            var secondPolygon = polygon.GetArea();
            if (firstPolygon > secondPolygon)
                return 1;
            else if (secondPolygon > firstPolygon)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Compares two values
        /// </summary>
        /// <param name="obj">Compared value</param>
        /// <returns>Returns true, if values are the same and false if values are different</returns>
        public override bool Equals(object obj)
        {
            return obj is Polygon polygon &&
            Id == polygon.Id &&
            Segments.SequenceEqual(polygon.Segments);
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
        /// Calculates the area of polygon
        /// </summary>
        /// <returns>Returns the area</returns>
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
        /// Calculates the perimeter of polygon
        /// </summary>
        /// <returns>Returns the perimeter</returns>
        public new double GetPerimeter()
        {
            var perimeter = 0d;
            for (int i = 0; i < Segments.Length; i++)
            {
                perimeter += Segments[i].GetLength();
            }
            return Math.Round(perimeter, 2);
        }

        /// <summary>
        /// Overloads + operator
        /// </summary>
        /// <param name="firstPolygon">First value</param>
        /// <param name="secondPolygon">Second Value</param>
        /// <returns>Returns result of sum</returns>
        /// <exception cref="InvalidOperationException">Different count of sides.</exception>
        public static Polygon operator +(Polygon firstPolygon, Polygon secondPolygon)
        {
            Polygon polygon = new Polygon(firstPolygon.Segments,firstPolygon.Id+secondPolygon.Id);
            polygon.Segments = new Segment[firstPolygon.Segments.Length];
            if (firstPolygon.Segments.Length != secondPolygon.Segments.Length)
            {
                throw new InvalidOperationException("Different count of sides.");
            }
            else
            {
                for (int i = 0; i < firstPolygon.Segments.Length; i++)
                {
                    polygon.Segments[i].FirstPoint = new Point((firstPolygon.Segments[i].FirstPoint.X + secondPolygon.Segments[i].FirstPoint.X), (firstPolygon.Segments[i].FirstPoint.Y + secondPolygon.Segments[i].FirstPoint.Y));
                    polygon.Segments[i].SecondPoint = new Point((firstPolygon.Segments[i].SecondPoint.X + secondPolygon.Segments[i].SecondPoint.X), (firstPolygon.Segments[i].SecondPoint.Y + secondPolygon.Segments[i].SecondPoint.Y)); ;
                }
                return polygon;
            }
        }

        /// <summary>
        /// Overloads - operator
        /// </summary>
        /// <param name="firstPolygon">First value</param>
        /// <param name="secondPolygon">Second Value</param>
        /// <returns>Returns result of subtraction</returns>
        /// <exception cref="InvalidOperationException">Different count of sides.</exception>
        public static Polygon operator -(Polygon firstPolygon, Polygon secondPolygon)
        {
            Polygon polygon = new Polygon(firstPolygon.Segments, firstPolygon.Id + secondPolygon.Id);
            polygon.Segments = new Segment[firstPolygon.Segments.Length];
            if (firstPolygon.Segments.Length != secondPolygon.Segments.Length)
            {
                throw new InvalidOperationException("Different count of sides.");
            }
            else
            {
                for (int i = 0; i < firstPolygon.Segments.Length; i++)
                {
                    polygon.Segments[i].FirstPoint = firstPolygon.Segments[i].FirstPoint - secondPolygon.Segments[i].FirstPoint;
                    polygon.Segments[i].FirstPoint = firstPolygon.Segments[i].FirstPoint - secondPolygon.Segments[i].FirstPoint;
                }
                return polygon;
            }
        }

        /// <summary>
        /// Overloads == operator
        /// </summary>
        /// <param name="firstPolygon">First value</param>
        /// <param name="secondPolygon">Second Value</param>
        /// <returns>Returns equality comparison result</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool operator ==(Polygon firstPolygon, Polygon secondPolygon)
        {
            Polygon polygon = new Polygon(firstPolygon.Segments, firstPolygon.Id + secondPolygon.Id);
            polygon.Segments = new Segment[firstPolygon.Segments.Length];
            if (firstPolygon.Segments.Length != secondPolygon.Segments.Length)
            {
                throw new InvalidOperationException("Different count of sides.");
            }
            else
            {
                for (int i = 0; i < firstPolygon.Segments.Length; i++)
                {
                    if ((firstPolygon.Segments[i].FirstPoint == secondPolygon.Segments[i].FirstPoint) && (firstPolygon.Segments[i].SecondPoint == secondPolygon.Segments[i].SecondPoint))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Overloads != operator
        /// </summary>
        /// <param name="firstPolygon">First value</param>
        /// <param name="secondPolygon">Second Value</param>
        /// <returns>Returns inequality comparison result</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool operator !=(Polygon firstPolygon, Polygon secondPolygon)
        {
            Polygon polygon = new Polygon(firstPolygon.Segments, firstPolygon.Id + secondPolygon.Id);
            polygon.Segments = new Segment[firstPolygon.Segments.Length];
            if (firstPolygon.Segments.Length != secondPolygon.Segments.Length)
            {
                throw new InvalidOperationException("Different count of sides.");
            }
            else
            {
                var counter = 0;
                for (int i = 0; i < firstPolygon.Segments.Length; i++)
                {
                    if ((firstPolygon.Segments[i].FirstPoint != secondPolygon.Segments[i].FirstPoint) && (firstPolygon.Segments[i].SecondPoint != secondPolygon.Segments[i].SecondPoint))
                    {
                        counter++;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (counter != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }    
            }
        }

        /// <summary>
        /// Converts an array of segments to a Polygon object
        /// </summary>
        /// <param name="segments">Array of segments</param>
        public static implicit operator Polygon(Segment[] segments)
        {
            return new Polygon(segments, 4);
        }

        /// <summary>
        /// Converts a Polygon object to an array of segments
        /// </summary>
        /// <param name="polygon">Polygon</param>
        public static explicit operator Segment[](Polygon polygon)
        {
            return polygon.Segments;
        }

        /// <summary>
        /// Converts the value as a string
        /// </summary>
        /// <returns>Returns converted value</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {nameof(Polygon)}");
            for (int i = 0; i < this.Segments.Length; i++)
            {
                stringBuilder.AppendLine($"Point #{i + 1}: X = {this.Segments[i].FirstPoint.X}, Y = {this.Segments[i].FirstPoint.Y}.");
            }
            return stringBuilder.ToString();
        }
    }

}

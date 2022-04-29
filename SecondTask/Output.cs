using System;
using System.Text;

namespace SecondTask
{
    /// <summary>
    /// Provides methods for displaying results
    /// </summary>
    public class Output
    {
        /// <summary>
        /// Writes to the console the results of working with the Polygon class 
        /// </summary>
        public static void PolygonOutput()
        {
            Console.WriteLine("Polygon\n_____________________________________________");
            var polygonFirstSegments = Hexagon.GetRandomCoordinatesForHexagon();
            var polygonSecondSegments = Hexagon.GetRandomCoordinatesForHexagon();
            Console.WriteLine("First");
            Polygon firstPolygon = new Polygon(polygonFirstSegments, 1);
            Console.WriteLine(firstPolygon.ToString());
            Console.WriteLine("Second");
            Polygon secondPolygon = new Polygon(polygonSecondSegments, 2);
            Console.WriteLine(secondPolygon.ToString());

            Console.WriteLine("Cloning firstPolygon");
            Polygon newPoly = (Polygon)firstPolygon.Clone();
            Console.WriteLine(newPoly.ToString());

            Console.WriteLine("Comparing firstPolygon with secondPolygon");
            if (firstPolygon.CompareTo(secondPolygon) > 0)
            {
                Console.WriteLine("firstPolygon bigger than secondPolygon");
            }
            else if (firstPolygon.CompareTo(secondPolygon) < 0)
            {
                Console.WriteLine("secondPolygon bigger than firstPolygon");
            }
            else
            {
                Console.WriteLine("Polygones are the same");
            }

            Console.WriteLine("Math operation");

            newPoly = firstPolygon + secondPolygon;
            Console.WriteLine($"Sum\n {newPoly}");

            newPoly = firstPolygon - secondPolygon;
            Console.WriteLine($"Subtraction\n {newPoly}");

            var comparison = firstPolygon == secondPolygon;
            Console.WriteLine($"Equality {comparison}");

            comparison = firstPolygon != secondPolygon;
            Console.WriteLine($"Inequality {comparison}");

            var segmentsImplicit = (Segment[])firstPolygon;
            Polygon polygonExplicit = segmentsImplicit;
            var resultExplicit = polygonExplicit.ToString();
            Console.WriteLine($"Polygon explicit: {resultExplicit}");
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < segmentsImplicit.Length; i++)
            {
                stringBuilder.AppendLine($"Point #{i + 1}: X = {segmentsImplicit[i].FirstPoint.X}, Y = {segmentsImplicit[i].FirstPoint.Y}.");
            }
            Console.WriteLine($"Polygon implicit: \n{stringBuilder}");
            Console.WriteLine("_____________________________________________");
        }

        /// <summary>
        /// Writes to the console the results of working with the Triangle class
        /// </summary>
        public static void TriangleOutput()
        {
            Console.WriteLine("Triangle\n_____________________________________________");
            var triangleFirstSegments = Triangle.GetRandomCoordinatesForTriangle();
            var triangleSecondSegments = Triangle.GetRandomCoordinatesForTriangle();
            Console.WriteLine("First");
            Triangle firstTriangle = new Triangle(triangleFirstSegments, 1);
            Console.WriteLine(firstTriangle.ToString());
            Console.WriteLine("Second");
            Triangle secondTriangle = new Triangle(triangleSecondSegments, 2);
            Console.WriteLine(secondTriangle.ToString());

            Console.WriteLine("Cloning firstHexagon");
            Polygon newPoly = (Polygon)firstTriangle.Clone();
            Console.WriteLine(((Triangle)newPoly).ToString());

            Console.WriteLine("Comparing firstTriangle with secondTriangle");
            if (firstTriangle.CompareTo(secondTriangle) > 0)
            {
                Console.WriteLine("firstTriangle bigger than secondTriangle");
            }
            else if (firstTriangle.CompareTo(secondTriangle) < 0)
            {
                Console.WriteLine("secondTriangle bigger than firstTriangle");
            }
            else
            {
                Console.WriteLine("Triangles are the same");
            }

            Console.WriteLine("Math operation");

            newPoly = firstTriangle + secondTriangle;
            Segment[] segmentsImplicit = (Segment[])newPoly;
            Triangle trianleExplicit = segmentsImplicit;
            Console.WriteLine($"Sum\n {trianleExplicit}");

            newPoly = firstTriangle - secondTriangle;
            segmentsImplicit = (Segment[])newPoly;
            trianleExplicit = segmentsImplicit;
            Console.WriteLine($"Subtraction\n {trianleExplicit}");

            var comparison = firstTriangle == secondTriangle;
            Console.WriteLine($"Equality {comparison}");

            comparison = firstTriangle != secondTriangle;
            Console.WriteLine($"Inequality {comparison}");
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < segmentsImplicit.Length; i++)
            {
                stringBuilder.AppendLine($"Point #{i + 1}: X = {segmentsImplicit[i].FirstPoint.X}, Y = {segmentsImplicit[i].FirstPoint.Y}.");
            }
            Console.WriteLine($"Polygon implicit: \n{stringBuilder}");
            Console.WriteLine("_____________________________________________");
        }

        /// <summary>
        /// Writes to the console the results of working with the Hexagon class
        /// </summary>
        public static void HexagonOutput()
        {
            Console.WriteLine("Hexagon\n_____________________________________________");
            var hexagonFirstSegments = Hexagon.GetRandomCoordinatesForHexagon();
            var hexagonSecondSegments = Hexagon.GetRandomCoordinatesForHexagon();
            Console.WriteLine("First");
            Hexagon firstHexagon = new Hexagon(hexagonFirstSegments, 1);
            Console.WriteLine(firstHexagon.ToString());
            Console.WriteLine("Second");
            Hexagon secondHexagon = new Hexagon(hexagonSecondSegments, 2);
            Console.WriteLine(secondHexagon.ToString());

            Console.WriteLine("Cloning firstHexagon");
            Polygon newPoly = (Polygon)firstHexagon.Clone();
            Console.WriteLine(((Hexagon)newPoly).ToString());

            Console.WriteLine("Comparing firstHexagon with secondHexagon");
            if (firstHexagon.CompareTo(secondHexagon) > 0)
            {
                Console.WriteLine("firstHexagon bigger than secondHexagon");
            }
            else if (firstHexagon.CompareTo(secondHexagon) < 0)
            {
                Console.WriteLine("secondHexagon bigger than firstHexagon");
            }
            else
            {
                Console.WriteLine("Hexagones are the same");
            }

            Console.WriteLine("Math operation");

            newPoly = firstHexagon + secondHexagon;
            Segment[] segmentsImplicit = (Segment[])newPoly;
            Hexagon hexagonExplicit = segmentsImplicit;
            Console.WriteLine($"Sum\n {hexagonExplicit}");

            newPoly = firstHexagon - secondHexagon;
            segmentsImplicit = (Segment[])newPoly;
            hexagonExplicit = segmentsImplicit;
            Console.WriteLine($"Subtraction\n {hexagonExplicit}");

            var comparison = firstHexagon == secondHexagon;
            Console.WriteLine($"Equality {comparison}");

            comparison = firstHexagon != secondHexagon;
            Console.WriteLine($"Inequality {comparison}");

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < segmentsImplicit.Length; i++)
            {
                stringBuilder.AppendLine($"Point #{i + 1}: X = {segmentsImplicit[i].FirstPoint.X}, Y = {segmentsImplicit[i].FirstPoint.Y}.");
            }
            Console.WriteLine($"Polygon implicit: \n{stringBuilder}");
            Console.WriteLine("_____________________________________________");
        }
    }
}

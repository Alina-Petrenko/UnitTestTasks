using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SecondTask.UnitTests
{
    [TestFixture]
    public class HexagonTests
    {
        #region Fields

        private static readonly object[] TestCasesSegments =
        {
            new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10)),
                new Segment(new Point ( 0,10 ), new Point(-9,-3)),
                new Segment(new Point ( -9,-3 ), new Point(-2,-1)),
                new Segment(new Point ( -2,-1 ), new Point(-4,-4))
            },

            new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4)),
                new Segment(new Point ( 9,4 ), new Point(-14,2)),
                new Segment(new Point ( -14,2 ), new Point(8,-7)),
                new Segment(new Point ( 8,-7 ), new Point(4,-14))
            }
        };

        private static readonly object[] TestCasesEquals =
        {
            (new Hexagon(new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10)),
                new Segment(new Point ( 0,10 ), new Point(-9,-3)),
                new Segment(new Point ( -9,-3 ), new Point(-2,-1)),
                new Segment(new Point ( -2,-1 ), new Point(-4,-4))
            },1),

            new Hexagon(new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10)),
                new Segment(new Point ( 0,10 ), new Point(-9,-3)),
                new Segment(new Point ( -9,-3 ), new Point(-2,-1)),
                new Segment(new Point ( -2,-1 ), new Point(-4,-4))
            },1)),
        };

        private static readonly object[] TestCasesNotEquals =
        {
            (new Hexagon(new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10)),
                new Segment(new Point ( 0,10 ), new Point(-9,-3)),
                new Segment(new Point ( -9,-3 ), new Point(-2,-1)),
                new Segment(new Point ( -2,-1 ), new Point(-4,-4))
            },1),

            new Hexagon(new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4)),
                new Segment(new Point ( 9,4 ), new Point(-14,2)),
                new Segment(new Point ( -14,2 ), new Point(8,-7)),
                new Segment(new Point ( 8,-7 ), new Point(4,-14))
            },2))
        };

        private static readonly object[] TestCasesImplicit =
        {
            new Hexagon(new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10)), 
                new Segment(new Point ( 0,10 ), new Point(-9,-3)),
                new Segment(new Point ( -9,-3 ), new Point(-2,-1)),
                new Segment(new Point ( -2,-1 ), new Point(-4,-4))
            },1),

            new Hexagon(new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4)),
                new Segment(new Point ( 9,4 ), new Point(-14,2)),
                new Segment(new Point ( -14,2 ), new Point(8,-7)),
                new Segment(new Point ( 8,-7 ), new Point(4,-14))
            },2)};

        private static readonly object[] TestCasesCompare =
        {
            (
                new Hexagon(new Segment[] 
                {
                    new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                    new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                    new Segment(new Point ( 10,-15 ), new Point(9,4)),
                    new Segment(new Point ( 9,4 ), new Point(-14,2)),
                    new Segment(new Point ( -14,2 ), new Point(8,-7)),
                    new Segment(new Point ( 8,-7 ), new Point(4,-14))
                },2),

                new Hexagon(new Segment[] {
                    new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                    new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                    new Segment(new Point ( 4,-8 ), new Point(0,10)),
                    new Segment(new Point ( 0,10 ), new Point(-9,-3)),
                    new Segment(new Point ( -9,-3 ), new Point(-2,-1)),
                    new Segment(new Point ( -2,-1 ), new Point(-4,-4))
                },1)
                )
        };

        private static readonly object[] TestCasesGetArea =
        {
            (new Hexagon(new Segment[]
            {
                new Segment(new Point(-4, -4), new Point(3, -6)),
                new Segment(new Point(3, -6), new Point(4, -8)),
                new Segment(new Point(4, -8), new Point(0, 10)),
                new Segment(new Point(0, 10), new Point(-9, -3)),
                new Segment(new Point(-9, -3), new Point(-2, -1)),
                new Segment(new Point(-2, -1), new Point(-4, -4))
            }, 1), 86.5),

            (new Hexagon(new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4)),
                new Segment(new Point ( 9,4 ), new Point(-14,2)),
                new Segment(new Point ( -14,2 ), new Point(8,-7)),
                new Segment(new Point ( 8,-7 ), new Point(4,-14))
            },2), 157.0)
        };

        private static readonly object[] TestCasesGetPerimeter =
        {
            (new Hexagon(new Segment[]
            {
                new Segment(new Point(-4, -4), new Point(3, -6)),
                new Segment(new Point(3, -6), new Point(4, -8)),
                new Segment(new Point(4, -8), new Point(0, 10)),
                new Segment(new Point(0, 10), new Point(-9, -3)),
                new Segment(new Point(-9, -3), new Point(-2, -1)),
                new Segment(new Point(-2, -1), new Point(-4, -4))
            }, 1), 54.65),

            (new Hexagon(new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4)),
                new Segment(new Point ( 9,4 ), new Point(-14,2)),
                new Segment(new Point ( -14,2 ), new Point(8,-7)),
                new Segment(new Point ( 8,-7 ), new Point(4,-14))
            },2), 103.37)
        };

        #endregion

        #region Tests

        // TODO: before
        [Test, TestCaseSource("TestCasesSegments")]
        public void Hexagon_SetToFieldsValue_ValueHasBeenSet(Segment[] segments)
        {
            var id = 1;

            var hexagon = new Hexagon(segments, id);

            Assert.AreEqual(segments, hexagon.Segments);
            Assert.AreEqual(id, hexagon.Id);
        }
        
        // TODO: After
        // TODO: 1. Name of method should be as in template:
        // TODO: {NameOfMethod}_{InputData}_{ExpectedOutput}
        // TODO: 2. Always clarify Act, Arrange, Assert sections
        // TODO: 3. Add summary to tests too (if nothing to explain then just copy the name of method
        // TODO: 4. Use const whenever where it could be used inside method.
        /// <summary>
        /// Constructor_ValidData_ExpectedObjectCreated
        /// </summary>
        /// <param name="segments">Lines to create a geometric object</param>
        [Test, TestCaseSource("TestCasesSegments")]
        public void Constructor_ValidData_ExpectedObjectCreated(Segment[] segments)
        {
            // Act
            const int id = 1;

            // Arrange
            var hexagon = new Hexagon(segments, id);

            // Assert
            Assert.AreEqual(segments, hexagon.Segments);
            Assert.AreEqual(id, hexagon.Id);
        }
        
        [Test]
        public void GetRandomCoordinatesForHexagon_GetRandomCoordinates_ReturnsCoordinatesWithoutLineCross()
        {
            var firstSegments = Hexagon.GetRandomCoordinatesForHexagon();
            var secondSegments = Hexagon.GetRandomCoordinatesForHexagon();

            Assert.AreNotEqual(firstSegments, secondSegments);
        }

        // TODO: Rename into GetArea_ValidHexagon_ExpectedCalculatedArea
        [Test, TestCaseSource("TestCasesGetArea")]
        public void GetArea_GetHexagonArea_ReturnsHexagonArea((Hexagon firstHexagon, double expectedArea) tuple)
        {
            var result = tuple.firstHexagon.GetArea();

            Assert.AreEqual(tuple.expectedArea, result);
        }

        [Test, TestCaseSource("TestCasesGetPerimeter")]
        public void GetPerimeter_GetHexagonPerimeter_ReturnsHexagonPerimeter((Hexagon firstHexagon, double expectedPerimeter) tuple)
        {
            var result = tuple.firstHexagon.GetPerimeter();

            Assert.AreEqual(tuple.expectedPerimeter, result);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void Equals_EqualObjects_ReturnsTrue((Hexagon firstHexagon, Hexagon secondHexagon) tuple)
        {
            var result = tuple.firstHexagon.Equals(tuple.secondHexagon);

            Assert.True(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void Equals_NotEqualObjects_ReturnsFalse((Hexagon firstHexagon, Hexagon secondHexagon) tuple)
        {
            var result = tuple.firstHexagon.Equals(tuple.secondHexagon);

            Assert.False(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void GetHashCode_CreateTwoDifferentObject_AreNotEqual((Hexagon firstHexagon, Hexagon secondHexagon) tuple)
        {
            var hashCodeFirstHexagon = tuple.firstHexagon.GetHashCode();
            var hashCodeSecondHexagon = tuple.secondHexagon.GetHashCode();

            Assert.AreNotEqual(hashCodeFirstHexagon, hashCodeSecondHexagon);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void Clone_NotEqualObjects_ReturnsNewObject((Hexagon firstHexagon, Hexagon secondHexagon) tuple)
        {
            var expected = tuple.secondHexagon;

            Hexagon result = (Hexagon)(tuple.firstHexagon).Clone();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void CompareTo_EqualObjects_ReturnsTrue((Hexagon firstHexagon, Hexagon secondHexagon) tuple)
        {
            var value = 0;

            var result = tuple.firstHexagon.CompareTo(tuple.secondHexagon);

            Assert.AreEqual(value, result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void CompareTo_FirstHexagonLess_ReturnsTrue((Hexagon firstHexagon, Hexagon secondHexagon) tuple)
        {
            var value = -1;

            var result = tuple.firstHexagon.CompareTo(tuple.secondHexagon);

            Assert.AreEqual(value, result);
        }

        [Test, TestCaseSource("TestCasesCompare")]
        public void CompareTo_FirstHexagonBigger_ReturnsTrue((Hexagon firstHexagon, Hexagon secondHexagon) tuple)
        {
            var value = 1;

            var result = tuple.firstHexagon.CompareTo(tuple.secondHexagon);

            Assert.AreEqual(value, result);
        }

        [Test, TestCaseSource("TestCasesImplicit")]
        public void Implicit_ConvertSegmentsToHexagon_ReturnsHexagon(Hexagon hexagon)
        {
            Segment[] segments = (Segment[])hexagon;

            Assert.IsInstanceOf<Segment[]>(segments);
        }

        [Test, TestCaseSource("TestCasesSegments")]
        public void Explicit_ConvertHexagonToSegments_ReturnsSegments(Segment[] segments)
        {
            Hexagon hexagon = segments;

            Assert.IsInstanceOf<Hexagon>(hexagon);
            Assert.AreEqual(4, hexagon.Id);
        }

        #endregion
    }
}

using NUnit.Framework;

namespace SecondTask.UnitTests
{
    [TestFixture]
    public class PolygonTests
    {
        #region Fields

        private static readonly object[] TestCasesPoints =
        {
            (new Point[]
                {
                    new Point ( -4,2 ), new Point(3,12),new Point ( 9,3 )
                },
                new Segment[]
                {
                    new Segment (new Point( -4,2 ), new Point(3,12)),
                    new Segment(new Point(3,12), new Point(9,3)),
                    new Segment(new Point(9,3), new Point( -4,2 ))

                }),

            (new Point[]
                {
                    new Point ( 7 ), new Point(1,-8)
                },
                new Segment[]
                {
                    new Segment (new Point( 7 ), new Point(1,-8)),
                    new Segment(new Point(1,-8), new Point(7)),


                }),
            (new Point[]
                {
                    new Point (), new Point(3,7), new Point(-10, -2) , new Point(4, 8)
                },
                new Segment[]
                {
                    new Segment (new Point(), new Point(3,7)),
                    new Segment(new Point(3,7), new Point(-10,-2)),
                    new Segment(new Point(-10,-2), new Point(4,8)),
                    new Segment(new Point(4,8), new Point())
                })
        };

        private static readonly object[] TestCasesSegments =
        {
            new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 3,8 ), new Point(6,1)), new Segment(new Point ( 9,-1 ), new Point(-8,6))},
            new Segment[] {new Segment(new Point ( 7,7), new Point(9,9)), new Segment(new Point ( 4,2), new Point(0,5)), new Segment(new Point(6, -4), new Point(-5, 3)) }
        };

        private static readonly object[] TestCasesEquals =
        {
            (
                new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1),
                new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1)
            ),
            (
                new Polygon(new Segment[] {new Segment(new Point ( 7,7), new Point(9,9)), new Segment(new Point ( 3,-1), new Point(-10,-3))},2),
                new Polygon(new Segment[] {new Segment(new Point ( 7,7 ), new Point(9,9)), new Segment(new Point ( 3,-1 ), new Point(-10,-3))},2)
            )
        };

        private static readonly object[] TestCasesNotEquals =
        {
            (
                new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1),
                new Polygon(new Segment[] {new Segment(new Point ( 9,-4 ), new Point(7,-9)), new Segment(new Point ( 5,6 ), new Point())},2)
            ),
            (
                new Polygon(new Segment[] {new Segment(new Point ( 7,7), new Point(9,9)), new Segment(new Point ( 3,-1), new Point(-10,-3))},1),
                new Polygon(new Segment[] {new Segment(new Point ( 0,7 ), new Point(10,3)), new Segment(new Point ( -6,-3), new Point(-1,-2))},2)
            )
        };

        private static readonly object[] TestCasesCompare =
        {
            (
                new Polygon(new Segment[] {new Segment(new Point ( 9,-4 ), new Point(7,-9)), new Segment(new Point ( 5,6 ), new Point())},2),
                new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1)
            ),
            (
                new Polygon(new Segment[] {new Segment(new Point ( 0,7 ), new Point(10,3)), new Segment(new Point ( -6,-3), new Point(-1,-2))},2),
                new Polygon(new Segment[] {new Segment(new Point ( 7,7), new Point(9,9)), new Segment(new Point ( 3,-1), new Point(-10,-3))},1)
            )
        };

        private static readonly object[] TestCasesSum =
        {
            (
                new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1),
                new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1),
                new Polygon(new Segment[] {new Segment(new Point ( -2,-8 ), new Point()), new Segment(new Point ( 4,12 ), new Point(16,4))},2)
                ),
            (
                new Polygon(new Segment[] {new Segment(new Point ( 7,7), new Point(9,9)), new Segment(new Point ( 3,-1), new Point(-10,-3))},2),
                new Polygon(new Segment[] {new Segment(new Point ( 9,-3 ), new Point(2,-13)), new Segment(new Point ( 4,4 ), new Point(-1,8))},1),
                new Polygon(new Segment[] {new Segment(new Point ( 16,4 ), new Point(11,-4)), new Segment(new Point ( 7,3 ), new Point(-11,5))},3)
                )
        };

        private static readonly object[] TestCasesSubtraction =
        {
            (
                new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1),
                new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1),
                new Polygon(new Segment[] {new Segment(new Point ( 0,0 ), new Point()), new Segment(new Point ( 0,0 ), new Point(0,0))},2)
            ),
            (
                new Polygon(new Segment[] {new Segment(new Point ( 7,7), new Point(9,9)), new Segment(new Point ( 3,-1), new Point(-10,-3))},2),
                new Polygon(new Segment[] {new Segment(new Point ( 9,-3 ), new Point(2,-13)), new Segment(new Point ( 4,4 ), new Point(-1,8))},1),
                new Polygon(new Segment[] {new Segment(new Point ( -2,10), new Point(7,22)), new Segment(new Point ( -1,-5), new Point(-9,-11))},3)
            )
        };

        private static readonly object[] TestCasesExplicit =
        {
            new Polygon(new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( 2,6 ), new Point(8,2))},1),
            new Polygon(new Segment[] {new Segment(new Point ( 0,0 ), new Point()), new Segment(new Point ( 0,0 ), new Point(0,0))},2)
        };

        #endregion

            #region Tests

        [Test, TestCaseSource("TestCasesSegments")]
        public void Polygon_SetToFieldsValue_ValueHasBeenSet(Segment[] segments)
        {
            var id = 1;

            var polygon = new Polygon(segments, id);

            Assert.AreEqual(segments, polygon.Segments);
            Assert.AreEqual(id, polygon.Id);
        }

        [Test, TestCaseSource("TestCasesPoints")]
        public void GetSegments_GetSegmentFromPoint_ReturnSegmentsArray((Point[] points, Segment[] segments) tuple)
        {
            var newSegments = GeometricFigure.GetSegments(tuple.points);

            Assert.AreEqual(tuple.segments, newSegments);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void Equals_EqualObjects_ReturnsTrue((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var result = tuple.firstPolygon.Equals(tuple.secondPolygon);

            Assert.True(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void Equals_NotEqualObjects_ReturnsFalse((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var result = tuple.firstPolygon.Equals(tuple.secondPolygon);

            Assert.False(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void GetHashCode_CreateTwoDifferentObject_AreNotEqual((Polygon firstPolygon, Polygon secondPolygon)tuple)
        {
            var hashCodeFirstPolygon = tuple.firstPolygon.GetHashCode();
            var hashCodeSecondPolygon = tuple.secondPolygon.GetHashCode();

            Assert.AreNotEqual(hashCodeFirstPolygon, hashCodeSecondPolygon);
        }

        [Test, TestCaseSource("TestCasesSum")]
        public void Sum_DifferentObjects_ReturnsSumOfPoints((Polygon firstPolygon, Polygon secondPolygon, Polygon expectedResultPolygon) tuple)
        {
            var expectedResult = tuple.expectedResultPolygon;
            var result = tuple.firstPolygon + tuple.secondPolygon;

            Assert.AreEqual(result, expectedResult);
        }

        [Test, TestCaseSource("TestCasesSubtraction")]
        public void Subtraction_DifferentObjects_ReturnsSubtractionOfPoints((Polygon firstPolygon, Polygon secondPolygon, Polygon expectedResultPolygon) tuple)
        {
            var expectedResult = tuple.expectedResultPolygon;
            var result = tuple.firstPolygon - tuple.secondPolygon;

            Assert.AreEqual(result, expectedResult);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void Equality_EqualObjects_ReturnsTrue((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var result = tuple.firstPolygon == tuple.secondPolygon;

            Assert.True(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void Equality_NotEqualObjects_ReturnsFalse((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var result = tuple.firstPolygon == tuple.secondPolygon;

            Assert.False(result);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void Inequality_EqualObjects_ReturnsFalse((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var result = tuple.firstPolygon != tuple.secondPolygon;

            Assert.False(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void Inequality_NotEqualObjects_ReturnsTrue((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var result = tuple.firstPolygon != tuple.secondPolygon;

            Assert.True(result);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void Clone_NotEqualObjects_ReturnsNewObject((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var expected = tuple.secondPolygon;

            Polygon result = (Polygon)(tuple.firstPolygon).Clone();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void CompareTo_EqualObjects_ReturnsTrue((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var value = 0;

            var result = tuple.firstPolygon.CompareTo(tuple.secondPolygon);

            Assert.AreEqual(value,result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void CompareTo_FirstPolygonLess_ReturnsTrue((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var value = -1;

            var result = tuple.firstPolygon.CompareTo(tuple.secondPolygon);

            Assert.AreEqual(value, result);
        }

        [Test, TestCaseSource("TestCasesCompare")]
        public void CompareTo_FirstPolygonBigger_ReturnsTrue((Polygon firstPolygon, Polygon secondPolygon) tuple)
        {
            var value = 1;

            var result = tuple.firstPolygon.CompareTo(tuple.secondPolygon);

            Assert.AreEqual(value, result);
        }

        [Test, TestCaseSource("TestCasesExplicit")]
        public void Implicit_ConvertSegmentsToPolygon_ReturnsPolygon(Polygon polygon)
        {
            Segment[] segments = (Segment[])polygon;

            Assert.IsInstanceOf<Segment[]>(segments);
        }

        [Test, TestCaseSource("TestCasesSegments")]
        public void Explicit_ConvertPolygonToSegments_ReturnsSegments(Segment[] segments)
        {
            Polygon polygon = segments;

            Assert.IsInstanceOf<Polygon>(polygon);
        }

        #endregion
    }
}

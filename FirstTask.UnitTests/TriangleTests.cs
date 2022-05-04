using NUnit.Framework;

namespace SecondTask.UnitTests
{
    [TestFixture]
    public class TriangleTests
    {
        #region Fields

        private static readonly object[] TestCasesSegments =
        {
            new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10))
            },

            new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4))
            }
        };

        private static readonly object[] TestCasesEquals =
        {
            (new Triangle(new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10))
            },1),

            new Triangle(new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10))
            },1)),
        };

        private static readonly object[] TestCasesNotEquals =
        {
            (new Triangle(new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10))
            },1),

            new Triangle(new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4))
            },2))
        };

        private static readonly object[] TestCasesImplicit =
        {
            new Triangle(new Segment[] {
                new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                new Segment(new Point ( 4,-8 ), new Point(0,10))
            },1),

            new Triangle(new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4))
            },2)};

        private static readonly object[] TestCasesCompare =
        {
            (
                new Triangle(new Segment[]
                {
                    new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                    new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                    new Segment(new Point ( 10,-15 ), new Point(9,4))
                },2),

                new Triangle(new Segment[] {
                    new Segment(new Point ( -4,-4 ), new Point(3,-6)),
                    new Segment(new Point ( 3,-6 ), new Point(4,-8)),
                    new Segment(new Point ( 4,-8 ), new Point(0,10))
                },1)
                )
        };

        private static readonly object[] TestCasesGetArea =
        {
            (new Triangle(new Segment[]
            {
                new Segment(new Point(-4, -4), new Point(3, -6)),
                new Segment(new Point(3, -6), new Point(4, -8)),
                new Segment(new Point(4, -8), new Point(0, 10))
            }, 1), 70.03),

            (new Triangle(new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4))
            },2), 101.29)
        };

        private static readonly object[] TestCasesGetPerimeter =
        {
            (new Triangle(new Segment[]
            {
                new Segment(new Point(-4, -4), new Point(3, -6)),
                new Segment(new Point(3, -6), new Point(4, -8)),
                new Segment(new Point(4, -8), new Point(0, 10))
            }, 1), 27.96),

            (new Triangle(new Segment[] {
                new Segment(new Point ( 4,-14 ), new Point(-7,-10)),
                new Segment(new Point ( -7,-10 ), new Point(10,-15)),
                new Segment(new Point ( 10,-15 ), new Point(9,4))
            },2), 48.45)
        };

        #endregion

        #region Tests

        [Test, TestCaseSource("TestCasesSegments")]
        public void Triangle_SetToFieldsValue_ValueHasBeenSet(Segment[] segments)
        {
            var id = 1;

            var triangle = new Triangle(segments, id);

            Assert.AreEqual(segments, triangle.Segments);
            Assert.AreEqual(id, triangle.Id);
        }

        [Test]
        public void GetRandomCoordinatesForTrangle_GetRandomCoordinates_ReturnsCoordinatesWithoutLineCross()
        {
            var firstSegments = Triangle.GetRandomCoordinatesForTriangle();
            var secondSegments = Triangle.GetRandomCoordinatesForTriangle();

            Assert.AreNotEqual(firstSegments, secondSegments);
        }

        [Test, TestCaseSource("TestCasesGetArea")]
        public void GetArea_GetTriangleArea_ReturnsTriangleArea((Triangle firstTriangle, double expectedArea) tuple)
        {
            var result = tuple.firstTriangle.GetArea();

            Assert.AreEqual(tuple.expectedArea, result);
        }

        [Test, TestCaseSource("TestCasesGetPerimeter")]
        public void GetPerimeter_GetTrianglePerimeter_ReturnsTrianglePerimeter((Triangle firstTriangle, double expectedPerimeter) tuple)
        {
            var result = tuple.firstTriangle.GetPerimeter();

            Assert.AreEqual(tuple.expectedPerimeter, result);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void Equals_EqualObjects_ReturnsTrue((Triangle firstTriangle, Triangle secondTriangle) tuple)
        {
            var result = tuple.firstTriangle.Equals(tuple.secondTriangle);

            Assert.True(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void Equals_NotEqualObjects_ReturnsFalse((Triangle firstTriangle, Triangle secondTriangle) tuple)
        {
            var result = tuple.firstTriangle.Equals(tuple.secondTriangle);

            Assert.False(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void GetHashCode_CreateTwoDifferentObject_AreNotEqual((Triangle firstTriangle, Triangle secondTriangle) tuple)
        {
            var hashCodeFirstTriangle = tuple.firstTriangle.GetHashCode();
            var hashCodeSecondTriangle = tuple.secondTriangle.GetHashCode();

            Assert.AreNotEqual(hashCodeFirstTriangle, hashCodeSecondTriangle);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void Clone_NotEqualObjects_ReturnsNewObject((Triangle firstTriangle, Triangle secondTriangle) tuple)
        {
            var expected = tuple.secondTriangle;

            Triangle result = (Triangle)(tuple.firstTriangle).Clone();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource("TestCasesEquals")]
        public void CompareTo_EqualObjects_ReturnsTrue((Triangle firstTriangle, Triangle secondTriangle) tuple)
        {
            var value = 0;

            var result = tuple.firstTriangle.CompareTo(tuple.secondTriangle);

            Assert.AreEqual(value, result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void CompareTo_FirstTriangleLess_ReturnsTrue((Triangle firstTriangle, Triangle secondTriangle) tuple)
        {
            var value = -1;

            var result = tuple.firstTriangle.CompareTo(tuple.secondTriangle);

            Assert.AreEqual(value, result);
        }

        [Test, TestCaseSource("TestCasesCompare")]
        public void CompareTo_FirstTriangleBigger_ReturnsTrue((Triangle firstTriangle, Triangle secondTriangle) tuple)
        {
            var value = 1;

            var result = tuple.firstTriangle.CompareTo(tuple.secondTriangle);

            Assert.AreEqual(value, result);
        }

        [Test, TestCaseSource("TestCasesImplicit")]
        public void Implicit_ConvertSegmentsToTriangle_ReturnsTriangle(Triangle triangle)
        {
            Segment[] segments = (Segment[])triangle;

            Assert.IsInstanceOf<Segment[]>(segments);
        }

        [Test, TestCaseSource("TestCasesSegments")]
        public void Explicit_ConvertTriangleToSegments_ReturnsSegments(Segment[] segments)
        {
            Triangle triangle = segments;

            Assert.IsInstanceOf<Triangle>(triangle);
        }

        #endregion
    }
}

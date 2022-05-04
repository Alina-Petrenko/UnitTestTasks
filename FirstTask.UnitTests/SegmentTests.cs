using System;
using NUnit.Framework;

namespace SecondTask.UnitTests
{
    [TestFixture]
    public class SegmentTests
    {
        #region Fields

        private static readonly object[] TestCases =
        {
            new Point[] {new Point ( -1,-4 ), new Point()},
            new Point[] {new Point ( 7 ), new Point(10,8)},
            new Point[] {new Point (), new Point(3,7)}
        };
        private static readonly object[] TestCasesSegments =
        {
            new Segment (new Point ( -1,-4 ), new Point()),
            new Segment (new Point ( 7 ), new Point(10,8)),
            new Segment (new Point (), new Point(3,7))
        };
        private static readonly object[] TestCasesEquals =
        {
            new Segment[] {new Segment(new Point ( -1,-4 ), new Point()), new Segment(new Point ( -1,-4 ), new Point())},
            new Segment[] {new Segment(new Point ( 7,7), new Point(9,9)), new Segment(new Point ( 7,7), new Point(9,9))},
        };
        private static readonly object[] TestCasesNotEquals =
        {
            new Segment[] {new Segment(new Point ( 0,-4 ), new Point()), new Segment(new Point ( -1,-4 ), new Point(9,-5))},
            new Segment[] {new Segment(new Point ( -10,8), new Point(9,4)), new Segment(new Point ( 0,7), new Point())},
        };

        #endregion

        #region Tests

        [Test, TestCaseSource("TestCases")]
        public void Segment_SetToFieldsValue_ValueHasBeenSet(Point firstPoint, Point secondPoint)
        {
            Segment segment;

            segment = new Segment(firstPoint, secondPoint);

            Assert.AreEqual(firstPoint, segment.FirstPoint);
            Assert.AreEqual(secondPoint, segment.SecondPoint);
        }

        [Test, TestCaseSource("TestCasesSegments")]
        public void GetLength_CalculatesLength_ReturnsLength(Segment segment)
        {
            var lenght = Math.Sqrt(Math.Pow(segment.SecondPoint.X - segment.FirstPoint.X, 2) + Math.Pow(segment.SecondPoint.Y - segment.FirstPoint.Y, 2));
            var result = segment.GetLength();

            Assert.AreEqual(lenght, result);
        }


        [Test, TestCaseSource("TestCasesEquals")]
        public void Equals_EqualObjects_ReturnsTrue(Segment firstSegment, Segment secondSegment)
        {
            var result = firstSegment.Equals(secondSegment);

            Assert.True(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void Equals_NotEqualObjects_ReturnsFalse(Segment firstSegment, Segment secondSegment)
        {
            var result = firstSegment.Equals(secondSegment);

            Assert.False(result);
        }

        [Test, TestCaseSource("TestCasesNotEquals")]
        public void GetHasCode_CreateTwoDifferentObject_AreNotEqual(Segment firstSegment, Segment secondSegment)
        {
            var hashCodeFirstSegment = firstSegment.GetHashCode();
            var hashCodeSecondSegment = secondSegment.GetHashCode();

            Assert.AreNotEqual(hashCodeFirstSegment, hashCodeSecondSegment);
        }

        #endregion
    }
}

using NUnit.Framework;

namespace SecondTask.UnitTests
{
    [TestFixture]
    public class PointTests
    {
        #region Tests

        [Test]
        [TestCase(-1, 1)]
        [TestCase(0, -4)]
        [TestCase(1, 20)]
        public void Point_SetToFieldsValue_ValueHasBeenSet(int x, int y)
        {
            Point point;

            point = new Point(x, y);

            Assert.AreEqual(x, point.X);
            Assert.AreEqual(y, point.Y);
        }

        [Test]
        public void Point_DoNotSetToFieldsValue_ValueHasBeenSetByDefault()
        {
            Point point;
            var defaultValue = 0;

            point = new Point();

            Assert.AreEqual(defaultValue, point.X);
            Assert.AreEqual(defaultValue, point.Y);
        }

        [Test]
        [TestCase(3, 7, 3, 7)]
        [TestCase(0, -10, 0, -10)]
        [TestCase(-4, -1, -4, -1)]
        public void Equals_EqualObjects_ReturnsTrue(int firstX, int firstY, int secondX, int secondY)
        {
            var firstPoint = new Point(firstX, firstY);
            var secondPoint = new Point(secondX, secondY);

            var result = firstPoint.Equals(secondPoint);

            Assert.True(result);
        }

        [Test]
        [TestCase(3, 7, 1, 2)]
        [TestCase(0, -10,7,10)]
        [TestCase(-4, -1,1,8)]
        public void Equals_NotEqualObjects_ReturnsFalse(int firstX, int firstY, int secondX, int secondY)
        {
            var firstPoint = new Point(firstX, firstY);
            var secondPoint = new Point(secondX, secondY);

            var result = firstPoint.Equals(secondPoint);

            Assert.False(result);
        }

        [Test]
        [TestCase(3, 7, 1, 2)]
        [TestCase(0, -10, 7, 10)]
        [TestCase(-4, -1, 1, 8)]
        public void Sum_NotEqualObjects_ReturnsSumOfPoints(int firstX, int firstY, int secondX, int secondY)
        {
            var firstPoint = new Point(firstX, firstY);
            var secondPoint = new Point(secondX, secondY);
            var point = new Point(firstX + secondX, firstY + secondY);

            var result = firstPoint + secondPoint;

            Assert.AreEqual(result, point);
        }

        [Test]
        [TestCase(13, -20, -4, 0)]
        [TestCase(7, 1, 10, 10)]
        [TestCase(0, 0, 0, 0)]
        public void Subtraction_NotEqualObjects_ReturnsSubtractionOfPoints(int firstX, int firstY, int secondX, int secondY)
        {
            var firstPoint = new Point(firstX, firstY);
            var secondPoint = new Point(secondX, secondY);
            var point = new Point(firstX - secondX, firstY - secondY);

            var result = firstPoint - secondPoint;

            Assert.AreEqual(result, point);
        }

        [Test]
        [TestCase(13, -20, 13, -20)]
        [TestCase(7, 1, 7, 1)]
        [TestCase(0, 0, 0, 0)]
        public void Equality_EqualObjects_ReturnsTrue(int firstX, int firstY, int secondX, int secondY)
        {
            var firstPoint = new Point(firstX, firstY);
            var secondPoint = new Point(secondX, secondY);

            var result = firstPoint == secondPoint;

            Assert.True(result);
        }

        [Test]
        [TestCase(14, -20, 3, -20)]
        [TestCase(7, 0, -3, 1)]
        [TestCase(0, 4, 0, 0)]
        public void Equality_NotEqualObjects_ReturnsFalse(int firstX, int firstY, int secondX, int secondY)
        {
            var firstPoint = new Point(firstX, firstY);
            var secondPoint = new Point(secondX, secondY);

            var result = firstPoint == secondPoint;

            Assert.False(result);
        }

        [Test]
        [TestCase(13, -20, 13, -20)]
        [TestCase(7, 1, 7, 1)]
        [TestCase(0, 0, 0, 0)]
        public void Inequality_EqualObjects_ReturnsFalse(int firstX, int firstY, int secondX, int secondY)
        {
            var firstPoint = new Point(firstX, firstY);
            var secondPoint = new Point(secondX, secondY);

            var result = firstPoint != secondPoint;

            Assert.False(result);
        }

        [Test]
        [TestCase(14, -20, 3, -20)]
        [TestCase(7, 0, -3, 1)]
        [TestCase(0, 4, 0, 0)]
        public void Inequality_NotEqualObjects_ReturnsTrue(int firstX, int firstY, int secondX, int secondY)
        {
            var firstPoint = new Point(firstX, firstY);
            var secondPoint = new Point(secondX, secondY);

            var result = firstPoint != secondPoint;

            Assert.True(result);
        }

        #endregion
    }
}
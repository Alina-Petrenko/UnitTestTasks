using NUnit.Framework;
using System;

namespace FourthTask.UnitTest
{
    [TestFixture]
    public class PantherTests
    {
        #region Fields

        /// <summary>
        /// TestCasesSetValue
        /// </summary>
        private static readonly object[] TestCasesSetValue =
        {
            new Panther("Panther", 7, Gender.Male, 29, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,15,55,10)),
            new Panther("Panther", 4, Gender.Male, 70, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,15,40,10)),
            new Panther("Panther", 10, Gender.Female, 63, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,19,30,10)),
        };

        /// <summary>
        /// TestCases
        /// </summary>
        private static readonly object[] TestCases =
        {
            ("Panther", 7, Gender.Male, 29, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,15,55,10)),
            ("Panther", 4, Gender.Male, 70, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,15,40,10)),
            ("Panther", 10, Gender.Female, 63, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,19,30,10)),
        };

        /// <summary>
        /// TestCasesTime
        /// </summary>
        private static readonly object[] TestCasesTime =
        {
            (new DateTime(2022,5,4,15,55,10), new DateTime(2022,5,4,15,20,10)),
            (new DateTime(2022,5,4,15,40,10), new DateTime(2022,5,4,15,20,10)),
            (new DateTime(2022,5,4,19,30,10), new DateTime(2022,5,4,15,20,10)),
        };

        /// <summary>
        /// TestCasesDistance
        /// </summary>
        private static readonly object[] TestCasesDistance =
        {
            (64, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,15,55,10),  37.33),
            (32, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,15,40,10), 10.67),
            (78, new DateTime(2022,5,4,15,20,10), new DateTime(2022,5,4,19,30,10), 325.0)
        };

        #endregion

        #region Tests

        /// <summary>
        /// Creates an object with valid data
        /// </summary>
        /// <param name="tuple">Tuple with name, age, gender, speed, start time, and end time</param>
        [Test, TestCaseSource("TestCases")]
        public void Constructor_ValidData_ExpectedObjectCreated((string name, int age, Gender gender, int speed, DateTime start, DateTime end) tuple)
        {
            // Act & Arrange
            var panther = new Panther(tuple.name, tuple.age, tuple.gender, tuple.speed, tuple.start, tuple.end);

            // Assert
            Assert.AreEqual(tuple.name, panther.Name);
            Assert.AreEqual(tuple.age, panther.Age);
            Assert.AreEqual(tuple.gender, panther.Gender);
            Assert.AreEqual(tuple.speed, panther.Speed);
            Assert.AreEqual(tuple.start, panther.StartTime);
            Assert.AreEqual(tuple.end, panther.EndTime);
        }

        /// <summary>
        /// Catch exception after setting invalid data
        /// </summary>
        /// <param name="tuple">Tuple with start time and end time</param>
        [Test, TestCaseSource("TestCasesTime")]
        public void Constructor_InvalidData_ExpectedException((DateTime start, DateTime end) tuple)
        {
            // TODO: provided example how it should looks like in BirdTests.
            // Act & Arrange & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Panther("Panther", 7, Gender.Male, 40, tuple.start, tuple.end));
        }

        /// <summary>
        /// Calculates distance
        /// </summary>
        /// <param name="tuple">Tuple with speed, start time, end time and expected distance</param>
        [Test, TestCaseSource("TestCasesDistance")]
        public void DistanceCalculation_ValidData_ExpectedDistance((int speed, DateTime start, DateTime end, double expectedDistance) tuple)
        {
            // Act
            var panther = new Panther("Panther", 7, Gender.Male, tuple.speed, tuple.start, tuple.end);
            var time = tuple.end - tuple.start;

            // Arrange
            var result = panther.DistanceCalculation(tuple.speed, time);

            // Assert
            Assert.AreEqual(tuple.expectedDistance, result);
        }

        /// <summary>
        /// Сhecks valid <paramref name="speed"/> for compliance with the limit
        /// </summary>
        /// <param name="speed">Speed</param>
        [Test]
        [TestCase(20)]
        [TestCase(40)]
        [TestCase(70)]
        public void SpeedCheck_ValidData_ExpectedSpeed(int speed)
        {
            // Act & Arrange
            var panther = new Panther("Panther", 7, Gender.Male, speed, new DateTime(2022, 5, 4, 15, 20, 10),
                new DateTime(2022, 5, 4, 15, 55, 10));

            // Assert
            Assert.AreEqual(speed, panther.Speed);
        }

        /// <summary>
        /// Catch exception after setting invalid data
        /// </summary>
        /// <param name="speed"></param>
        [Test]
        [TestCase(90)]
        [TestCase(83)]
        [TestCase(105)]
        public void SpeedCheck_InvalidData_ExpectedException(int speed)
        {
            // Act & Arrange & Assert
            Assert.Throws<OverSpeedException>(() => new Panther("Panther", 7, Gender.Male, speed, new DateTime(2022, 5, 4, 15, 20, 10), new DateTime(2022, 5, 4, 15, 55, 10)));
        }

        #endregion
    }
}

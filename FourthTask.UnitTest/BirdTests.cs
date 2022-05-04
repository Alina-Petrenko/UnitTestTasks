using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace FourthTask.UnitTest
{
    [TestFixture]
    public class BirdTests
    {
        #region Fields

        /// <summary>
        /// TestCasesSetValues
        /// </summary>
        private static readonly object[] TestCasesSetValues =
        {
            new Bird("Bird",4,Gender.Male,20),
            new Bird("Bird",10,Gender.Female,60),
            new Bird("Bird",1,Gender.Male,35)
        };

        /// <summary>
        /// TestCasesDistance
        /// </summary>
        private static readonly object[] TestCasesDistance =
        {
            (20, new TimeSpan(0, 30, 0), 10.0),
            (40, new TimeSpan(0, 15, 0), 10.0),
            (16, new TimeSpan(0, 7, 0), 1.87)
        };

        #endregion

        #region Tests

        /// <summary>
        /// Creates an object with valid data
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="gender">Gender</param>
        /// <param name="speed">Speed</param>
        [Test]
        [TestCase("Bird", 1, Gender.Male, 20)]
        [TestCase("Bird", 10, Gender.Female, 60)]
        [TestCase("Bird", 1, Gender.Male, 35)]
        public void Constructor_ValidData_ExpectedObjectCreated(string name, int age, Gender gender, int speed)
        {
            // Act & Arrange
            var bird = new Bird(name, age, gender, speed);

            // Assert
            Assert.AreEqual(name, bird.Name);
            Assert.AreEqual(age, bird.Age);
            Assert.AreEqual(gender, bird.Gender);
            Assert.AreEqual(speed, bird.Speed);
        }

        /// <summary>
        /// Sets value 'InSky' in 'true'
        /// </summary>
        /// <param name="bird">Bird object</param>
        [Test, TestCaseSource("TestCasesSetValues")]
        public void TakeOff_ChangeStateToInSky_ExpectedInSkyIsTrue(Bird bird)
        {
            // Act & Arrange
            bird.TakeOff();
            var result = bird.InSky;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Sets value 'InSky' in 'false'
        /// </summary>
        /// <param name="bird"></param>
        [Test, TestCaseSource("TestCasesSetValues")]
        public void Land_ChangeStateToInSky_ExpectedInSkyIsFalse(Bird bird)
        {
            // Act & Arrange
            bird.Land();
            var result = bird.InSky;

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Calculates distance
        /// </summary>
        /// <param name="tuple">Tuple with speed, time and expected distance</param>
        [Test, TestCaseSource("TestCasesDistance")]
        public void DistanceCalculation_ValidData_ExpectedDistance((int speed, TimeSpan time, double expectedDistance) tuple)
        {
            // Act
            var bird = new Bird("Bird", 4, Gender.Male, 20);

            // Arrange
            var result = bird.DistanceCalculation(tuple.speed, tuple.time);

            // Assert
            Assert.AreEqual(tuple.expectedDistance, result);
        }

        /// <summary>
        /// Ñhecks valid <paramref name="speed"/> for compliance with the limit
        /// </summary>
        /// <param name="speed">Speed</param>
        [Test]
        [TestCase(20)]
        [TestCase(40)]
        [TestCase(70)]
        public void SpeedCheck_ValidData_ExpectedSetSpeed(int speed)
        {
            // Act & Arrange
            var bird = new Bird("Bird", 4, Gender.Male, speed);

            // Assert
            Assert.AreEqual(speed, bird.Speed);
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
            Assert.Throws<OverSpeedException>(() => new Bird("Bird", 4, Gender.Male, speed));
        }

        #endregion
    }
}
using System;
using System.Diagnostics;

namespace FourthTask
{
    /// <summary>
    /// Class represents Bird
    /// </summary>
    public class Bird: Animal, IFlyable
    {
        #region Fields
        /// <summary>
        /// Stopwatch
        /// </summary>
        private Stopwatch _stopwatch = new Stopwatch();
        #endregion

        #region Properties
        /// <summary>
        /// Is bird in sky
        /// </summary>
        public bool InSky { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Sets the initial value
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="gender">Gender</param>
        /// <param name="speed">Speed</param>
        public Bird(string name, int age, Gender gender, int speed)
        {
            Name = name;
            Age = age;
            PawCount = 2;
            Gender = gender;
            Speed = SpeedCheck(speed);
            InSky = false;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Represents the state change of the bird to "in Sky"
        /// </summary>
        public void TakeOff()
        {
            InSky = true;
            _stopwatch.Start();
        }

        /// <summary>
        /// Represents the state change of the bird to "on Land"
        /// </summary>
        /// <returns>Returns time spent in flight</returns>
        public TimeSpan Land()
        {
            var random = new Random();
            InSky = false;
            _stopwatch.Stop();
            var time = TimeSpan.FromMinutes(random.Next(1,61));
            return _stopwatch.Elapsed + time;   
        }

        /// <summary>
        /// Calculates distance covered
        /// </summary>
        /// <param name="speed">Speed</param>
        /// <param name="time">Time</param>
        /// <returns>Returns distance covered</returns>
        public double DistanceCalculation(int speed, TimeSpan time)
        {
            var distance = Math.Round(((double)(time.TotalMinutes) / 60 * speed),2);
            return distance;
        }

        /// <summary>
        /// Сhecks the received speed for compliance with the limit
        /// </summary>
        /// <param name="speed">Received speed</param>
        /// <returns>Returns speed</returns>
        /// <exception cref="OverSpeedException">Over speed for animal</exception>
        public override int SpeedCheck(int speed)
        {
            if (speed > 80)
            {
                throw new OverSpeedException(speed);
            }
            else
            {
                return speed;
            }
        }
        #endregion
    }
}

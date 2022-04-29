using System;

namespace FourthTask
{
    /// <summary>
    /// Class represents Panther
    /// </summary>
    public class Panther : Animal, IRunnable
    {
        #region Properties
        /// <summary>
        /// Start Time
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End Time
        /// </summary>
        public DateTime EndTime { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Sets the initial value
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="gender">Gender</param>
        /// <param name="speed">Speed</param>
        public Panther(string name, int age, Gender gender, int speed, DateTime startTime, DateTime endTime)
        {
            Name = name;
            Age = age;
            PawCount = 4;
            Gender = gender;
            Speed = SpeedCheck(speed);
            EndTime = endTime;
            if (startTime > endTime)
            {
                throw new ArgumentOutOfRangeException("Start time can't be bigger then end time");
            }
            else
            {
                StartTime = startTime;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Calculates distance covered
        /// </summary>
        /// <param name="speed">Speed</param>
        /// <param name="time">Time</param>
        /// <returns>Returns distance covered</returns>
        public double DistanceCalculation(int speed, TimeSpan time)
        {
            var distance = Math.Round(((double)(time.TotalMinutes) / 60 * speed), 2);
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

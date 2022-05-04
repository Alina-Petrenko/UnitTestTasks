using System;

namespace FourthTask
{
    /// <summary>
    /// Provides a method for calculating distance
    /// </summary>
    public interface IMobile
    {
        #region Public Methods

        /// <summary>
        /// Calculates distance covered
        /// </summary>
        /// <param name="speed">Speed</param>
        /// <param name="time">Time</param>
        /// <returns>Returns distance covered</returns>
        public double DistanceCalculation(int speed, TimeSpan time);

        #endregion
    }
}

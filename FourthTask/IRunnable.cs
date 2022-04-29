using System;

namespace FourthTask
{
    /// <summary>
    /// Provides properties to define the start and end of a movement
    /// </summary>
    public interface IRunnable: IMobile
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
    }
}

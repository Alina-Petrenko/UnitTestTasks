using System;

namespace FourthTask
{
    /// <summary>
    /// Provides fields and properties for determining the bird's position
    /// </summary>
    public interface IFlyable : IMobile
    {
        #region Properties

        /// <summary>
        /// Is bird in sky
        /// </summary>
        bool InSky { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Represents the state change of the bird to "in Sky"
        /// </summary>
        public void TakeOff();

        /// <summary>
        /// Represents the state change of the bird to "on Land"
        /// </summary>
        /// <returns>Returns time spent in flight</returns>
        public TimeSpan Land();

        #endregion
    }
}

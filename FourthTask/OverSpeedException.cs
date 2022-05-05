using System;

namespace FourthTask
{
    /// <summary>
    /// Class represents Exception class
    /// </summary>
    /// TODO: Take a look on new implementation.
    public class OverSpeedException : Exception
    {
        #region Fields

        /// <summary>
        /// Exception message template.
        /// </summary>
        private const string ExceptionMessage = "Over speed for animal: {speed}. Expected limit: 80";
        
        #endregion
        
        #region Public Methods

        /// <summary>
        /// Returns an error message
        /// </summary>
        /// <param name="speed">Recieved speed</param>
        public OverSpeedException(int speed) : base(string.Format(ExceptionMessage, speed))
        {
            Console.WriteLine(ExceptionMessage, speed);
        }

        #endregion
    }
}

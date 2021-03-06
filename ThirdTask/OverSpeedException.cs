using System;

namespace ThirdTask
{
    /// <summary>
    /// Class represents Exception class
    /// </summary>
    public class OverSpeedException : Exception
    {
        /// <summary>
        /// Returns an error message
        /// </summary>
        /// <param name="speed">Recieved speed</param>
        public OverSpeedException(int speed)
        {
            Console.WriteLine($"Over speed for animal: {speed}. Expected limit: 80");
        }
    }
}

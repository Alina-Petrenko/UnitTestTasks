using System;

namespace SecondTask
{
    /// <summary>
    /// Provides an extension method for the Random class
    /// </summary>
    public static class RandomExtension
    {
        /// <summary>
        /// Generates random coordinates
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Returns tuple of coordinates</returns>
        public static (int X,int Y) GetRandomPoint (this Random random)
        {
            return (random.Next(-10,11),random.Next(-10,11));
        }
    }
}

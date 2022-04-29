using System;

namespace ThirdTask
{
    /// <summary>
    /// Provides an extension method for the Random class
    /// </summary>
    public static class RandomExtension
    {
        /// <summary>
        /// Generates random animal
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Returns random animal</returns>
        public static Animal GetRandomAnimal(this Random random)
        {
            int value;
            value = random.Next(1, 4);
            switch (value)
            {
                case 1:
                    return new Spider("Spider", random.Next(1, 6), (Gender)Enum.GetValues(typeof(Gender)).GetValue(random.Next(0, 2)), random.Next(1, 5));
                case 2:
                    return new Lama("Lama", random.Next(1, 21), (Gender)Enum.GetValues(typeof(Gender)).GetValue(random.Next(0, 2)), random.Next(1, 20));
                case 3:
                    return new Snake("Snake", random.Next(1, 10), (Gender)Enum.GetValues(typeof(Gender)).GetValue(random.Next(0, 2)), random.Next(1, 10));
                default:
                    break;
            }
            throw new Exception("Something wrong");
        }
    }
}

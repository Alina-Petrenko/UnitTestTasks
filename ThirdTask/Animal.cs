using System;

namespace ThirdTask
{
    /// <summary>
    /// Provides gender of animals
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// Class represents animal
    /// </summary>
    public abstract class Animal
    {
        private int age;
        private int speed;
        public string Name { get; protected set; }
        public int Age
        {
            get
            {
                return age;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age can't be less then 0");
                }
                else
                {
                    age = value;
                }
            }
        }
        public int CountOfPaw { get; protected set; }
        public Gender AnimalGender { get; protected set; }
        public int Speed
        {
            get
            {
                return speed;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Speed can't be less then 0");
                }
                else
                {
                    speed = value;
                }
            }
        }

        /// <summary>
        /// Сhecks the received speed for compliance with the limit
        /// </summary>
        /// <param name="speed">Received speed</param>
        /// <returns>Returns speed</returns>
        /// <exception cref="OverSpeedException">Over speed for animal</exception>
        public abstract int SpeedCheck(int speed);
    }
}

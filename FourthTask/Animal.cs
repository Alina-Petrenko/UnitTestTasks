using System;

namespace FourthTask
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
    /// Class represents animal.
    /// </summary>
    public abstract class Animal
    {
        #region Fields

        /// <summary>
        /// Age
        /// </summary>
        private int _age;

        /// <summary>
        /// Maximum speed
        /// </summary>
        private int _speed;

        #endregion

        #region Properties

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Count of paw
        /// </summary>
        public int PawCount { get; protected set; }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; protected set; }

        /// <summary>
        /// Age
        /// </summary>
        public int Age
        {
            get => _age;
            protected set
            {
                if (value <= 0)
                {
                    // TODO: Not covered by unit tests
                    throw new ArgumentOutOfRangeException(nameof(Age));
                }

                _age = value;
            }
        }

        /// <summary>
        /// Maximum speed
        /// </summary>
        public int Speed
        {
            get => _speed;
            protected set
            {
                if (value <= 0)
                {
                    // TODO: Not covered by unit tests
                    throw new ArgumentOutOfRangeException(nameof(Speed));
                }

                _speed = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Сhecks the received speed for compliance with the limit.
        /// </summary>
        /// <param name="speed">Received speed</param>
        /// <returns>Returns speed</returns>
        /// <exception cref="OverSpeedException">Thrown when animal tried to over speed</exception>
        public abstract int SpeedCheck(int speed);

        #endregion
    }
}


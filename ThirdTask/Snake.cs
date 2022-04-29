namespace ThirdTask
{
    /// <summary>
    /// Class represents Snake
    /// </summary>
    internal class Snake: Animal
    {
        public Snake(string name, int age, Gender gender, int speed)
        {
            Name = name;
            Age = age;
            CountOfPaw = 0;
            AnimalGender = gender;
            Speed = SpeedCheck(speed);
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
    }
}

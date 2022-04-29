namespace ThirdTask
{
    /// <summary>
    /// Class represents Lama
    /// </summary>
    public class Lama : Animal
    {
        public Lama(string name, int age, Gender genders, int speed)
        {
            Name = name;
            Age = age;
            CountOfPaw = 4;
            AnimalGender = genders;
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

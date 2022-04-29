using System;

namespace FourthTask
{
    /// <summary>
    /// Starts the project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Prints the result of the distance calculation to the console
        /// </summary>
        static void Main()
        {
            var random = new Random();
            var bird = new Bird("Bird", 1, Gender.Male, 10);
            bird.TakeOff();
            IFlyable birdIFlyable = new Bird("Bird IFlyable", 2, Gender.Female, 12);
            birdIFlyable.TakeOff();
            IMobile birdIMobile = new Bird("Bird IMobile", 1, Gender.Male, 9);

            var birdTime = bird.Land();
            var birdResult = bird.DistanceCalculation(bird.Speed, birdTime);
            Console.WriteLine($"bird distance: {birdResult} km/h, speed: {bird.Speed}, time: {birdTime}");

            var birdIFlyableTime = birdIFlyable.Land();
            var birdIFlyableResult = birdIFlyable.DistanceCalculation(12, birdIFlyableTime);
            Console.WriteLine($"birdIFlyable distance: {birdIFlyableResult} km/h, speed: 12, time: {birdIFlyableTime}");

            var randomTime = TimeSpan.FromMinutes(random.Next(1, 61));
            var birdIMobileResult = birdIMobile.DistanceCalculation(9, randomTime);
            Console.WriteLine($"birdIMobile distance: {birdIMobileResult} km/h, speed: 9, time: {randomTime}");
            Console.WriteLine("");

            var panther = new Panther("Panther", 2, Gender.Male, 70, new DateTime(2022, 4, 7, 18, 30, 25), new DateTime(2022, 4, 7, 18, 50, 00));
            var pantherResult = panther.DistanceCalculation(panther.Speed, (panther.EndTime - panther.StartTime));
            Console.WriteLine($"panther distance: {pantherResult} km/h, speed: {panther.Speed}, time: {panther.EndTime - panther.StartTime}");

            IRunnable pantherIRunnable = new Panther("Panther", 1, Gender.Female, 45, new DateTime(2022, 4, 7, 17, 43, 00), new DateTime(2022, 4, 7, 18, 10, 02));
            var pantherIRunnableResult = pantherIRunnable.DistanceCalculation(45, (pantherIRunnable.EndTime - pantherIRunnable.StartTime));
            Console.WriteLine($"pantherIRunnable distance: {pantherIRunnableResult} km/h, speed: 45, time: {pantherIRunnable.EndTime - pantherIRunnable.StartTime}");

            IMobile pantherIMobile = new Panther("Panther", 6, Gender.Male, 79, new DateTime(2022, 4, 7, 19, 34, 19), new DateTime(2022, 4, 7, 20, 06, 56));
            var pantherIMobileResult = pantherIMobile.DistanceCalculation(79, (new DateTime(2022, 4, 7, 20, 06, 56) - new DateTime(2022, 4, 7, 19, 34, 19)));
            Console.WriteLine($"pantherIMobile distance: {pantherIMobileResult} km/h, speed: 79, time: {new DateTime(2022, 4, 7, 20, 06, 56) - new DateTime(2022, 4, 7, 19, 34, 19)}");
        }
    }
}

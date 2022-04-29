using System;
using System.Collections.Generic;

namespace ThirdTask
{
    /// <summary>
    /// Starts the project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Prints the array of random animal
        /// </summary>
        static void Main()
        {
            List<Animal> animals = new List<Animal>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var animal = random.GetRandomAnimal();
                animals.Add(animal);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}, Speed: {animal.Speed}, Count of paws {animal.CountOfPaw}, Gender: {animal.AnimalGender}");
            }
            Console.WriteLine("\nPress 'Y/y' to send animal for Extension, or any other character to exit ");
            var value = Console.ReadLine();
            if (value.ToLower() == "y")
            {
                animals.Add(new Lama("Lama", 10, Gender.Female, 90));
            }
            
        }
    }
}

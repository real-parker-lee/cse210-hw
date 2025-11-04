using System;

class Program
{
    static void Main()
    {
        /// generate a random int from 1 to 11
        Random randomGenerator = new Random();
        
        int magicNum = randomGenerator.Next(1,11);
        
        // Console.Write("Please enter your number: ");
        
        // int magicNum = int.Parse(Console.ReadLine());
        
        int guess;
        do {
            Console.Write("Guess the magic Number: ");
            guess = int.Parse(Console.ReadLine());
            
            // guess check logic
            if (guess > magicNum)
            {
                Console.WriteLine($"{guess} is too high! Guess lower.");
            }
            else if (guess < magicNum)
            {
                Console.WriteLine($"{guess} is too low! Guess higher.");
            }
            else
            {
                Console.WriteLine("You guessed it! Good job!");
            }
        } while (guess != magicNum);
    }
}

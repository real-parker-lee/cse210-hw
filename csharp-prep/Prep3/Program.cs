using System;

class Program
{
    static void Main()
    {
        // ask user for number
        Console.Write("Please enter your number: ");
        
        int magicNum = int.Parse(Console.ReadLine());
        
        // ask for a guess
        Console.Write("Guess the magic Number: ");
        int guess = int.Parse(Console.ReadLine());
        
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
    }
}

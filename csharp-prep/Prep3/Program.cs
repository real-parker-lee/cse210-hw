using System;

class Program
{
    static void Main()
    {
        /// generate a random int from 1 to 11
        Random randomGenerator = new Random();
        
        int magicNum;
        
        int guessCount = 0;
        
        bool playAgain = true;
        bool responseValid = false;
        
        // Console.Write("Please enter your number: ");
        
        // int magicNum = int.Parse(Console.ReadLine());
        
        int guess;
        string replayStr = "";
        do 
        {
            // game stuff
            magicNum= randomGenerator.Next(1,11);
            do {
                Console.Write("Guess the magic Number: ");
                guess = int.Parse(Console.ReadLine());
                
                // guess check logic
                if (guess > magicNum)
                {
                    Console.WriteLine($"{guess} is too high! Guess lower.");
                    ++guessCount;
                }
                else if (guess < magicNum)
                {
                    Console.WriteLine($"{guess} is too low! Guess higher.");
                    ++guessCount;
                }
                else
                {
                    Console.WriteLine($"You guessed it in {++guessCount} tries! Good job!");
                }
            } while (guess != magicNum);
            // menu stuff
            do
            {
                Console.Write("Play Again? [Y/n]: ");
                replayStr = Console.ReadLine();
                
                if (replayStr == "" || replayStr == "y" || replayStr == "Y")
                {
                    playAgain = true;
                    responseValid = true;
                    guessCount = 0;
                }
                else if (replayStr == "n" || replayStr == "N")
                {
                    playAgain = false;
                    responseValid = true;
                    guessCount = 0;
                }
                else
                {
                    Console.WriteLine($"Invalid input: '{replayStr}'. Choose either 'y' or 'n'");
                    responseValid = false;
                }
            } while (!responseValid);
        } while (playAgain);
        
    }
}

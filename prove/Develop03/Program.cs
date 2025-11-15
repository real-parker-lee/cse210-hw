using System;

class Program
{
    static void Main(string[] args)
    {
        // bare requirements: 1 scripture
        List<Scripture> scriptures = new List<Scripture>();
        
        scriptures.Add(new Scripture("John", 3, 16, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        
        string resp = "a"; // dummy invalid input
        
        while (resp != "q" && resp != "quit")
        {
            Console.WriteLine("Press Enter to remove three words, or enter 'q' or 'quit' to exit.\n");
            scriptures[0].PrintPrompt();
            //Console.WriteLine("\n");
            
            // check if the game can even be progressed.
            if (scriptures[0].CountShown() == 0)
            {
                Console.WriteLine("No more words to hide. Exiting.");
                break;
            }
            
            // input validation
            do
            {
                Console.Write("> ");
                resp = Console.ReadLine();
                if (resp != "q" && resp != "quit" && resp !="")
                {
                    Console.WriteLine($"Invalid Input: {resp}");
                }
            }
            while (resp != "q" && resp != "quit" && resp !="");
            
            // if we get to this point, check resp to see if we should quit. if not, invoke Scripture.Hide().
            if (resp != "q" && resp != "quit")
            {
                scriptures[0].HideRandomWord();
                Console.Write("\n");
            }
        }
    }
}

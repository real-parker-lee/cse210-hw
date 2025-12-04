public class Program
{
    static void Main(string[] args)
    {   
        GoalTracker tracker = new GoalTracker();
        Console.WriteLine("Welcome to the EternalQuest REPL v1.0!\n");
        Console.WriteLine("Type \"about\" to learn more about this program.");
        Console.WriteLine("Type \"help\" for a list of all available commands and their usage.\n");
        tracker.RunRepl();
    }
}

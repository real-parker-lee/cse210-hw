class Program
{
    static void Main(string[] args)
    {
        Menu mainMenu = new Menu("Welcome to the Mindfulness Helper! Choose an option by its number below:", "> ");
        
        Breathing b = new Breathing(4, 6);
        b.SetDuration(20);
        
        Reflection r = new Reflection();
        r.AddPrompt("Think of a time when you stood up for someone else...");
        r.AddPrompt("Think of a time when you did something really difficult...");
        r.AddPrompt("Think of a time when you helped someone in need...");
        r.AddPrompt("Think of a time when you did something truly selfless...");
        
        r.AddQuestion("Why was this experience meaningful to you?");
        r.AddQuestion("Have you ever done anything like this before?");
        r.AddQuestion("How did you get started?");
        r.AddQuestion("How did you feel when it was complete?");
        r.AddQuestion("What made this time different than other times when you were not as successful?");
        r.AddQuestion("What is your favorite thing about this experience?");
        r.AddQuestion("What could you learn from this experience that applies to other situations?");
        r.AddQuestion("What did you learn about yourself through this experience?");
        r.AddQuestion("How can you keep this experience in mind in the future?");
        
        //mainMenu.AddItem(new MenuItem("Test Activity class Functions", a));
        mainMenu.AddItem(new MenuItem("Practice Mindful Breathing", b));
        mainMenu.AddItem(new MenuItem("Reflect on Resillience", r));
        
        Activity chosen = mainMenu.Show();
        chosen.Run();
    }
}

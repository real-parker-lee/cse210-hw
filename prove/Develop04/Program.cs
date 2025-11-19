class Program
{
    static void Main(string[] args)
    {
        Menu mainMenu = new Menu("Welcome to the Mindfulness Helper! Choose an option by its number below:", "> ");
        
        Breathing b = new Breathing(4, 6);
        b.SetDuration(20);
        
        //mainMenu.AddItem(new MenuItem("Test Activity class Functions", a));
        mainMenu.AddItem(new MenuItem("Practice Mindful Breathing", b));
        
        Activity chosen = mainMenu.Show();
        chosen.Run();
    }
}

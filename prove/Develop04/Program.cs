using System;

class Program
{
    static void Main(string[] args)
    {
        Menu mainMenu = new Menu("Welcome to the Mindfulness Helper! Choose an option by its number below:", "> ");
        
        Activity a = new Activity("descriptionTest");
        a.SetDuration(5);
        
        Activity b = new Activity("activity b");
        b.SetDuration(2);
        
        mainMenu.AddItem(new MenuItem("Test Activity class Functions", a));
        mainMenu.AddItem(new MenuItem("the other one.", b));
        
        Activity chosen = mainMenu.Show();
    }
}

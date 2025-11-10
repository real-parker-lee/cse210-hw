using System;
// using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // init global values
        Menu menu = new Menu();
        int selection;
        bool done = false;
        string loadPath; // holds path to load from.
        string savePath; // path to save to. may be empty.
        
        // init journal with prompts
        Journal journal = new Journal();
        journal.AddPrompt("I saw the hand of Christ in my life in");
        journal.AddPrompt("Today I am thankful for");
        journal.AddPrompt("What happened today");
        journal.AddPrompt("Name a Rose (Good thing) and a Thorn (Bad thing) that happened today");
        
        
        do
        {
            selection = menu.ProcessMenu();
            switch(selection)
            {
                case 1:
                    // create new entry
                    journal.AddEntry();
                    Console.WriteLine("Entry added.\n");
                    break;
                    
                case 2:
                    Console.WriteLine($"Displaying {journal.EntryCount()} entries:\n");
                    journal.Display();
                    break;
                    
                case 3:
                    // save to file
                    Console.Write("Enter filepath to save to, or leave blank to overwrite the loaded file: ");
                    savePath = Console.ReadLine();
                    if ("" == savePath)
                    {
                        journal.WriteToFile();
                        Console.WriteLine("placeholder: saving to loaded file\n");
                    }
                    else
                    {
                        Console.WriteLine($"placeholder: saving to new path: {savePath}");
                        journal.WriteToFile(savePath);
                    }
                    
                    Console.WriteLine($"Saved journal to path: {journal.GetCurrentPath()}\n");
                    break;
                    
                case 4:
                    // load from file
                    Console.Write("Enter path to journal: ");
                    loadPath = Console.ReadLine();
                    journal.ReadFromFile(loadPath);
                    Console.WriteLine($"Successfully loaded journal at {loadPath}\n");
                    break;
                    
                case 5:
                    //quit
                    done = true;
                    Console.WriteLine("Goodbye.");
                    break;
            }
        } while (!done);
    }
}

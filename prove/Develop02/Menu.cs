class Menu
{
  public string[] _menuStrings = {
    "Welcome to the Count",
    "OPTIONS:",
    "1. Create Journal Entry",
    "2. Display Journal",
    "3. Save Journal to File",
    "4. Read Journal from File",
    "5. Quit"
  };
  
  public int ProcessMenu()
  {
    foreach (string s in _menuStrings)
    {
      Console.WriteLine(s);
    }
    
    int choice = 0;
    do
    {
      choice = int.Parse(Console.ReadLine());
    } while (choice < 1 || choice > 5);
    
    return choice;
  }
}

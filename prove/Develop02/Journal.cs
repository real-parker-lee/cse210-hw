public class Journal
{
  protected List<Entry> _entries = new List<Entry>();
  protected List<string> _prompts = new List<string>();
  protected string _currentPath;
  
  public void Display()
  {
    foreach (Entry e in _entries)
    {
      e.Display();
    }
  }
  
  // public void ReadFromFile(string path)
  // {
  //   // read data from file, then set _currentPath so that saving is more streamlined later.
  // }
  
  // public void WriteToFile()
  // {
  //   // use _currentPath as file to save to.
  // }
  
  // public void WriteToFile(string path)
  // {
  //   // specify new file to save to.
  //   // NOTE: also should set _currentPath to the new value.
  // }
  
  public void AddEntry()
  {
    Entry e = new Entry();
    // get date
    // for now, using a random string
    string date = "TODAY";
    
    // get a random prompt
    Random rand = new Random();
    string thisPrompt = _prompts[rand.Next(0, _prompts.Count + 1)];
    
    // get user input for content
    Console.WriteLine($"{thisPrompt}:");
    string resp = Console.ReadLine();
    
    // finally, add the entry to the list
    e.Make(resp, date, thisPrompt);
    _entries.Add(e);
  }
  
  public void AddPrompt(string newPrompt)
  {
    _prompts.Add(newPrompt);
  }
  
  public string GetCurrentPath()
  {
    return _currentPath;
  }
}

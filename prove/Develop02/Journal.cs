using System.IO;

public class Journal
{
  protected List<Entry> _entries = new List<Entry>();
  protected List<string> _prompts = new List<string>();
  protected string _currentPath = "./journal.txt";
  
  public void Display()
  {
    foreach (Entry e in _entries)
    {
      e.Display();
    }
  }
  
  public void ReadFromFile(string path)
  {
    _currentPath = path;
    string[] lines = System.IO.File.ReadAllLines(path);
    // process the lines into journal entries
    foreach (string line in lines)
    {
      // split by | to get data
      string[] fields = line.Split("|");
      
      // create new entry and add to list
      Entry e = new Entry();
      e.Make(fields[2], fields[0], fields[1]);
      _entries.Add(e);
    }
  }
  
  public void WriteToFile()
  {
    using (StreamWriter output = new StreamWriter(_currentPath))
    {
      foreach (Entry e in _entries)
      {
        output.WriteLine(e.Serialize());
      }
    }
  }
  
  public void WriteToFile(string path)
  {
    _currentPath = path;
    using (StreamWriter output = new StreamWriter(_currentPath))
    {
      foreach (Entry e in _entries)
      {
        output.WriteLine(e.Serialize());
      }
    }
  }
  
  public void AddEntry()
  {
    Entry e = new Entry();
    // get date
    DateTime now = DateTime.Now;
    string date = now.ToShortDateString();
    
    // get a random prompt
    Random rand = new Random();
    string thisPrompt = _prompts[rand.Next(0, _prompts.Count)];
    
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
  
  public int EntryCount()
  {
    return _entries.Count;
  }
}

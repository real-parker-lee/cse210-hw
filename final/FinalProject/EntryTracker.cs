public class EntryTracker
{
  private string _groupName;
  private string _entryType;
  private List<Entry> _entries = new List<Entry>();
  private string _currentPath;
  
  public void SetCurrentPath(string p)
  {
    _currentPath = p;
  }
  
  public string GetCurrentPath()
  {
    return _currentPath;
  }
  
  public void SetGroupName(string gn)
  {
    _groupName = gn;
  }
  
  public string GetGroupName()
  {
    return _groupName;
  }
  
  public List<Entry> GetEntries()
  {
    return _entries;
  }
  
  public string GetEntryType()
  {
    return _entryType;
  }
  
  public void SetEntryType(string et)
  {
    _entryType = et.ToUpper();
  }
  
  public EntryTracker(string et, string gn)
  {
    SetEntryType(et);
    SetGroupName(gn);
  }
  
  public EntryTracker(string et, string gn, string path)
  {
    SetEntryType(et);
    SetGroupName(gn);
    SetCurrentPath(path);
  }
  
  public string Serialize()
  {
    string content = "";
    foreach (Entry e in GetEntries())
    {
      content = content + e.Serialize() + "\n";
    }
    // write to file at currentPath.
    return content;
    
  }
  
  public static List<EntryTracker> Deserialize(string path)
  {
    List<EntryTracker> trackers = new List<EntryTracker>();
    string[] lines = File.ReadAllLines(path);
    
    // NOTE: need to instance an EventTracker to access the methods, so we create a dud one for bootstrapping.
    trackers.Add(new EntryTracker("TASK", "Tasks"));
    trackers.Add(new EntryTracker("EVENT", "Events"));
    trackers.Add(new EntryTracker("NOTE", "Notes"));
    foreach (string l in lines)
    {
      string[] data = l.Split("|");
      switch (data[0])
      {
        case "TASK":
          trackers[0].AddEntry(new TaskEntry(data[1], Priority.FromNumber(int.Parse(data[2])), bool.Parse(data[3])));
          continue;
        case "EVENT":
          trackers[1].AddEntry(new EventEntry(data[1], Priority.FromNumber(int.Parse(data[2])), data[3], DateTime.Parse(data[4]), DateTime.Parse(data[5])));
          continue;
        case "NOTE":
          trackers[2].AddEntry(new NoteEntry(data[1], Priority.FromNumber(int.Parse(data[2])), data[4], DateTime.Parse(data[3])));
          continue;
        default:
          Console.WriteLine($"Error: Malformed data: '{l}'");
          break;
      }
    }
    return trackers;
  }
  
  public void AddEntry(Entry e)
  {
    _entries.Add(e);
  }
  
  public void ShowAll()
  {
    Console.WriteLine($"{GetGroupName()}:\n-------------------");
    for (int i = 0; i < GetEntries().Count(); i++)
    {
      Console.WriteLine($"{i+1}) {GetEntries()[i].Stringify()}");
    }
    Console.WriteLine("-------------------");
  }
}

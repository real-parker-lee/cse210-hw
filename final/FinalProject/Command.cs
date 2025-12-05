public class Command
{
  private string _name = "";
  private string _desc = "";
  private string _usage = "";
  private Action<string[], EntryTracker> _eval;
  
  public void SetUsage(string u)
  {
    _usage = u;
  }
  
  public string GetUsage()
  {
    return _usage;
  }
  
  public void SetEvalBody(Action<string[], EntryTracker> body)
  {
    _eval = body;
  }
  
  public string GetName()
  {
    return _name;
  }
  
  public void SetName(string n)
  {
    _name = n;
  }
  
  public string GetDesc()
  {
    return _desc;
  }
  
  public void SetDesc(string d)
  {
    _desc = d;
  }
  
  public void Eval(string[] args, EntryTracker tracker)
  {
    _eval(args, tracker);
  }
  
  public void Eval(string[] args, List<EntryTracker> trackers)
  {
    // handle special cases where no one tracker is specified.
    foreach (EntryTracker t in trackers)
    {
      Eval(args, t);
    }
  }
  
  public Command(string name, string usage, string desc, Action<string[], EntryTracker> body)
  {
    SetUsage(usage);
    SetEvalBody(body);
    SetName(name);
    SetDesc(desc);
  }
  
  public void ShowUsage()
  {
    Console.WriteLine($"{GetUsage()}");
  }
  
  public void ShowHelp()
  {
    Console.WriteLine(GetUsage());
    Console.WriteLine(GetDesc());
  }
}

public class Entry
{
  private string _name;
  private Priority _priority;
  private string _entryTypeString;
  
  public string GetEntryTypeString()
  {
    return _entryTypeString;
  }
  
  public void SetEntryTypeString(string et)
  {
    _entryTypeString = et.ToUpper();
  }
  
  public Entry(string name, Priority p)
  {
    SetEntryTypeString("ENTRY");
    _name = name;
    _priority = p;
  }
  
  public string GetName()
  {
    return _name;
  }
  
  public void SetName(string newName)
  {
    _name = newName;
  }
  
  public Priority GetPriority()
  {
    return _priority;
  }
  
  public void SetPriority(Priority p)
  {
    _priority = p;
  }
  
  public virtual string Stringify()
  {
    return $"{GetPriority().AsInt()} | {GetName()}";
  }
  
  public virtual string Serialize()
  {
    return $"ENTRY|{GetName()}|{GetPriority().AsInt()}";
  }
  
  public virtual void CheckOff()
  {
    return;
  }
  
  public virtual void CheckOff(int idx)
  {
    return;
  }
  
  public virtual string GetContents()
  {
    return "lkafdkjh";
  }
}

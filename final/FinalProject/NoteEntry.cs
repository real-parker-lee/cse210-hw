public class NoteEntry : Entry
{
  private string _contents = "";
  private DateTime _createdDate;
  
  public void SetCreationDate(DateTime d)
  {
    _createdDate = d;
  }
  
  public void SetContents(string c)
  {
    _contents = c;
  }
  
  public override string GetContents()
  {
    return _contents;
  }
  
  public DateTime GetCreationDate()
  {
    return _createdDate;
  }
  
  public NoteEntry(string name, Priority p, string contents, DateTime created)
  :base(name, p)
  {
    SetCreationDate(created);
  }
  
  public NoteEntry(string name, DateTime c)
  :base(name, Priority.FromNumber(0))
  {
    SetCreationDate(DateTime.Now);
  }
  
  public override string Serialize()
  {
    return $"NOTE|{base.GetName()}|{base.GetPriority().AsInt()}|{GetCreationDate()}|{GetContents()}";
  }
  
  public override string Stringify()
  {
    return $"";
  }
  
  public override void CheckOff(int idx)
  {
    CheckOff();
  }
  
  public override void CheckOff()
  {
    Console.WriteLine("Error: cannot check off a note.");
    return;
  }
}

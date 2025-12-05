public class EventEntry : Entry
{
  private DateTime _startDate;
  private DateTime _endDate;
  private string _location;
  
  public DateTime GetStartDate()
  {
    return _startDate;
  }
  
  public DateTime GetEndDate()
  {
    return _endDate;
  }
  
  public void SetStartDate(DateTime d)
  {
    _startDate = d;
  }
  
  public void SetEndDate(DateTime d)
  {
    _endDate = d;
  }
  
  public EventEntry(string n, Priority p, string loc, DateTime sd, DateTime ed)
  :base(n, p)
  {
    SetStartDate(sd);
    SetEndDate(ed);
    SetLocation(loc);
  }
  
  public void SetLocation(string loc)
  {
    _location = loc;
  }
  
  public string GetLocation()
  {
    return _location;
  }
  
  public override string Stringify()
  {
    return $"EVENT: {GetStartDate()} --> {GetEndDate()} : {GetName()} ({GetPriority().AsString()})";
  }
  
  public override string Serialize()
  {
    return $"EVENT|{base.GetName()}|{base.GetPriority().AsInt()}|{GetLocation()}|{GetStartDate()}|{GetEndDate()}";
  }
  
  public override void CheckOff()
  {
    Console.WriteLine("Error: cannot manually mark an event as done.");
    return;
  }
}

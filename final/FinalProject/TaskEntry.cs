public class TaskEntry : Entry
{
  private bool _isDone = false;
  
  public bool IsDone()
  {
    return _isDone;
  }
  
  public void SetDone(bool d)
  {
    _isDone = d;
  }
  
  public TaskEntry(string n, Priority p, bool d)
  :base(n, p)
  {
    SetDone(d);
  }
  
  public override string Stringify()
  {
    string check = IsDone() ? "x" : " ";
    return $"[{check}] {base.GetName()}";
  }

  public override string Serialize()
  {
      return $"TASK|{base.GetName()}|{base.GetPriority()}|{IsDone()}";
  }
  
  public override void CheckOff()
  {
    SetDone(true);
  }
}

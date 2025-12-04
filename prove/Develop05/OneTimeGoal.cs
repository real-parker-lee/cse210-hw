public class OneTimeGoal : BaseGoal
{
  private bool _isDone;
  
  public OneTimeGoal(string n, int pts, bool d)
  {
    SetName(n);
    SetPoints(pts);
    SetDone(d);
  }
  
  public OneTimeGoal(string n, int pts)
  {
    SetName(n);
    SetPoints(pts);
  }
  
  public bool IsDone()
  {
    return _isDone;
  }
  
  public void SetDone(bool d)
  {
    _isDone = d;
  }
  
  public override int CheckOff()
  {
    if (IsDone())
    {
      return 0;
    }
    else
    {
      SetDone(true);
      return GetPoints();
    }
  }
  
  public override string Serialize()
  {
    return $"ONETIME|{GetName()}|{GetPoints()}|{IsDone()}";
  }
  
  public override string Show()
  {
    string check = (IsDone()) ? "x" : " ";
    return $"[{check}] {GetName()} ({GetPoints()} pts)";
  }
}

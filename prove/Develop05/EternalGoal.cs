public class EternalGoal : BaseGoal
{
  public int _timesCompleted = 0;
  
  public EternalGoal(string n, int pts, int times)
  {
    SetName(n);
    SetPoints(pts);
    SetTimesCompleted(times);
  }
  
  public EternalGoal(string n, int pts)
  {
    SetName(n);
    SetPoints(pts);
    SetTimesCompleted(0);
  }
  
  public void SetTimesCompleted(int t)
  {
    _timesCompleted = t;
  }
  
  public int GetTimesCompleted()
  {
    return _timesCompleted;
  }
  
  public override int CheckOff()
  {
    SetTimesCompleted(GetTimesCompleted() + 1);
    return GetPoints();
  }

  public override string Serialize()
  {
      return $"ETERNAL|{GetName()}|{GetPoints()}|{GetTimesCompleted()}";
  }
  
  public override string Show()
  {
    return $"[ {GetTimesCompleted()}/{GetTimesCompleted() + 1} ] {GetName()} ({GetPoints()} pts)";
  }
}

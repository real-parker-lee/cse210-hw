public class ChecklistGoal : BaseGoal
{
  private int _minTimes;
  private int _currentTimes = 0;
  private int _pointsPerCompletion;
  private bool _isDone = false;
  
  public ChecklistGoal(string n, int p, int ppc, int minTimes, int doneTimes, bool done)
  {
    SetCurrentTimes(doneTimes);
    SetPoints(p);
    SetName(n);
    SetMinTimes(minTimes);
    SetPointsPerCompletion(ppc);
    SetDone(done);
  }
  
  public ChecklistGoal(string n, int p, int ppc, int minTimes, bool done)
  {
    SetPoints(p);
    SetName(n);
    SetMinTimes(minTimes);
    SetPointsPerCompletion(ppc);
    SetDone(done);
  }
  
  public ChecklistGoal(string n, int p, int ppc, int minTimes)
  {
    SetPoints(p);
    SetName(n);
    SetMinTimes(minTimes);
    SetPointsPerCompletion(ppc);
  }
  
  public void SetDone(bool d)
  {
    _isDone = d;
  }
  
  public bool IsDone()
  {
    return _isDone;
  }
  
  public int GetPointsPerCompletion()
  {
    return _pointsPerCompletion;
  }
  
  public void SetPointsPerCompletion(int ppc)
  {
    _pointsPerCompletion = ppc;
  }
  
  public int GetMinTimes()
  {
    return _minTimes;
  }
  
  public void SetMinTimes(int m)
  {
    _minTimes = m;
  }
  
  public int GetCurrentTimes()
  {
    return _currentTimes;
  }
  
  public void SetCurrentTimes(int t)
  {
    _currentTimes = t;
  }
  
  public override int CheckOff()
  {
    // increment currentTimes.
    _currentTimes++;
    
    int bonus = (GetCurrentTimes() == GetMinTimes()) ? GetPoints() : 0;
    
    // mark done if above threshold.
    SetDone(GetCurrentTimes() >= GetMinTimes());
    
    return GetPointsPerCompletion() + bonus;
  }
  
  public override string Serialize()
  {
    return $"CHECK|{GetName()}|{GetPoints()}|{IsDone()}|{GetCurrentTimes()}|{GetMinTimes()}|{GetPointsPerCompletion()}";
  }

  public override string Show()
  {
    return $"[ {GetCurrentTimes()}/{GetMinTimes()} ] {GetName()} ({GetPointsPerCompletion()} pts | {GetPoints()} bonus)";
  }
}

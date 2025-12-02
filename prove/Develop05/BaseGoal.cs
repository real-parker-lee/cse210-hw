public abstract class BaseGoal
{
  private string _name;
  private int _points;
  
  public string GetName()
  {
    return _name;
  }
  
  public void SetName(string n)
  {
    _name = n;
  }
  
  public int GetPoints()
  {
    return _points;
  }
  
  public void SetPoints(int p)
  {
    _points = p;
  }
  
  // returns number of points earned.
  public abstract int CheckOff();
  
  public abstract string Serialize();
  
  public abstract string Show();
}

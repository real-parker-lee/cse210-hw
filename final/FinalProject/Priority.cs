public class Priority
{
  private int _val;
  
  
  public Priority(int val)
  {
    _val = val;
  }
  
  public static Priority FromNumber(int val)
  {
    return new Priority(val);
  }
  
  public int AsInt()
  {
    return _val;
  }
  
  public string AsString()
  {
    string[] names = {"N/A", "URGENT", "High", "Medium", "Low"};
    try
    {
      return names[_val];
    }
    catch (ArgumentOutOfRangeException)
    {
      return $"{_val}";
    }
  }
}

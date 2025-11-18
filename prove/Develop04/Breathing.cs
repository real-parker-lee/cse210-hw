public class Breathing : Activity
{
  private int _inTime;
  private int _outTime;
  
  public Breathing(int it, int ot)
  {
    if (it <= 0)
    {
      Console.WriteLine($"Invalid breathe-in time: {it}");
    }
    
    if (ot <= 0)
    {
      Console.WriteLine($"Invalid breathe-out-time: {ot}");
    }
    
    if (it > 0 && ot > 0)
    {
      _inTime = it;
      _outTime = ot;
    }
    SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
  }
  
  
}

public class Breathing : Activity
{
  private int _inTime; // IN SECONDS
  private int _outTime;
  
  public Breathing(int it, int ot)
  {
    if (it <= 0)
    {
      Console.WriteLine($"Invalid breathe-in time: {it}");
      _inTime = 5;
    }
    
    if (ot <= 0)
    {
      Console.WriteLine($"Invalid breathe-out-time: {ot}");
      _outTime = 5;
    }
    
    if (it > 0 && ot > 0)
    {
      _inTime = it;
      _outTime = ot;
    }
    SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
  }
  
  public int GetInTime()
  {
    return _inTime;
  }
  
  public int GetOutTime()
  {
    return _outTime;
  }
  
  // I know we didn't discuss polymorphism yet, but this is the only way I
  // could find to get subclasses to override the Run() method, which allowed
  // me to avoid checking what type of activity is being called in the menu.
  // Wouldn't want to re-use code :)
  public override void Run()
  {
    Console.WriteLine($"{GetStartMessage()}\n");
    Console.WriteLine($"{GetDescription()}\n");
    SetDuration(PromptDuration());
    // calculate the number of times to repeat breathing excersize
    int period = GetInTime() + GetOutTime();
    int cycles = GetDuration() / period;
    
    Console.Write("Starting Breathing excersize in  ");
    SetCountDownPos();
    DisplayCountDown(3);
    Console.WriteLine("");
    
    // repeat the breathing loop that many times.
    for (int i = 0; i < cycles; i++)
    {
      Console.Write("Breathe in... ");
      SetCountDownPos();
      DisplayCountDown(GetInTime());
      Console.SetCursorPosition(0, Console.CursorTop); // move to beginning of line 
      Console.Write("Breathe out... ");
      SetCountDownPos();
      DisplayCountDown(GetOutTime());
      Console.Write("  "); // get rid of digit that won't get overwritten due to string length.
      Console.SetCursorPosition(0, Console.CursorTop);
      
    }
    Console.WriteLine("");
    // End excersize
    Console.WriteLine($"You did Mindful Breathing for {GetDuration()} seconds.");
    Console.WriteLine(GetEndMessage());
  }
}

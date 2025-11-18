public class Activity
{
  private string _startMessage = "Let's Begin...";
  private string _endMessage = "You did well.";
  private string _durationPrompt = "How many seconds would you like to spend on this activity? > ";
  private string _description; // set by subclasses.
  // timer related things
  private int[] _timerPos = new int[2]; // LEFTMOST DIGIT
  private int _duration; // set upon prompting. units in seconds
  // throbber related things
  private string[] _throbberAnim = {"/", "|", "\\", "-"};
  private int[] _throbberPos = new int[2];
  
  public Activity()
  {
    _description = "Default Description. If you see this, you used the default constructor for a generic activity.\nFix That.";
  }
  
  public Activity(string d)
  {
    _description = d;
  }
  
  public string GetStartMessage()
  {
    return _startMessage;
  }
  
  public string GetEndMessage()
  {
    return _endMessage;
  }
  
  public string GetDurationPrompt()
  {
    return _durationPrompt;
  }
  
  public string GetDescription()
  {
    return _description;
  }
  
  public void SetDescription(string desc)
  {
    _description = desc;
  }
  
  public int PromptDuration()
  {
    Console.Write(GetDurationPrompt());
    return int.Parse(Console.ReadLine());
  }
  
  public void SetDuration(int d)
  {
    _duration = d;
  }
  
  public int GetDuration()
  {
    return _duration;
  }
  
  public void SetThrobberPos()
  {
    _throbberPos[0] = Console.CursorLeft;
    _throbberPos[1] = Console.CursorTop;
  }
  
  public void DisplayThrobber(int durationMs, int stepMs)
  {
    int stepCount = durationMs / stepMs;
    for (int i = 0; i < stepCount; i++)
    {
      Thread.Sleep(stepMs);
      Console.SetCursorPosition(_throbberPos[0], _throbberPos[1]);
      Console.Write(_throbberAnim[i % 4]);
    }
    
    // hide the throbber.
    Console.SetCursorPosition(_throbberPos[0], _throbberPos[1]);
    Console.Write(" ");
  }
  
  public void SetTimerPos()
  {
    _timerPos[0] = Console.CursorLeft;
    _timerPos[1] = Console.CursorTop;
  }
  
  public int[] GetTimerPos()
  {
    return _timerPos;
  }
  
  public void DisplayTimer()
  {
    // save current cursor position
    int cPosLeft = Console.CursorLeft;
    int cPosTop = Console.CursorTop;
    
    // hacky way of getting digits in duration
    int totalDigits = $"{GetDuration()}".Length;
    int currentDigits = 0;
    
    // engage timer loop.
    for (int i = 0; i <= GetDuration(); i++)
    {
      Console.SetCursorPosition(GetTimerPos()[0], GetTimerPos()[1]);
      currentDigits = $"{GetDuration() - i}".Length;
      Console.Write($"{GetDuration() - i}");
      for (int j = 1; j < totalDigits - currentDigits; j++)
      {
        Console.Write(" ");
      }
      Console.SetCursorPosition(cPosLeft, cPosTop);
      Thread.Sleep(1000);
    }
  }
  
  public void Run()
  {
    Console.WriteLine("You're not meant to run a generic activity.");
    SetThrobberPos();
    DisplayThrobber(3000, 250);
    Console.Write("Timer: ");
    SetTimerPos();
    Console.Write(" <-- thats' counting down!");
    DisplayTimer();
    
  }
}

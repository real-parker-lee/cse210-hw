public class Activity
{
  private string _startMessage = "Let's Begin...";
  private string _endMessage = "You did well.";
  private string _durationPrompt = "How many seconds would you like to spend on this activity?\n> ";
  private string _description; // set by subclasses.
  // countDown related things
  private int[] _countDownPos = new int[2]; // LEFTMOST DIGIT
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
    Console.CursorVisible = false;
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
    Console.CursorVisible = true;
  }
  
  public void SetCountDownPos()
  {
    _countDownPos[0] = Console.CursorLeft;
    _countDownPos[1] = Console.CursorTop;
  }
  
  public int[] GetCountDownPos()
  {
    return _countDownPos;
  }
  
  public void DisplayCountDown(int seconds)
  {
    Console.CursorVisible = false;
    // save current cursor position
    int cPosLeft = Console.CursorLeft;
    int cPosTop = Console.CursorTop;
    
    // init vars used to calculate padding
    int totalDigits = $"{seconds}".Length;
    int currentDigits = 0;
    
    // loop the countDown
    for (int i = 0 ; i <= seconds; i++)
    {
      Console.SetCursorPosition(GetCountDownPos()[0], GetCountDownPos()[1]);
      currentDigits = $"{seconds - i}".Length;
      Console.Write($"{seconds - i}");
      
      // add padding to the right for multi-digit durations.
      for (int j = 1; j < totalDigits - currentDigits; j++)
      {
        Console.Write(" ");
      }
      Console.SetCursorPosition(cPosLeft, cPosTop);
      Thread.Sleep(1000);
    }
    Console.CursorVisible = true;
  }
  
  public virtual void Run()
  {
    Console.WriteLine($"{GetEndMessage()}  ");
    SetThrobberPos();
    DisplayThrobber(3000, 250);
    
  }
}

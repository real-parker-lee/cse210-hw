public class Listing : Activity
{
  private List<string> _prompts = new List<string>();
  private int _responseCount = 0;
  
  public Listing(List<string> prompts)
  : base()
  {
    _prompts = prompts;
    SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. List answers until time runs out.");
  }
  
  public Listing()
  : base()
  {
    _prompts = new List<string>();
    SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. List answers until time runs out.");
  }
  
  public void AddPrompt(string prompt)
  {
    _prompts.Add(prompt);
  }
  
  public List<string> GetPrompts()
  {
    return _prompts;
  }
  
  public string GetRandomPrompt()
  {
    Random rand = new Random();
    return GetPrompts()[rand.Next(0, GetPrompts().Count)];
  }
  
  public int GetResponseCount()
  {
    return _responseCount;
  }
  
  public void SetResponseCount(int newVal)
  {
    _responseCount = newVal;
  }
  
  public void GetResponse()
  {
    Console.Write("> ");
    string response = Console.ReadLine();
    if (response != "")
    {
      SetResponseCount(GetResponseCount() + 1);
    }
  }
  
  public override void Run()
  {
    Console.WriteLine($"{GetStartMessage()}\n");
    Console.WriteLine($"{GetDescription()}\n");
    SetDuration(PromptDuration());
    // print the prompt
    Console.Write($"{GetRandomPrompt()}\nStarting in ");
    SetCountDownPos();
    DisplayCountDown(5);
    Console.WriteLine("\n");
    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(GetDuration());
    do
    {
      GetResponse();
    } while (DateTime.Compare(DateTime.Now, endTime) < 0); // check if current time is earlier than end time.
    Console.Write($"You listed {GetResponseCount()} things. ");
    SetThrobberPos();
    DisplayThrobber(3000, 250);
    Console.WriteLine("");
    Console.WriteLine($"{GetEndMessage()}");
  }
}

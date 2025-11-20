public class Reflection : Activity
{
  private List<string> _prompts = new List<string>();
  private List<string> _questions = new List<string>();
  private int _secondsPerQuestion = 5;
  
  public Reflection()
  : base()
  {
    SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
  }
  
  public void AddPrompt(string prompt)
  {
    _prompts.Add(prompt);
  }
  
  public void AddQuestion(string question)
  {
    _questions.Add(question);
  }
  
  public List<string> GetPrompts()
  {
    return _prompts;
  }
  
  public List<string> GetQuestions()
  {
    return _questions;
  }
  
  public string GetRandomPrompt()
  {
    Random rand = new Random();
    return GetPrompts()[rand.Next(0, GetPrompts().Count)];
  }
  
  public string GetRandomQuestion()
  {
    Random rand = new Random();
    return GetQuestions()[rand.Next(0,GetQuestions().Count)];
  }
  
  public override void Run()
  {
    // display common welcome.
    Console.WriteLine($"{GetStartMessage()}\n");
    Console.WriteLine($"{GetDescription()}\n");
    SetDuration(PromptDuration());
    Console.Write($"{GetRandomPrompt()} ");
    SetCountDownPos();
    DisplayCountDown(3);
    Console.WriteLine("\n");
    // begin questions 
    for (int i = 0; i < GetDuration() / _secondsPerQuestion; i++)
    {
      Console.Write($"{GetRandomQuestion()} ");
      SetThrobberPos();
      DisplayThrobber(_secondsPerQuestion * 1000, 250);
      Console.WriteLine("\n");
    }
    
    Console.WriteLine(GetEndMessage());
  }
}

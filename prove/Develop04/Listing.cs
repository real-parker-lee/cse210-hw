public class Listing : Activity
{
  private List<string> _prompts = new List<string>();
  private int _responseCount = 0;
  
  public Listing(List<string> prompts)
  {
    _prompts = prompts;
  }
  
  public void AddPrompt(string prompt)
  {
    _prompts.Add(prompt);
  }
  
  public List<string> GetPrompts()
  {
    return _prompts;
  }
  
  public int GetResponseCount()
  {
    return _responseCount;
  }
  
  public void SetResponseCount(int newVal)
  {
    _responseCount = newVal;
  }
  
  public override void Run()
  {
    
  }
}

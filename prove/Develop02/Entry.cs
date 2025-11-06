public class Entry
{
  protected string _content;
  protected string _date;
  protected string _prompt;
  
  public void Display()
  {
    Console.WriteLine($"{_date} | {_prompt}...");
    Console.WriteLine(_content);
    Console.WriteLine("-----------------\n");
  }
  
  public void Make(string content, string date, string prompt)
  {
    _prompt = prompt;
    _date = date;
    _content = content;
  }
  
}

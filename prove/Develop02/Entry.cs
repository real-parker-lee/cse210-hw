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
  
  // serialize is responsible for formatting the file representation of an entry.
  public string Serialize()
  {
    // TODO: escape pipe characters in _content
    return $"{_date}|{_prompt}|{_content}";
  }
  
  public void Make(string content, string date, string prompt)
  {
    _prompt = prompt;
    _date = date;
    _content = content;
  }
  
}

class Menu
{
  private string _header;
  private string _prompt;
  private List<MenuItem> _items = new List<MenuItem>();
  
  public Menu(string header, string prompt)
  {
    _header = header;
    _prompt = prompt;
  }
  
  public void AddItem(MenuItem i)
  {
    _items.Add(i);
  }
  
  public List<MenuItem> GetMenuItems()
  {
    return _items;
  }
  
  public string GetHeader()
  {
    return _header;
  }
  
  public string GetPrompt()
  {
    return _prompt;
  }
  
  public int GetSelection()
  {
    Console.Write(GetPrompt());
    int res = int.Parse(Console.ReadLine());
    return res - 1; // correct for displayed menu using 1 as first item
  }
  
  public string StringifyItems()
  {
    string result = "";
    for (int i = 0 ; i < GetMenuItems().Count; i++)
    {
      result = result + $"{i+1}) {GetMenuItems()[i].GetOptName()}\n";
    }
    return result;
  }
  
  public Activity Show()
  {
    Console.WriteLine(GetHeader());
    Console.WriteLine(StringifyItems());
    int ans;
    bool isValid = false;
    do
    {
      ans = GetSelection();
      if (0 < ans && ans < GetMenuItems().Count())
      {
        isValid = true;
      }
      
      if (!isValid)
      {
        Console.WriteLine("Invalid Selection. Try again.");
      }
    } while (!isValid);
    return GetMenuItems()[ans].GetActivity();
  }
}

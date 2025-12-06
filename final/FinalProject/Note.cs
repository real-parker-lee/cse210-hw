public class Note
{
  private string _data = ""; // encoded in base64.
  
  public string GetEncodedData()
  {
    return _data;
  }
  
  public void SetData(string plain)
  {
    _data = Encode(plain);
  }
  
  public string GetDecodedData()
  {
    return Decode(GetEncodedData());
  }
  
  public string Encode(string plain)
  {
    byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plain);
    return System.Convert.ToBase64String(plainBytes);
  }
  
  public string Decode(string data)
  {
    byte[] encodedBytes = System.Convert.FromBase64String(data);
    return System.Text.Encoding.UTF8.GetString(encodedBytes);
  }
  
  public Note()
  {
    _data = "";
  }
  
  public Note(string b64Data)
  {
    _data = b64Data;
  }
  
  public List<string> ArrayToList(string[] array)
  {
    List<string> list = new List<string>();
    for (int i = 0; i < array.Count(); i++)
    {
      list.Add(array[i]);
    }
    return list;
  }
  
  // Invoke an editor which can be exited using 
  public void Edit(string title)
  {
    Console.Clear();
    Console.WriteLine($"{title}");
    
    string defaultMessage = "Edit Me!";
    Console.Write(defaultMessage);
    
    string input = defaultMessage;
    while (true)
    {
      ConsoleKeyInfo thisKey = Console.ReadKey(true);
      // intercept enter
      if (thisKey.Key == ConsoleKey.Enter)
      {
        Console.WriteLine();
        // don't exit, instead add a newline to input
        input += "\n";
      }
      else if (thisKey.Key == ConsoleKey.Backspace)
      {
        // did we delete too much
        if (Console.CursorLeft == 0)
        {
          continue;
          
        }
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        Console.Write(" ");
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        input = string.Join("", input.Take(input.Length - 1));
      }
      // type-able character
      else if (!char.IsControl(thisKey.KeyChar))
      {
        input += thisKey.KeyChar.ToString();
        Console.Write(thisKey.KeyChar);
      }
      else if (thisKey.Key == ConsoleKey.Escape)
      {
        break;
      }
    }
    SetData(input);
  }
}

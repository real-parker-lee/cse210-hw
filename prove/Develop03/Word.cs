class Word
{
  private string _text;
  private bool _isHidden = false;
  
  public Word()
  {
    _text = "";
  }
  
  public Word(string text)
  {
    _text = text;
  }
  
  public void Hide()
  {
    _isHidden = true;
  }
  
  public bool IsHidden()
  {
    return _isHidden;
  }
  
  public string GetString()
  {
    string result = "";
    foreach (char l in _text)
    {
      if (IsHidden() && !(l == '.' || l == ',' || l == ':' || l == ';' || l == '(' || l == ')' || l == '!' || l == '?'))
      {
        result = result + "_";
      }
      else
      {
        result = result + l;
      }
    }
    return result; // why is my LSP being weird? ITS HIGHLIGHTING THE COMMENTS?!?!
  }
  
  public void DisplayString()
  {
    Console.WriteLine(GetString());
  }
  
  public static List<Word> MakeSentence(string text)
  {
    List<Word> sentence = new List<Word>();
    
    string[] words = text.Split(" ");
    foreach (string w in words)
    {
      sentence.Add(new Word(w));
    }
    
    return sentence;
  }
}

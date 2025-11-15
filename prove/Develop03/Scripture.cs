class Scripture
{
  private List<Word> _words = new List<Word>();
  private Reference _ref;
  private int _hideDelta = 3;
  
  public Scripture(Reference r, string content) // pass in full string which gets split by spaces into the word list.
  {
    _words = Word.MakeSentence(content);
    _ref = r;
  }
  
  public Scripture(string bk, int ch, int sv, int ev, string content)
  {
    _words = Word.MakeSentence(content);
    _ref = new Reference(bk, ch, sv, ev);
  }
  
  public Reference GetReference()
  {
    return _ref;
  }
  
  public List<Word> GetWords()
  {
    return _words;
  }
  
  public void PrintReference()
  {
    Console.WriteLine(GetReference().GetString());
  }
  
  public void PrintPrompt()
  {
    PrintReference();
    foreach (Word w in GetWords())
    {
      Console.Write($"{w.GetString()} ");
    }
    Console.WriteLine("\n");
  }
  
  public int CountShown()
  {
    int count = 0;
    foreach (Word w in GetWords())
    {
      if (!w.IsHidden())
      {
        ++count;
      }
    }
    return count;
  }
  
  public void HideRandomWord()
  {
    int counter = Math.Min(_hideDelta, CountShown());
    int idx;
    while (counter >= 1)
    {
      // pick random element from list
      Random rand = new Random();
      idx = rand.Next(0,GetWords().Count);
      // check if it's hidden.
      if (GetWords()[idx].IsHidden())
      {
        // if yes, continue loop.
        continue;
      }
      else
      {
        // if no, hide it and decrement counter.
        GetWords()[idx].Hide();
        counter--;
      }
    }
    //Console.WriteLine($"words shown: {CountShown()}");
  }
  
  public int GetHideDelta()
  {
    return _hideDelta;
  }
}

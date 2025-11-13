class Reference
{
  private string _book;
  private int _chapter;
  private int _startVerse;
  private int _endVerse;
  
  public Reference(string bk, int ch, int sv, int ev)
  {
    SetBook(bk);
    SetChapter(ch);
    SetStartVerse(sv);
    SetEndVerse(ev);
  }
  
  public string GetBook()
  {
    return _book;
  }
  
  public void SetBook(string bk)
  {
    _book = bk;
  }
  
  public int GetChapter()
  {
    return _chapter;
  }
  
  public void SetChapter(int ch)
  {
    _chapter = ch;
  }
  
  public int GetStartVerse()
  {
    return _startVerse;
  }
  
  public void SetStartVerse(int sv)
  {
    _startVerse = sv;
  }
  
  public int GetEndVerse()
  {
    return _endVerse;
  }
  
  public void SetEndVerse(int ev)
  {
    _endVerse = ev;
  }
  
  public string GetString()
  {
    if (GetStartVerse() == GetEndVerse())
    {
      return $"{GetBook()} {GetChapter()}:{GetStartVerse()}";
    }
    else
    {
      return $"{GetBook()} {GetChapter()}:{GetStartVerse()}-{GetEndVerse()}";
    }
  }
}

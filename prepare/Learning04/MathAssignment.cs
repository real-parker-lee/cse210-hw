class MathAssignment : Assignment
{
  private string _textbookSection;
  private string _problems;
  
  public MathAssignment(string tbs, string probs, string s, string t)
  : base(s, t)
  {
    _textbookSection = tbs;
    _problems = probs;
  }
  
  public string GetTextBookSection()
  {
    return _textbookSection;
  }
  
  public string GetProblems()
  {
    return _problems;
  }
  
  public string GetHomeworkList()
  {
    return $"SECTION: {GetTextBookSection()}\nPROBLEMS: {GetProblems()}\n";
  }
}

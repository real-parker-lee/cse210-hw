class WritingAssignment : Assignment
{
  private string _title;
  
  public WritingAssignment(string title, string s, string t)
  : base(s,t)
  {
    _title = title;
  }
  
  public string GetTitle()
  {
    return _title;
  }
  
  public string GetWritingInformation()
  {
    return $"{GetTitle()} by {GetStudent()}";
  }
}

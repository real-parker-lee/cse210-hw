class Assignment
{
  private string _student;
  private string _topic;
  
  public Assignment(string s, string t)
  {
    _student = s;
    _topic = t;
  }
  
  public string GetStudent()
  {
    return _student;
  }
  
  public string GetTopic()
  {
    return _topic;
  }
  
  public string GetSummary()
  {
    return $"NAME:    {GetStudent()}\nTOPIC:   {GetTopic()}";
  }
}

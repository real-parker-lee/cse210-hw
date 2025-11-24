class Doctor : Person
{
  private string _tools;
  
  public Doctor(string tools, string fn, string ln, int a, int w) : base(fn,ln,a,w)
  {
    _tools = tools;
  }

  public override string PersonInformation()
  {
    return $"{base.PersonInformation()} Tools: {_tools}";
    //return base.PersonInformation();
  }
  
  public string DoctorInformation()
  {
    return $"{PersonInformation()} Tools: {_tools}";
  }
}

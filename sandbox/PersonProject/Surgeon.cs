class Surgeon : Doctor
{
  private string _title;
  
  public Surgeon(string title, string tools, string fn, string ln, int a, int w)
  : base(tools, fn, ln, a, w)
  {
    _title = title;
  }
  
  public string SurgeonInformation()
  {
    return $"{_title} {DoctorInformation()}";
  }
}

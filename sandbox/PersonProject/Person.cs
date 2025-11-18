class Person
{
  private string _firstName;
  private string _lastName;
  //protected int _age; // Use this if you want subclasses to be able to access this field.
  private int _age;
  private int _weight;
  
  public Person(string fn, string ln, int a, int w)
  {
    _firstName = fn;
    _lastName = ln;
    SetWeight(w);
    SetAge(a);
  }
  
  public string PersonInformation()
  {
    return $"{_firstName} {_lastName}: {_age} years old, {_weight} pounds.";
  }
  
  public void SetAge(int a)
  {
    if (a > 125)
    {
      _age = 0;
    }
    else if (a < 0)
    {
      _age = 0;
    }
    else
    {
      _age = a;
    }
  }
  
  public void SetWeight(int w)
  {
    if (w > 600 || w < 0)
    {
      _weight = 150;
    }
    else
    {
      _weight = w;
    }
  }
}

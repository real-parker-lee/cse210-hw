class Police : Person
{
  private string _weapons;
  
  public Police(string weapons, string fn, string ln, int a, int w)
  : base(fn, ln, a, w)
  {
    // _age = a; // WARNING: bypasses parent class setter method.
    _weapons = weapons;
  }
  
  public string GetPoliceInformation()
  {
    return $"Officer {base.PersonInformation()}, Weapons: {_weapons}";
  }
}

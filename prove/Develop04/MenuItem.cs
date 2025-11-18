class MenuItem
{
  private string _menuOpt;
  private Activity _activity;
  
  public MenuItem(string opt, Activity act)
  {
    _menuOpt = opt;
    _activity = act;
  }
  
  public string GetOptName()
  {
    return _menuOpt;
  }
  
  public Activity GetActivity()
  {
    return _activity;
  }
}

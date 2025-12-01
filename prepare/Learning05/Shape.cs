class Shape
{
  private string _color;
  
  public string GetColor()
  {
    return _color;
  }
  
  public Shape(string col)
  {
    SetColor(col);
  }
  
  public void SetColor(string newCol)
  {
    _color = newCol;
  }
  
  public virtual double GetArea()
  {
    return 0.0;
  }
}

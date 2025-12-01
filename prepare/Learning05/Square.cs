class Square : Shape
{
  private double _side;
  
  public Square(string c, double l)
  :base(c)
  {
    SetSide(l);
  }
  
  public double GetSide()
  {
    return _side;
  }
  
  public void SetSide(double l)
  {
    _side = l;
  }
  
  public override double GetArea()
  {
    return GetSide() * GetSide();
  }
}

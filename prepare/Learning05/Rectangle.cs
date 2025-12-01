class Rectangle : Shape
{
  private double _length;
  private double _width;
  
  public Rectangle(string c, double l, double w)
  :base(c)
  {
    SetLength(l);
    SetWidth(w);
  }
  
  public void SetWidth(double w)
  {
    _width = w;
  }
  
  public void SetLength(double l)
  {
    _length = l;
  }
  
  public double GetWidth()
  {
    return _width;
  }
  
  public double GetLength()
  {
    return _length;
  }
  
  public override double GetArea()
  {
    return GetLength() * GetWidth();
  }
}

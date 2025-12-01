class Circle : Shape
{
  private double _radius;
  
  public Circle(string color, double r)
  :base(color)
  {
    SetRadius(r);
  }
  
  public void SetRadius(double r)
  {
    _radius = r;
  }
  
  public double GetRadius()
  {
    return _radius;
  }
  
  public override double GetArea()
  {
    return Math.PI * GetRadius() * GetRadius();
  }
}

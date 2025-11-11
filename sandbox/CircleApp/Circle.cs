class Circle
{
  private double _radius;
  
  // Constructors
  public Circle()
  {
    _radius = 0.0;
  }
  
  public Circle(double radius)
  {
    // Don't reuse code!
    SetRadius(radius);
  }
  
  public void SetRadius(double radius)
  {
    if (radius < 0)
    {
      Console.WriteLine($"Invalid Radius: {radius}");
      _radius = 0;
    }
    else
    {
      _radius = radius;
    }
  }
  
  public double GetCircleArea()
  {
    return 3.1415926535897932 * _radius * _radius;
  }
}

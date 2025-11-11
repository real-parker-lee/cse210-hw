// See https://aka.ms/new-console-template for more information
class Program
{
  public static void Main()
  {
    Console.WriteLine("Hello CircleApp World!");
    //Circle circ = new Circle();
    
    //circ._radius = 10;
    Circle circ = new Circle(10.0);
    Console.WriteLine(circ.GetCircleArea());
  }
}

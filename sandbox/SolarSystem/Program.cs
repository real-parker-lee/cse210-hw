class Program
{
  static void Main()
  {
    // Console.WriteLine("Bonjour toute le monde");
    Planet mercury = new Planet();
    mercury._name = "Mercury";
    mercury._diameter = 1234.343;
    
    Planet venus = new Planet();
    venus._name = "Venus";
    venus._diameter = 2345.67;
    
    mercury.DisplayPlanetInformation();
    venus.DisplayPlanetInformation();
  }
}

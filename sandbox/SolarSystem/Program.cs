class Program
{
  static void Main()
  {
    
    SolarSystem solarSystem = new SolarSystem();
    // Console.WriteLine("Bonjour toute le monde");
    Planet mercury = new Planet();
    mercury._name = "Mercury";
    mercury._diameter = 4880.00;
    
    Planet venus = new Planet();
    venus._name = "Venus";
    venus._diameter = 12104.00;
    
    Planet earth = new Planet();
    earth._name = "Earth";
    earth._diameter = 12742.00;
    
    Planet mars = new Planet();
    mars._name = "Mars";
    mars._diameter = 6779.00;
    
    Planet jupiter = new Planet();
    jupiter._name = "Jupiter";
    jupiter._diameter = 139822.00;
    
    Planet saturn = new Planet();
    saturn._name = "Saturn";
    saturn._diameter = 116464.00;
    
    Planet uranus = new Planet();
    uranus._name = "Uranus";
    uranus._diameter = 50724.00;
    
    Planet neptune = new Planet();
    neptune._name = "Neptune";
    neptune._diameter = 49244.00;
    
    Planet pluto = new Planet();
    pluto._name = "Pluto";
    pluto._diameter = 2376.00;
    
    solarSystem._solarSystem.Add(mercury);
    solarSystem._solarSystem.Add(venus);
    solarSystem._solarSystem.Add(earth);
    solarSystem._solarSystem.Add(mars);
    solarSystem._solarSystem.Add(jupiter);
    solarSystem._solarSystem.Add(saturn);
    solarSystem._solarSystem.Add(uranus);
    solarSystem._solarSystem.Add(neptune);
    solarSystem._solarSystem.Add(pluto);
    
    // mercury.DisplayPlanetInformation();
    // venus.DisplayPlanetInformation();
  }
}

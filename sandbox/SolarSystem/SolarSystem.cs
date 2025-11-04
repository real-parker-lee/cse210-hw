class SolarSystem {
  public List<Planet> _solarSystem = new List<Planet>();
  
  public void DisplaySolarSystem()
  {
    foreach(Planet p in _solarSystem)
    {
      p.DisplayPlanetInformation();
    }
  }
}

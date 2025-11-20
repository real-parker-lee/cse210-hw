public class Quit : Activity
{

  public override void Run()
  {
    Console.Write("Exiting Application. ");
    SetThrobberPos();
    DisplayThrobber(2000, 250);
    ToggleDoQuit();
  }
}

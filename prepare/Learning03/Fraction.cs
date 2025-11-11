class Fraction
{
  private int _numer;
  private int _denom;
  
  public Fraction()
  {
    _numer = 1;
    _denom = 1;
  }
  
  public Fraction(int num)
  {
    _numer = num;
    _denom = 1;
  }
  
  public Fraction(int num, int den)
  {
    _numer = num;
    _denom = den;
  }
}

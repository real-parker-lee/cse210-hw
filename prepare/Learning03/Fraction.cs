class Fraction
{
  private int _numer;
  private int _denom;
  
  public Fraction()
  {
    SetNumerator(1);
    SetDenominator(1);
  }
  
  public Fraction(int num)
  {
    SetNumerator(num);
    SetDenominator(1);
  }
  
  public Fraction(int num, int den)
  {
    SetNumerator(num);
    SetDenominator(den);
  }
  
  // getters and setters
  public void SetNumerator(int newVal)
  {
    _numer = newVal;
  }
  
  public void SetDenominator(int newVal)
  {
    _denom = newVal;
  }
  
  public int GetNumerator()
  {
    return _numer;
  }
  
  public int GetDenominator()
  {
    return _denom;
  }
  
  public string GetFractionString()
  {
    if (_denom == 1)
    {
      return $"{GetNumerator()}";
    }
    else
    {
      return $"{GetNumerator()}/{GetDenominator()}";
    }
  }
  
  public double GetDecimalValue()
  {
    return GetNumerator() / GetDenominator();
  }
}

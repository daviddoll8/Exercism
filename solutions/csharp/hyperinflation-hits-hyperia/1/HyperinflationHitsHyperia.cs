public static class CentralBank
{
  public static string DisplayDenomination(long @base, long multiplier)
  {
    long denomination;
    try
    {
      checked
      {
        denomination = @base * multiplier;
      }
      return denomination.ToString();
    }
    catch (OverflowException)
    {
      return "*** Too Big ***";
    }
  }

  public static string DisplayGDP(float @base, float multiplier)
  {
    float gdp = @base * multiplier;

    if (float.IsPositiveInfinity(gdp))
    {
      return "*** Too Big ***";
    }

    return gdp.ToString();
  }

  public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
  {
    try
    {
      var salary = salaryBase * multiplier;
      return salary.ToString();
    }
    catch (OverflowException)
    {
      return "*** Much Too Big ***";
    }
  }
}

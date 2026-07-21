static class SavingsAccount
{
  public static float InterestRate(decimal balance)
  {
    if (balance < 0)
    {
      return 3.213f;
    }
    else if (balance < 1000)
    {
      return 0.5f;
    }
    else if (balance >= 1000 && balance < 5000)
    {
      return 1.621f;
    }
    else
    {
      return 2.475f;
    }
  }

  public static decimal Interest(decimal balance) =>
    (decimal)(InterestRate(balance) / 100) * balance;

  public static decimal AnnualBalanceUpdate(decimal balance) =>
    balance + Interest(balance);

  public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
  {
    var balancePerYear = balance;
    var numYears = 0;
    while (balancePerYear < targetBalance)
    {
      balancePerYear = AnnualBalanceUpdate(balancePerYear);
      numYears++;
    }
    return numYears;
  }
}

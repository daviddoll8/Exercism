public struct CurrencyAmount : IEquatable<CurrencyAmount>
{
  private decimal amount;
  private string currency;

  public CurrencyAmount(decimal amount, string currency)
  {
    this.amount = amount;
    this.currency = currency;
  }


  // TODO: implement equality operators

  public static bool operator ==(CurrencyAmount left, CurrencyAmount right) =>
    left.Equals(right);

  public static bool operator !=(CurrencyAmount left, CurrencyAmount right) =>
    !(left == right);

  public bool Equals(CurrencyAmount other)
  {
    if (other.currency != this.currency)
    {
      throw new ArgumentException();
    }
    return this.amount == other.amount;
  }

  public override int GetHashCode() =>
    HashCode.Combine(this.amount, this.currency);

  public static bool IsCompatible(string left, string right) => left == right;

  // TODO: implement comparison operators
  public static bool operator <(CurrencyAmount left, CurrencyAmount right) =>
    IsCompatible(left.currency, right.currency) ? left.amount < right.amount : throw new ArgumentException();

  public static bool operator >(CurrencyAmount left, CurrencyAmount right) =>
    IsCompatible(left.currency, right.currency) ? left.amount > right.amount : throw new ArgumentException();

  // TODO: implement arithmetic operators
  public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right) =>
    IsCompatible(left.currency, right.currency) ? new CurrencyAmount(left.amount + right.amount, left.currency) : throw new ArgumentException();

  public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right) =>
    IsCompatible(left.currency, right.currency) ? new CurrencyAmount(left.amount - right.amount, left.currency) : throw new ArgumentException();

  public static CurrencyAmount operator *(CurrencyAmount left, decimal right) =>
    new CurrencyAmount(left.amount * right, left.currency);

  public static CurrencyAmount operator /(CurrencyAmount left, decimal right) =>
    new CurrencyAmount(left.amount / right, left.currency);

  // TODO: implement type conversion operators
  public static explicit operator double(CurrencyAmount ca) => (double)ca.amount;

  public static implicit operator decimal(CurrencyAmount ca) => ca.amount;

}

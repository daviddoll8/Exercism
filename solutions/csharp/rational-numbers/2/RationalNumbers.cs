public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) =>
        Math.Pow(realNumber, (double)r.Numerator / r.Denominator);
}

public struct RationalNumber
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var numerator = (r1.Numerator * r2.Denominator) + (r2.Numerator * r1.Denominator);
        var denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        var numerator = (r1.Numerator * r2.Denominator) - (r2.Numerator * r1.Denominator);
        var denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator).Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Denominator, r2.Numerator * r1.Denominator).Reduce();

    public RationalNumber Abs() =>
        new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator)).Reduce();

    public RationalNumber Reduce()
    {
        if (Numerator == 0)
            return new RationalNumber(0, 1);

        var commonDenominator = GetCommonDenominator(Math.Max(Numerator, Denominator), Math.Min(Numerator, Denominator));

        return (Denominator / commonDenominator) switch
        {
            < 0 => new RationalNumber((Numerator / commonDenominator) * -1, (Denominator / commonDenominator) * -1),
            > 0 => new RationalNumber(Numerator / commonDenominator, Denominator / commonDenominator),
            _ => new RationalNumber(0, 1)
        };
    }

    private static int GetCommonDenominator(int numerator, int denominator) =>
        (numerator % denominator == 0) ? denominator : GetCommonDenominator(denominator, numerator % denominator);

    public RationalNumber Exprational(int power) =>
        (power > 0) switch
        {
            true => new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power)).Reduce(),
            false => new RationalNumber((int)Math.Pow(Denominator, power * -1), (int)Math.Pow(Numerator, power * -1)).Reduce()
        };

    public double Expreal(int baseNumber) =>
        baseNumber.Expreal(this);
}

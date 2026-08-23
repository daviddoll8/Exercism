public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        throw new NotImplementedException("You need to implement this extension method.");
    }
}

public struct RationalNumber
{
    private int Numerator { get; set; }
    private int Denominator { get; set; }

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
        new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));

    public RationalNumber Reduce()
    {
        var commonDenominator = GetCommonDenominator(Numerator, Denominator);
        return new RationalNumber(Numerator / commonDenominator, Denominator / commonDenominator);
    }

    private static int GetCommonDenominator(int numerator, int denominator)
    {
        var largest = Math.Abs(numerator) >= Math.Abs(denominator) ? numerator : denominator;
        var smallest = largest == numerator ? denominator : numerator;
        var remainder = largest % smallest;
        var lastRemainder = remainder;

        if (remainder == 0)
            return smallest;

        while (remainder != 0)
        {
            largest = smallest;
            smallest = lastRemainder;
            remainder = largest % smallest;
            if (remainder != 0)
                lastRemainder = remainder;
        }
        return lastRemainder;
    }

    public RationalNumber Exprational(int power)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}

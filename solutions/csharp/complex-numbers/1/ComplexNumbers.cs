public struct ComplexNumber(double real, double imaginary)
{
    public double RealNum { get; set; } = real;
    public double ImaginaryNum { get; set; } = imaginary;

    public readonly double Real() => RealNum;

    public readonly double Imaginary() => ImaginaryNum;

    public readonly ComplexNumber Mul(ComplexNumber other) =>
        new((RealNum * other.RealNum) - (ImaginaryNum * other.ImaginaryNum),
            (ImaginaryNum * other.RealNum) + (RealNum * other.ImaginaryNum));

    public readonly ComplexNumber Add(ComplexNumber other) => new(RealNum + other.RealNum, ImaginaryNum + other.ImaginaryNum);

    public readonly ComplexNumber Sub(ComplexNumber other) => new(RealNum - other.RealNum, ImaginaryNum - other.ImaginaryNum);

    public readonly ComplexNumber Div(ComplexNumber other)
    {
        var real = ((RealNum * other.RealNum) + (ImaginaryNum * other.ImaginaryNum))
            / (Math.Pow(other.RealNum, 2) + Math.Pow(other.ImaginaryNum, 2));
        var imaginary = ((ImaginaryNum * other.RealNum) - (RealNum * other.ImaginaryNum))
            / (Math.Pow(other.RealNum, 2) + Math.Pow(other.ImaginaryNum, 2));
        return new ComplexNumber(real, imaginary);
    }

    public readonly ComplexNumber Add(double num) => new(RealNum + num, ImaginaryNum);

    public readonly ComplexNumber Mul(double num) => new(RealNum * num, ImaginaryNum * num);

    public readonly ComplexNumber Div(double num) => new(RealNum / num, ImaginaryNum / num);

    public readonly double Abs() => Math.Sqrt((RealNum * RealNum) + (ImaginaryNum * ImaginaryNum));

    public readonly ComplexNumber Conjugate() => new(RealNum, ImaginaryNum * -1);

    public readonly ComplexNumber Exp() =>
        new(Math.Pow(Math.E, RealNum) * Math.Cos(ImaginaryNum), Math.Pow(Math.E, RealNum) * Math.Sin(ImaginaryNum));
}

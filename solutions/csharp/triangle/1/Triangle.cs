public static class Triangle
{
    public static bool LengthValidation(double[] sides) =>
        sides switch
        {
            _ when sides[0] + sides[1] <= sides[2] => false,
            _ when sides[0] + sides[2] <= sides[1] => false,
            _ when sides[1] + sides[2] <= sides[0] => false,
            _ => true
        };

    public static bool SidesValidation(double[] sides) =>
        sides.All(side => side > 0);

    public static bool IsTriangle(double[] sides) =>
        LengthValidation(sides) &&
        SidesValidation(sides);

    private static int NumSidesEqual(double[] sides) =>
        sides[0] == sides[1] && sides[0] == sides[2] ? 3 :
        sides[0] == sides[1] && sides[1] == sides[2] ? 3 :
        sides[0] == sides[1] || sides[0] == sides[2] ? 2 :
        sides[0] == sides[1] || sides[1] == sides[2] ? 2 : 1;

    public static bool IsScalene(double side1, double side2, double side3) =>
        IsTriangle([side1, side2, side3]) &&
        side1 != side2 && side1 != side3 && side2 != side3;

    public static bool IsIsosceles(double side1, double side2, double side3) =>
        IsTriangle([side1, side2, side3]) &&
        NumSidesEqual([side1, side2, side3]) >= 2;

    public static bool IsEquilateral(double side1, double side2, double side3) =>
        IsTriangle([side1, side2, side3]) &&
        side1 == side2 && side1 == side3 && side2 == side3;
}

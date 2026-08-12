public static class Triangle
{
    public static bool IsTriangle(double[] sides) =>
        sides[0] + sides[1] > sides[2] &&
        sides[0] + sides[2] > sides[1] &&
        sides[1] + sides[2] > sides[0];

    public static bool IsScalene(double side1, double side2, double side3) =>
        IsTriangle([side1, side2, side3]) &&
        side1 != side2 && side1 != side3 && side2 != side3;

    public static bool IsIsosceles(double side1, double side2, double side3) =>
        IsTriangle([side1, side2, side3]) &&
        (side1 == side2 || side2 == side3 || side1 == side3);

    public static bool IsEquilateral(double side1, double side2, double side3) =>
        IsTriangle([side1, side2, side3]) &&
        side1 == side2 && side1 == side3 && side2 == side3;
}

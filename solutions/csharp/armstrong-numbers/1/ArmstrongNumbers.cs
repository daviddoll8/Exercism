public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number) =>
        number.ToString().Sum(c => Math.Pow(c - '0', number.ToString().Length)) == number;
}

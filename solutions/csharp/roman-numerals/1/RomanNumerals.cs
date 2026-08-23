using System.Text;

public static class RomanNumeralExtension
{
    private static readonly (int Value, string Numeral)[] ValueToNumeralMap =
    [
        (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
        (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
        (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
    ];
    public static string ToRoman(this int value)
    {
        var result = new StringBuilder();

        foreach (var (num, roman) in ValueToNumeralMap)
        {
            while (value >= num)
            {
                result.Append(roman);
                value -= num;
            }
        }
        return result.ToString();
    }
}

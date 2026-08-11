public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var number = phoneNumber.Where(char.IsDigit).ToArray();
        return number.Length switch
        {
            10 =>
                number[0] - '0' >= 2 && number[3] - '0' >= 2 ?
                new string(number) :
                throw new ArgumentException(),
            11 =>
                number[0] - '0' == 1 && number[1] - '0' >= 2 && number[4] - '0' >= 2 ?
                new string(number[1..]) :
                throw new ArgumentException(),
            _ => throw new ArgumentException()
        };
    }
}

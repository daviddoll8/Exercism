using System.Text.RegularExpressions;

public static class Wordy
{
    public static int Answer(string question)
    {
        Match resultMatch = Regex.Match(question, @"^What is (?<result>-?\d+)\?$");
        if (resultMatch.Success) return int.Parse(resultMatch.Groups["result"].Value);

        Match questionMatch = Regex
            .Match(question, @"^What is (?<firstNumber>-?\d+)(?<operation>[^-\d]+)(?<secondNumber>-?\d+)(?<rest>.+)?");
        if (!questionMatch.Success) throw new ArgumentException();

        int firstNumber = int.Parse(questionMatch.Groups["firstNumber"].Value);
        int secondNumber = int.Parse(questionMatch.Groups["secondNumber"].Value);
        string rest = questionMatch.Groups["rest"].Value;

        int result = questionMatch.Groups["operation"].Value.Trim() switch
        {
            "plus" => firstNumber + secondNumber,
            "minus" => firstNumber - secondNumber,
            "multiplied by" => firstNumber * secondNumber,
            "divided by" => firstNumber / secondNumber,
            _ => throw new ArgumentException()
        };

        return Answer($"What is {result}{rest}");
    }
}

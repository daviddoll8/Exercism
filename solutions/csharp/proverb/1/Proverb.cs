public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0)
            return [];

        var result = new string[subjects.Length];
        var first = subjects[0];

        for (int i = 0; i < subjects.Length; i++)
        {
            if (i == subjects.Length - 1)
            {
                result[i] = $"And all for the want of a {first}.";
                continue;
            }

            result[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";
        }
        return result;
    }
}

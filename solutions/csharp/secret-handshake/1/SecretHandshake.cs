public static class SecretHandshake
{
    private static readonly Dictionary<int, string> CommandSet = new()
    {
        [0] = "wink",
        [1] = "double blink",
        [2] = "close your eyes",
        [3] = "jump"
    };

    public static string[] Commands(int commandValue)
    {
        var actions = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            if (i == 4 && (commandValue & (1 << i)) != 0)
                actions.Reverse();

            if (i != 4 && (commandValue & (1 << i)) != 0)
                actions.Add(CommandSet[i]);
        }

        return [.. actions];
    }
}

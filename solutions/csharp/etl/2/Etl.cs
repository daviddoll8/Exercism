public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) =>
        old.SelectMany(keyValuePair => keyValuePair.Value.Select(value => (value.ToLower(), keyValuePair.Key))).ToDictionary();
}

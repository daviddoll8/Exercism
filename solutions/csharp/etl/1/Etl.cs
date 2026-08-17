public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var transormed = new Dictionary<string, int>();
        foreach (var keyValuePair in old)
        {
            foreach (var value in keyValuePair.Value)
            {
                transormed.Add(value.ToLower(), keyValuePair.Key);
            }
        }
        return transormed;
    }
}

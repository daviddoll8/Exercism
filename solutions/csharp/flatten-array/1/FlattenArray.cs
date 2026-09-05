using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var result = new List<object>();
        foreach (var item in input)
        {
            if (item is null)
            {
                continue;
            }
            if (item is IEnumerable sub)
            {
                foreach (var subItem in Flatten(sub))
                    result.Add(subItem);
            }
            else
            {
                result.Add(item);
            }
        }
        return result.ToArray();
    }
}

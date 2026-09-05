using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var item in input)
        {
            if (item is IEnumerable sub)
                foreach (var subItem in Flatten(sub)) yield return subItem;
            else if (item != null)
                yield return item;
        }
    }
}

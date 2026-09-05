using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) => Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
        Value = values.First();
        foreach (var value in values.Skip(1))
            Add(value);
    }

    public int Value { get; }
    public BinarySearchTree? Left { get; private set; }
    public BinarySearchTree? Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
            Left = Left?.Add(value) ?? new BinarySearchTree(value);
        else
            Right = Right?.Add(value) ?? new BinarySearchTree(value);

        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var left in Left?.AsEnumerable() ?? [])
            yield return left;

        yield return Value;

        foreach (var right in Right?.AsEnumerable() ?? [])
            yield return right;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

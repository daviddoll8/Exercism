using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    public int Value { get; }
    public BinarySearchTree? Left { get; private set; }
    public BinarySearchTree? Right { get; private set; }
    public BinarySearchTree(int value) => Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
        if (!values.Any())
            throw new ArgumentException();

        Value = values.ToArray()[0];
        foreach (var value in values.Skip(1))
            Add(value);
    }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
        {
            if (Left is null)
                Left = new BinarySearchTree(value);
            else
                Left.Add(value);
        }
        else
        {
            if (Right is null)
                Right = new BinarySearchTree(value);
            else
                Right.Add(value);
        }

        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left is not null)
        {
            foreach (var value in Left)
                yield return value;
        }
        yield return Value;
        if (Right is not null)
        {
            foreach (var value in Right)
                yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

using System.Collections;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private Node<T>? _head;

    public int Count { get; private set; }
    public SimpleLinkedList() => Count = 0;

    public SimpleLinkedList(T value)
    {
        _head = new Node<T>(value);
        Count++;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        _head = new Node<T>(values.First());
        Count++;

        var current = _head;
        foreach (var value in values.Skip(1))
        {
            current.Next = new Node<T>(value);
            current = current.Next;
            Count++;
        }
    }

    public void Push(T value)
    {
        Count++;
        var newNode = new Node<T>(value);

        if (_head is null)
        {
            _head = newNode;
            return;
        }

        var current = _head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public T Pop()
    {
        Count--;

        if (_head.Next is null)
        {
            var only = _head.Data;
            _head = null;
            return only;
        }

        var current = _head;
        while (current.Next.Next is not null)
            current = current.Next;

        var last = current.Next.Data;
        current.Next = null;
        return last;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var stack = new Stack<Node<T>>();
        for (var node = _head; node is not null; node = node.Next)
            stack.Push(node);

        while (stack.Count > 0)
            yield return stack.Pop().Data;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Node<T>(T data)
{
    public T Data { get; set; } = data;
    public Node<T>? Next { get; set; }
}

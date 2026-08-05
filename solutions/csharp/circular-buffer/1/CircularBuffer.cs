public class CircularBuffer<T>
{
    private readonly T[] buffer;
    private int writeIndex;
    private int readIndex;
    private int count;

    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];
        writeIndex = 0;
        readIndex = 0;
        count = 0;
    }

    public T Read()
    {
        if (count == 0)
            throw new InvalidOperationException("Buffer is empty");

        var value = buffer[readIndex];
        readIndex = (readIndex + 1) % buffer.Length;
        count--;
        return value;
    }

    public void Write(T value)
    {
        if (count == buffer.Length)
            throw new InvalidOperationException();

        buffer[writeIndex] = value;
        writeIndex = (writeIndex + 1) % buffer.Length;
        count++;
    }

    public void Overwrite(T value)
    {
        if (count < buffer.Length)
        {
            Write(value);
            return;
        }

        buffer[writeIndex] = value;
        writeIndex = (writeIndex + 1) % buffer.Length;
        readIndex = writeIndex;
    }

    public void Clear()
    {
        count = 0;
        readIndex = 0;
        writeIndex = 0;
    }
}

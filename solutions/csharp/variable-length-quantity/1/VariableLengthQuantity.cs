public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var encoding = new List<uint>();
        foreach (var number in numbers)
        {
            var value = number;
            var result = new List<uint>();
            do
            {
                var chunk = value & 0x7F;
                value >>= 7;
                if (result.Count != 0)
                    chunk |= 0x80;
                result.Add(chunk);
            } while (value > 0);
            result.Reverse();
            encoding.AddRange(result);
        }
        return [.. encoding];
    }

    public static uint[] Decode(uint[] bytes)
    {
        var decoded = new List<uint>();
        uint value = 0;
        var inProgress = false;

        foreach (var b in bytes)
        {
            value = (value << 7) | (b & 0x7F);
            if (b >= 0x80)
            {
                inProgress = true;
            }
            else
            {
                decoded.Add(value);
                value = 0;
                inProgress = false;
            }
        }
        return inProgress ? throw new InvalidOperationException() : [.. decoded];
    }
}

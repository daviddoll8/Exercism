public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int low = 0;
        int high = input.Length - 1;

        while (low <= high)
        {
            int middle = low + (high - low) / 2;

            if (input[middle] < value)
            {
                low = middle + 1;
            }
            else if (input[middle] > value)
            {
                high = middle - 1;
            }
            else
            {
                return middle;
            }
        }

        return -1;
    }
}

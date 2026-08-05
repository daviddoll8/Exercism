using System;
using System.Collections.Generic;

public class Robot
{
    // Central registry to track all active IDs
    private static readonly HashSet<string> UsedIds = new HashSet<string>();
    private static readonly object LockObject = new object();
    private static readonly Random RandomInstance = new Random();

    private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Digits = "0123456789";

    // Instance property for the robot's unique identity
    public string Name { get; private set; }

    public Robot()
    {
        Name = GenerateUniqueId();
    }

    public void Reset()
    {
        Name = GenerateUniqueId();
    }

    private static string GenerateUniqueId()
    {
        lock (LockObject)
        {
            while (true)
            {
                string candidateId = CreateIdString();

                // Add returns true if the ID is unique and successfully added
                if (UsedIds.Add(candidateId))
                {
                    return candidateId;
                }

                // If Add returns false, the loop runs again to try a new ID
            }
        }
    }

    private static string CreateIdString()
    {
        char[] result = new char[5];

        // 2 Uppercase Letters
        result[0] = Letters[RandomInstance.Next(Letters.Length)];
        result[1] = Letters[RandomInstance.Next(Letters.Length)];

        // 3 Digits
        result[2] = Digits[RandomInstance.Next(Digits.Length)];
        result[3] = Digits[RandomInstance.Next(Digits.Length)];
        result[4] = Digits[RandomInstance.Next(Digits.Length)];

        return new string(result);
    }
}

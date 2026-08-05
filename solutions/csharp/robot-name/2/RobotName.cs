using System;
using System.Collections.Generic;

public class Robot
{
    private static readonly HashSet<string> UsedIds = new HashSet<string>();
    private static readonly object LockObject = new object();
    private static readonly Random RandomInstance = new Random();

    private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Digits = "0123456789";

    public string Name { get; private set; }

    public Robot() => Reset();

    public void Reset() => Name = GenerateUniqueId();

    private static string GenerateUniqueId()
    {
        lock (LockObject)
        {
            while (true)
            {
                string candidateId = CreateIdString();

                if (UsedIds.Add(candidateId))
                {
                    return candidateId;
                }

            }
        }
    }

    private static string CreateIdString()
    {
        char[] result = new char[5];

        result[0] = Letters[RandomInstance.Next(Letters.Length)];
        result[1] = Letters[RandomInstance.Next(Letters.Length)];

        result[2] = Digits[RandomInstance.Next(Digits.Length)];
        result[3] = Digits[RandomInstance.Next(Digits.Length)];
        result[4] = Digits[RandomInstance.Next(Digits.Length)];

        return new string(result);
    }
}

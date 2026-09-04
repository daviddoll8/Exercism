public static class RnaTranscription
{
    public static string ToRna(string strand) => new([.. strand.Select(ConvertDna)]);

    private static char ConvertDna(char dna) => dna switch
    {
        'G' => 'C',
        'C' => 'G',
        'T' => 'A',
        'A' => 'U',
        _ => throw new ArgumentException()
    };
}

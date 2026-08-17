public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> AminoAcids = new Dictionary<string, string>
    {
        ["AUG"] = "Methionine",
        ["UUU"] = "Phenylalanine",
        ["UUC"] = "Phenylalanine",
        ["UUA"] = "Leucine",
        ["UUG"] = "Leucine",
        ["UCU"] = "Serine",
        ["UCC"] = "Serine",
        ["UCA"] = "Serine",
        ["UCG"] = "Serine",
        ["UAU"] = "Tyrosine",
        ["UAC"] = "Tyrosine",
        ["UGU"] = "Cysteine",
        ["UGC"] = "Cysteine",
        ["UGG"] = "Tryptophan",
        ["UAA"] = "STOP",
        ["UAG"] = "STOP",
        ["UGA"] = "STOP",
    };
    public static string[] Proteins(string strand)
    {
        var translation = new List<string>();
        for (int i = 0; i < strand.Length / 3; i++)
        {
            var codon = new string([.. strand.Skip(i * 3).Take(3)]);
            if (AminoAcids.TryGetValue(codon, out string aminoAcid))
            {
                if (aminoAcid == "STOP")
                    break;
                translation.Add(aminoAcid);
            }
        }
        return [.. translation];
    }
}

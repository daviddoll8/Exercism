public static class PlayAnalyzer
{
  public static string AnalyzeOnField(int shirtNum)
  {
    return shirtNum switch
    {
      1 => "goalie",
      2 => "left back",
      >= 3 and <= 4 => "center back",
      5 => "right back",
      >= 6 and <= 8 => "midfielder",
      9 => "left wing",
      10 => "striker",
      11 => "right wing",
      _ => "UNKNOWN"
    };
  }

  public static string AnalyzeOffField(object report)
  {
    return report switch
    {
      string => report.ToString(),
      int => $"There are {report} supporters at the match.",
      Foul i => i.GetDescription(),
      Injury i => $"Oh no! {i.GetDescription()} Medics are on the field.",
      Incident i => i.GetDescription(),
      Manager m when m.Club is null => m.Name,
      Manager m => $"{m.Name} ({m.Club})",
      _ => ""
    };

  }
}


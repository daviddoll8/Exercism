public struct Coord
{
  public Coord(ushort x, ushort y)
  {
    X = x;
    Y = y;
  }
  public ushort X { get; }
  public ushort Y { get; }
}
public struct Plot
{
  public Coord C1 { get; }

  public Coord C2 { get; }
  public Coord C3 { get; }
  public Coord C4 { get; }
  public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
  {
    C1 = c1;
    C2 = c2;
    C3 = c3;
    C4 = c4;
  }
}

public class ClaimsHandler
{
  private HashSet<Plot> plotRepository = new HashSet<Plot>();
  private Plot lastStakedPlot;
  public void StakeClaim(Plot plot)
  {
    if (plotRepository.Add(plot))
    {
      lastStakedPlot = plot;
    }
  }

  public bool IsClaimStaked(Plot plot)
  {
    return plotRepository.Contains(plot);
  }

  public bool IsLastClaim(Plot plot)
  {
    return plot.Equals(lastStakedPlot);
  }

  public Plot GetClaimWithLongestSide()
  {
    Dictionary<int, Plot> longestPlot = new Dictionary<int, Plot>();
    var currLongest = 0;
    foreach (var plot in plotRepository)
    {
      var distances = new List<int>
      {
        CalculateDistance(plot.C1, plot.C2),
        CalculateDistance(plot.C2, plot.C3),
        CalculateDistance(plot.C3, plot.C4)
      };
      foreach (var distance in distances)
      {
        if (distance > currLongest)
        {
          currLongest = distance;
          longestPlot.Add(currLongest, plot);
        }
      }
    }
    return longestPlot.GetValueOrDefault(currLongest);
  }

  private int CalculateDistance(Coord a, Coord b)
  {
    var horizontalGap = b.X - a.X;
    var verticalGap = b.Y - a.Y;
    return (int)Math.Sqrt(Math.Pow(horizontalGap, 2) * Math.Pow(verticalGap, 2));
  }
}

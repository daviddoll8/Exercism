public struct Coord
{
  public Coord(ushort x, ushort y)
  {
    X = x;
    Y = y;
  }
  public ushort X { get; }
  public ushort Y { get; }

  public double DistanceBetweenCoords(Coord other) =>
    Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
}
public struct Plot
{
  public Coord C1 { get; }
  public Coord C2 { get; }
  public Coord C3 { get; }
  public Coord C4 { get; }
  public double LongestSide { get; }

  public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
  {
    C1 = c1;
    C2 = c2;
    C3 = c3;
    C4 = c4;
    LongestSide = CalculateLongestSide(c1, c2, c3, c4);
  }

  public double CalculateLongestSide(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
  {
    var sides = new double[4];
    sides[0] = coord1.DistanceBetweenCoords(coord2);
    sides[1] = coord2.DistanceBetweenCoords(coord3);
    sides[2] = coord3.DistanceBetweenCoords(coord3);
    sides[3] = coord4.DistanceBetweenCoords(coord4);
    return sides.Max();
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

  public Plot GetClaimWithLongestSide() =>
    plotRepository.OrderByDescending(plot => plot.LongestSide).First();
}

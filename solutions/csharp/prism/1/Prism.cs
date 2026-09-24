public static class Prism
{
  public readonly record struct LaserInfo(double X, double Y, double Angle);

  public readonly record struct PrismInfo(int Id, double X, double Y, double Angle);

  private const double Epsilon = 1e-2;

  public static int[] FindSequence(LaserInfo laser, PrismInfo[] prisms)
  {
    var startDirection = (Math.Cos(double.DegreesToRadians(laser.Angle)), Math.Sin(double.DegreesToRadians(laser.Angle)));

    var origin = (laser.X, laser.Y);
    var direction = startDirection;
    var angle = laser.Angle;

    var result = new List<int>();

    while (true)
    {
      int? hitId = null;
      PrismInfo? hitInfo = null;
      double bestDistance = double.MaxValue;

      foreach (var prism in prisms)
      {
        var b = (prism.X - origin.X, prism.Y - origin.Y);
        double dot = Dot(direction, b);     // signed distance along the beam
        double cross = Cross(direction, b); // signed perpendicular distance from the beam's line

        if (Math.Abs(cross) < Epsilon && dot > 0 && dot < bestDistance)
        {
          bestDistance = dot;
          hitId = prism.Id;
          hitInfo = prism;
        }
      }

      if (hitId is null)
      {
        break;
      }

      result.Add(hitId.Value);
      origin = (hitInfo.Value.X, hitInfo.Value.Y);
      angle += hitInfo.Value.Angle;
      direction = (Math.Cos(double.DegreesToRadians(angle)), Math.Sin(double.DegreesToRadians(angle)));
    }

    return [.. result];
  }

  private static double Dot((double, double) a, (double, double) b) => (a.Item1 * b.Item1) + (a.Item2 * b.Item2);

  private static double Cross((double, double) a, (double, double) b) => (a.Item1 * b.Item2) - (b.Item1 * a.Item2);
}

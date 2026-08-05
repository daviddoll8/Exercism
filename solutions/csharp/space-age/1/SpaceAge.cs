public class SpaceAge
{
    private int _seconds;
    private const double EarthYearInSeconds = 31557600;

    private readonly Dictionary<string, double> OrbitalPeriodRatio = new()
    {
        ["Mercury"] = 0.2408467,
        ["Venus"] = 0.61519726,
        ["Earth"] = 1.0,
        ["Mars"] = 1.8808158,
        ["Jupiter"] = 11.862615,
        ["Saturn"] = 29.447498,
        ["Uranus"] = 84.016846,
        ["Neptune"] = 164.79132,
    };

    public SpaceAge(int seconds)
    {
        _seconds = seconds;
    }

    private double SecondsToEarthYears() => _seconds / EarthYearInSeconds;

    public double OnEarth() => SecondsToEarthYears();

    public double OnMercury() =>
         SecondsToEarthYears() / OrbitalPeriodRatio["Mercury"];

    public double OnVenus() =>
        SecondsToEarthYears() / OrbitalPeriodRatio["Venus"];

    public double OnMars() =>
        SecondsToEarthYears() / OrbitalPeriodRatio["Mars"];

    public double OnJupiter() =>
        SecondsToEarthYears() / OrbitalPeriodRatio["Jupiter"];

    public double OnSaturn() =>
        SecondsToEarthYears() / OrbitalPeriodRatio["Saturn"];

    public double OnUranus() =>
        SecondsToEarthYears() / OrbitalPeriodRatio["Uranus"];

    public double OnNeptune() =>
        SecondsToEarthYears() / OrbitalPeriodRatio["Neptune"];
}

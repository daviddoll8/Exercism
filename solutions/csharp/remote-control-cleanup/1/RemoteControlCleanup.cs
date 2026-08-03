public class RemoteControlCar
{
  public RemoteControlCar() => Telemetry = new RemoteControlTelemetry(this);

  public string CurrentSponsor { get; private set; } = "";
  private Speed currentSpeed;

  public interface ITelemetry
  {
    void Calibrate();
    bool SelfTest();
    void ShowSponsor(string sponsorName);
    void SetSpeed(decimal amount, string unitsString);
  }

  public ITelemetry Telemetry { get; }

  private class RemoteControlTelemetry : ITelemetry
  {
    private RemoteControlCar? parent;

    public RemoteControlTelemetry(RemoteControlCar parent)
    {
      this.parent = parent;
    }

    public void Calibrate()
    {
      return;
    }

    public bool SelfTest()
    {
      return true;
    }

    public void ShowSponsor(string sponsorName)
    {
      parent?.SetSponsor(sponsorName);
    }

    public void SetSpeed(decimal amount, string unitsString)
    {
      SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
      if (unitsString == "cps")
      {
        speedUnits = SpeedUnits.CentimetersPerSecond;
      }

      parent?.SetSpeed(new Speed(amount, speedUnits));
    }
  }

  public string GetSpeed()
  {
    return currentSpeed.ToString();
  }

  private void SetSponsor(string sponsorName)
  {
    CurrentSponsor = sponsorName;

  }

  private void SetSpeed(Speed speed)
  {
    currentSpeed = speed;
  }


  private enum SpeedUnits
  {
    MetersPerSecond,
    CentimetersPerSecond
  }

  private struct Speed
  {
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
      Amount = amount;
      SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
      string unitsString = "meters per second";
      if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
      {
        unitsString = "centimeters per second";
      }

      return Amount + " " + unitsString;
    }
  }
}


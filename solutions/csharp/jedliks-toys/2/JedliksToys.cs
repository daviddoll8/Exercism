class RemoteControlCar
{
  public int batteryPercent = 100;
  public int metersDriven;

  public static RemoteControlCar Buy() =>
    new RemoteControlCar();

  public string DistanceDisplay() =>
    $"Driven {this.metersDriven} meters";

  public string BatteryDisplay() =>
    this.batteryPercent == 0 ? "Battery empty" : $"Battery at {this.batteryPercent}%";

  public void Drive()
  {
    if (this.batteryPercent != 0)
    {
      this.batteryPercent--;
      this.metersDriven += 20;
    }
  }
}

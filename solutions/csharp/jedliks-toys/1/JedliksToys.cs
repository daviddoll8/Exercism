class RemoteControlCar
{
  public int batteryPercent = 100;
  public int metersDriven;
  public static RemoteControlCar Buy()
  {
    return new RemoteControlCar();
  }

  public string DistanceDisplay()
  {
    return $"Driven {this.metersDriven} meters";
  }
  public string BatteryDisplay()
  {
    return this.batteryPercent == 0 ? "Battery empty" : $"Battery at {this.batteryPercent}%";
  }
  public void Drive()
  {
    if (this.batteryPercent != 0)
    {
      this.batteryPercent--;
      this.metersDriven += 20;
    }
  }
}

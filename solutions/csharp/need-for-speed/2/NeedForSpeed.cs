class RemoteControlCar
{
  // TODO: define the constructor for the 'RemoteControlCar' class
  private int speed;
  private int batteryLife;
  private int batteryDrain;
  private int metersDriven;

  public RemoteControlCar(int speed, int batteryDrain)
  {
    this.speed = speed;
    this.batteryLife = 100;
    this.batteryDrain = batteryDrain;
    this.metersDriven = 0;
  }

  public bool BatteryDrained() =>
    this.batteryLife < this.batteryDrain;

  public int DistanceDriven() => this.metersDriven;

  public bool CanDrive() =>
    this.batteryLife >= this.batteryDrain;

  public void Drive()
  {
    if (this.CanDrive())
    {
      this.metersDriven += this.speed;
      this.batteryLife -= this.batteryDrain;
    }
  }

  public static RemoteControlCar Nitro()
  {
    return new RemoteControlCar(50, 4);
  }
}

class RaceTrack
{
  // TODO: define the constructor for the 'RaceTrack' class
  private int distance;

  public RaceTrack(int distance) => this.distance = distance;

  public bool TryFinishTrack(RemoteControlCar car)
  {
    while (car.DistanceDriven() < this.distance)
    {
      if (!car.CanDrive())
      {
        return false;
      }
      car.Drive();
    }
    return true;
  }
}

// TODO: implement the IRemoteControlCar interface
public interface IRemoteControlCar
{
  int DistanceTravelled { get; }
  void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
  public int DistanceTravelled { get; private set; }
  public int NumberOfVictories { get; set; }

  public int CompareTo(ProductionRemoteControlCar? other) =>
    this.NumberOfVictories == other.NumberOfVictories ? 0 :
    this.NumberOfVictories < other.NumberOfVictories ? -1 : 1;

  public void Drive()
  {
    DistanceTravelled += 10;
  }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
  public int DistanceTravelled { get; private set; }

  public void Drive()
  {
    DistanceTravelled += 20;
  }
}

public static class TestTrack
{
  public static void Race(IRemoteControlCar car)
  {
    throw new NotImplementedException($"Please implement the (static) TestTrack.Race() method");
  }

  public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
      ProductionRemoteControlCar prc2)
  {
    var carList = new List<ProductionRemoteControlCar>();
    carList.Add(prc1);
    carList.Add(prc2);
    carList.Sort();
    return carList;
  }
}

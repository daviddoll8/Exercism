class BirdCount
{
  private int[] birdsPerDay;

  public BirdCount(int[] birdsPerDay)
  {
    this.birdsPerDay = birdsPerDay;
  }

  public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };

  public int Today() =>
    this.birdsPerDay[this.birdsPerDay.Length - 1];

  public void IncrementTodaysCount() =>
    this.birdsPerDay[this.birdsPerDay.Length - 1]++;

  public bool HasDayWithoutBirds()
  {
    foreach (int birdsSeen in this.birdsPerDay)
    {
      if (birdsSeen == 0)
      {
        return true;
      }
    }
    return false;
  }

  public int CountForFirstDays(int numberOfDays)
  {
    var birdCount = 0;
    for (int i = 0; i < numberOfDays; i++)
      birdCount += this.birdsPerDay[i];

    return birdCount;
  }

  public int BusyDays()
  {
    var busyDays = 0;
    foreach (int birdsSeen in this.birdsPerDay)
    {
      if (birdsSeen >= 5)
      {
        busyDays++;
      }
    }
    return busyDays;
  }
}

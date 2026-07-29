class WeighingMachine
{
  // TODO: define the 'Precision' property

  public int Precision { get; }

  // TODO: define the 'Weight' property

  private double weight;
  public double Weight
  {
    get
    {
      return weight;
    }
    set
    {
      if (value < 0)
      {
        throw new ArgumentOutOfRangeException();
      }
      weight = value;
    }
  }

  // TODO: define the 'TareAdjustment' property
  public double TareAdjustment { get; set; } = 5.0;

  // TODO: define the 'DisplayWeight' property
  public string DisplayWeight
  {
    get
    {
      var displayWeight = this.weight - this.TareAdjustment;
      string formatString = $"{{0:F {this.Precision} }}";
      return string.Format(formatString, displayWeight);
    }
  }

}

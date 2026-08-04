public static class PhoneNumber
{
  public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) =>
    phoneNumber.Split('-') switch
    {
      ["212", "555", var local] => (true, true, local),
      ["212", _, var local] => (true, false, local),
      [_, "555", var local] => (false, true, local),
      [_, _, var local] => (false, false, local),
      _ => throw new Exception()
    };

  public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}

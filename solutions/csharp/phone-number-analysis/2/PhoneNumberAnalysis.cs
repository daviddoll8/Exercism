public static class PhoneNumber
{
  public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
  {
    string[] phoneNumberSections = phoneNumber.Split('-');
    return (phoneNumberSections[0] == "212", phoneNumberSections[1] == "555", phoneNumberSections[2]);
  }

  public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}

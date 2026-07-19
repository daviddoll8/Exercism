static class Badge
{
  public static string Print(int? id, string name, string? department)
  {
    if (department == null)
    {
      if (id == null)
      {
        return $"{name} - OWNER";
      }
      else
      {
        return $"[{id}] - {name} - OWNER";
      }
    }
    else if (id == null)
    {
      return $"{name} - {department.ToUpper()}";
    }
    else
    {
      return $"[{id}] - {name} - {department.ToUpper()}";
    }
  }
}

public class Orm
{
  private Database database;

  public Orm(Database database)
  {
    this.database = database;
  }

  public void Write(string data)
  {
    using var db = this.database;
    db.BeginTransaction();
    db.Write(data);
    db.EndTransaction();
  }

  public bool WriteSafely(string data)
  {
    try
    {
      this.database.BeginTransaction();
      this.database.Write(data);
      this.database.EndTransaction();
    }
    catch (Exception)
    {
      this.database.Dispose();
      return false;
    }
    return true;
  }
}

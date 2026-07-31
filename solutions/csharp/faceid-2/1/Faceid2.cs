public class FacialFeatures : IEquatable<FacialFeatures>
{
  public string EyeColor { get; }
  public decimal PhiltrumWidth { get; }

  public FacialFeatures(string eyeColor, decimal philtrumWidth)
  {
    EyeColor = eyeColor;
    PhiltrumWidth = philtrumWidth;
  }

  public bool Equals(FacialFeatures? other) =>
    other != null &&
    this.EyeColor == other.EyeColor &&
    this.PhiltrumWidth == other.PhiltrumWidth;

  public override int GetHashCode() =>
    HashCode.Combine(this.EyeColor, this.PhiltrumWidth);
  // TODO: implement equality and GetHashCode() methods
}

public class Identity : IEquatable<Identity>
{
  public string Email { get; }
  public FacialFeatures FacialFeatures { get; }

  public Identity(string email, FacialFeatures facialFeatures)
  {
    Email = email;
    FacialFeatures = facialFeatures;
  }

  public bool Equals(Identity? other) =>
    other != null &&
    this.Email == other.Email &&
    this.FacialFeatures.Equals(other.FacialFeatures);

  public override int GetHashCode() =>
    HashCode.Combine(this.Email, this.FacialFeatures);
  // TODO: implement equality and GetHashCode() methods
}

public class Authenticator
{
  // private Dictionary<string, FacialFeatures> usersRepository = new Dictionary<string, FacialFeatures>();
  private HashSet<Identity> _registerdUsers = new();

  public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
    faceA.Equals(faceB);

  public bool IsAdmin(Identity identity) =>
    identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));

  public bool Register(Identity identity) =>
    !IsRegistered(identity) &&
    _registerdUsers.Add(identity);

  public bool IsRegistered(Identity identity) =>
    _registerdUsers.Contains(identity);

  public static bool AreSameObject(Identity identityA, Identity identityB) =>
    ReferenceEquals(identityA, identityB);
}

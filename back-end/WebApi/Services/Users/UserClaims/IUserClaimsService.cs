namespace OpenOsp.WebApi.Services {

  public class IUserClaimsService<TUserKey>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible {

    public TUserKey UserId { get; private set; }

  }

}
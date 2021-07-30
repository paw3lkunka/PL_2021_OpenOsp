namespace OpenOsp.WebApi.Services {

  public class UserClaimsService<TUserKey> : IUserClaimsService<TUserKey>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible {

    public UserClaimsService(IHttpContextAccessor accessor) {
      UserId = accessor.HttpContext?.User.Claims
        .SingleOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
    }

    public TUserKey UserId { get; private set; }

  }

}
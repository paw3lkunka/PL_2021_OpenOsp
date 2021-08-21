using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace OpenOsp.Server.Api.Services {

  public class UserClaimsService<TId> : IUserClaimsService<TId>
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {

    public UserClaimsService(IHttpContextAccessor accessor) {
      var id = accessor.HttpContext?.User.Claims
        .SingleOrDefault(c => c.Type.Equals("uid"))?.Value;
      if (id == default(string)) {
        return;
      }
      UserId = (TId)Convert.ChangeType(id, typeof(TId));
    }

    public TId UserId { get; private set; }

  }

}
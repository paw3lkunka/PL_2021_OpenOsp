using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OpenOsp.Server.Api.Services {

  public interface IUserService<T, TId>
    where T : IdentityUser<TId>
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {

    Task Create(T user, string password);

    Task<T> ReadById(TId id);

    Task<T> ReadByEmail(string email);

    Task Delete(T user);

    Task<string> GetEmailConfirmationToken(T user);

    Task ConfirmEmail(T user, string token);

    Task<string> GetAuthenticationToken(T user, string password);

  }

}
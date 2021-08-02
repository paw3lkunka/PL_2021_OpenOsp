using System;
using Microsoft.AspNetCore.Identity;

namespace OpenOsp.Api.Services {

  public interface IUsersService<T, TId>
    where T : IdentityUser<TId>
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {

    void Create(T user, string password);

    T ReadById(TId id);

    T ReadByEmail(string email);

    void Delete(T user);

    string GenerateActivationCode(T user);

    void ActivateAccount(T user, string code);

    string GenerateAuthenticationToken(T user, string password);

  }

}
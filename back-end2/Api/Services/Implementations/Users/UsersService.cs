using System;
using Microsoft.AspNetCore.Identity;
using OpenOsp.Model.Models;

namespace OpenOsp.Api.Services {

  public class UsersService<T, TId>
    : IUsersService<T, TId>
    where T : IdentityUser<TId>
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {

    public UsersService() {
    }

    private readonly UserManager<T> _userManager;

    private readonly SignInManager<T> _signInManager;

    public void Create(T user, string password) {
      throw new NotImplementedException();
    }

    public T ReadById(TId id) {
      throw new NotImplementedException();
    }

    public T ReadByEmail(string email) {
      throw new NotImplementedException();
    }

    public void Delete(T user) {
      throw new NotImplementedException();
    }

    public string GenerateActivationCode(T user) {
      throw new NotImplementedException();
    }

    public void ActivateAccount(T user, string code) {
      throw new NotImplementedException();
    }

    public string GenerateAuthenticationToken(T user, string password) {
      throw new NotImplementedException();
    }

    // private readonly JwtSettings _jwtSettings;

  }

}
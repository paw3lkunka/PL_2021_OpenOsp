using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OpenOsp.Model.Models;
using OpenOsp.Server.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using OpenOsp.Server.Settings;
using OpenOsp.Server.Enums;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.WebUtilities;
using System.Web;

namespace OpenOsp.Server.Api.Services {

  public class UsersService<T, TId>
    : IUsersService<T, TId>
    where T : IdentityUser<TId>
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {

    public UsersService(
      UserManager<T> userManager,
      SignInManager<T> signInManager,
      IOptions<JwtSettings> jwtSettings
    ) {
      _userManager = userManager;
      _signInManager = signInManager;
      _jwtSettings = jwtSettings.Value;
    }

    private readonly UserManager<T> _userManager;

    private readonly SignInManager<T> _signInManager;

    private readonly JwtSettings _jwtSettings;

    public async Task Create(T user, string password) {
      var result = await _userManager.CreateAsync(user, password);
      if (!result.Succeeded) {
        throw new DbTransactionException<T>(
          DbTransactionType.Create, 
          result.Errors
            .Select(e => $"{e.Code}: {e.Description}")
            .ToList()
        );
      }
    }

    public async Task<T> ReadById(TId id) {
      var user = await _userManager.FindByIdAsync(id.ToString());
      if (user == default(T)) {
        throw new NotFoundException<T,TId>(id);
      }
      return user;
    }

    public async Task<T> ReadByEmail(string email) {
      var user = await _userManager.FindByEmailAsync(email);
      if (user == default(T)) {
        throw new NotFoundException<T, string>(email);
      }
      return user;
    }

    public async Task Delete(T user) {
      var result = await _userManager.DeleteAsync(user);
      if (!result.Succeeded) {
        throw new DbTransactionException<T>(DbTransactionType.Delete);
      }
    }

    public async Task<string> GetEmailConfirmationToken(T user) => HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(user));

    public async Task ConfirmEmail(T user, string token) {
      var result = await _userManager.ConfirmEmailAsync(user, HttpUtility.UrlDecode(token));
      if (!result.Succeeded) {
        throw new DbTransactionException<T>();
      }
    }

    public async Task<string> GetAuthenticationToken(T user, string password) {
      var signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
      if (!signInResult.Succeeded) {
        throw new UnauthorizedException();
      }
      var claimsIdentity = new ClaimsIdentity(
        new Claim[] {
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim(JwtRegisteredClaimNames.Sub, user.Email),
          new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
          new Claim("uid", user.Id.ToString()),
        },
        "Token"
      );
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
      var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var token = new JwtSecurityToken(
        _jwtSettings.Issuer,
        _jwtSettings.Audience,
        claimsIdentity.Claims,
        expires: DateTime.UtcNow.AddDays(2),
        signingCredentials: signingCredentials
      );
      return new JwtSecurityTokenHandler().WriteToken(token);
    }

  }

}
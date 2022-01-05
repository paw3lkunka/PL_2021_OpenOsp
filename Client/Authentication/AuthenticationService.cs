using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;

using OpenOsp.Model.Dtos;

namespace OpenOsp.Client.Authentication;

public class AuthenticationService : IAuthenticationService {
  private readonly HttpClient _http;
  
  private readonly AuthenticationStateProvider _authStateProvider;
  
  private readonly ILocalStorageService _localStorage;
  
  public AuthenticationService(HttpClient http, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage) {
    _http = http;
    _authStateProvider = authStateProvider;
    _localStorage = localStorage;
  }

  public async Task<string> Login(UserLoginDto loginDto) {
    var authResult = await _http.PostAsJsonAsync("api/users/login", loginDto);
    var authContent = await authResult.Content.ReadAsStringAsync();
    if (authResult.IsSuccessStatusCode is false) {
      return null;
    }
    await _localStorage.SetItemAsync("authToken", authContent);
    ((AuthStateProvider) _authStateProvider).NotifyUserAuthentication(authContent);
    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authContent);
    return authContent;
  }

  public async Task Logout() {
    await _localStorage.RemoveItemAsync("authToken");
    ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
    _http.DefaultRequestHeaders.Authorization = null;
  }
}
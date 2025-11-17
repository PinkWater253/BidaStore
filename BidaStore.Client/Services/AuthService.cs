// BidaStore.Client/Services/AuthService.cs
using BidaStore.Client.Auth;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BidaStore.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        // DTO để nhận phản hồi từ API
        private class LoginResponse
        {
            [JsonPropertyName("token")]
            public string Token { get; set; }
            [JsonPropertyName("userName")]
            public string UserName { get; set; }
        }

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> Login(string email, string password)
        {
            var loginRequest = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginRequest);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            if (loginResponse == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                return false;
            }

            // Lưu token vào Local Storage
            await _localStorage.SetItemAsync("authToken", loginResponse.Token);
            await _localStorage.SetItemAsync("userName", loginResponse.UserName);

            // Thông báo cho Blazor biết trạng thái xác thực đã thay đổi
            await ((CustomAuthStateProvider)_authStateProvider).NotifyUserAuthentication(loginResponse.Token);

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("userName");

            // Thông báo cho Blazor biết trạng thái đã thay đổi
            await ((CustomAuthStateProvider)_authStateProvider).NotifyUserLogout();
        }
    }
}
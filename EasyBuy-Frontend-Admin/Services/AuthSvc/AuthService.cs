﻿using EasyBuy_Frontend_Admin.Dtos.Auth;
using EasyBuy_Frontend_Admin.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace EasyBuy_Frontend_Admin.Services.AuthSvc
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7084"); 
        }

        public async Task<SignUpDTO> Register(SignUpDTO signUpDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Auth/Register", signUpDTO);

                if (response.IsSuccessStatusCode)
                {
                    var createdUser = await response.Content.ReadFromJsonAsync<SignUpDTO>();
                    return createdUser; 
                }
                else
                {
                    Debug.WriteLine("Đăng ký không thành công. Trạng thái: " + response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while registering: " + ex.Message);
                return null;
            }
        }

        // Phương thức đăng nhập
        public async Task<SignInDTO> Login(SignInDTO signInDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Auth/Login", signInDTO);

                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<SignInDTO>();
                    return user; 
                }
                else
                {
                    Debug.WriteLine("Đăng nhập không thành công. Trạng thái: " + response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while logging in: " + ex.Message);
                return null;
            }
        }
    }
}

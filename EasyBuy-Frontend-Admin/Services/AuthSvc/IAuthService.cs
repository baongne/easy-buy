﻿using EasyBuy_Frontend_Admin.Dtos.Auth;
using EasyBuy_Frontend_Admin.Models;

namespace EasyBuy_Frontend_Admin.Services.AuthSvc
{
    public interface IAuthService
    {
        Task<SignUpDTO> Register(SignUpDTO signUpDTO);
        Task<SignInDTO> Login(SignInDTO signInDTO);
    }
}

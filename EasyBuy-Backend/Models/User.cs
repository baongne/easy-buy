﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyBuy_Backend.Models
{
    public class User : IdentityUser
    {
        [StringLength(200)]
        public string? Address { get; set; }

        public UserStatus Status { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        public virtual ICollection<Cart>? Carts { get; set; }
    }

    public enum UserStatus
    {
        ENABLE = 0,

        DISABLED = 1
    }

    public enum UserRole
    {
        USER = 0,

        ADMIN = 1
    }
}

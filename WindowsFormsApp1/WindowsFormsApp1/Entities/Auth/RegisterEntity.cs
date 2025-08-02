using System;
using System.Collections.Generic;
using WindowsFormsApp1.Entities.Common;

namespace WindowsFormsApp1.Entities.Auth
{
    public class RegisterEntity : BaseEntity
    {
        public DateTime SavedAt { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLogin { get; set; }
        public string Role { get; set; } = "User";
        public string ImagePath { get; set; }
        public bool HasFaceRegistered { get; set; } = false;

        public virtual ICollection<SearchLog> SearchLogs { get; set; }

        public string EmailVerificationCode { get; set; }
        public bool IsEmailVerified { get; set; } = false;
    }
}

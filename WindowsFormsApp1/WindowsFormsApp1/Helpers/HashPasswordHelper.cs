﻿using System.Security.Cryptography;
using System.Text;
using System;

namespace WindowsFormsApp1.Helpers
{
    public class HashPasswordHelper
    {
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

using MongoDB.Driver;
using WasteManagementSystem.Data;
using WasteManagementSystem.Models;

namespace WasteManagementSystem.Services
{
    public class AuthService
    {
        public User Login(string username, string password)
        {
            var user = DatabaseHelper.Users.Find(u => u.Username == username).FirstOrDefault();

            if (user != null)
            {
                string inputHash = HashPassword(password);
                if (user.PasswordHash == inputHash)
                {
                    return user;
                }
            }
            return null;
        }

        public bool Register(User user, string password)
        {
            var existingUser = DatabaseHelper.Users.Find(u => u.Username == user.Username).FirstOrDefault();
            if (existingUser != null) return false;

            user.PasswordHash = HashPassword(password);
            // Role, FullName, Address, PhoneNumber are already in 'user' object
            
            DatabaseHelper.Users.InsertOne(user);
            return true;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

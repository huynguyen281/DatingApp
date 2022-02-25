using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using DatingApp.API.Database.Entities;

namespace DatingApp.API.Database
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (context.Users.Any()) return;


            var userData = System.IO.File.ReadAllText("DataBase/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);
            if (users == null) return;

            using var hmac = new HMACSHA512();
            foreach (var user in users)
            {
                user.Username = user.Username.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123456789"));
                user.PasswordSalt = hmac.Key;
                user.CreatedAt = DateTime.Now;

                context.Add(user);
            }
            context.SaveChanges();

        }
    }
}
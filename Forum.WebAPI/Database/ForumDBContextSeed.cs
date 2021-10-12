using Forum.WebAPI.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Forum.WebAPI.Database
{
    public partial class ForumDBContext
    {
        const int length= 12;
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public async Task<List<Users>> GetUsers()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
            response.EnsureSuccessStatusCode();
            var usersFromServer = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<Users>>(usersFromServer);
            return users;
        }

        public async Task<List<Posts>> GetPosts()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();
            var postsFromServer = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Posts>>(postsFromServer);
            return posts;
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            var usersToDatabase = GetUsers();
            foreach (var item in usersToDatabase.GetAwaiter().GetResult())
            {
                item.Password = CreatePassword(length);
                modelBuilder.Entity<Users>().HasData(
                    new Users
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Username = item.Username,
                        Password = item.Password,
                        Website = item.Website
                    });
            }

            var postsToDatabase = GetPosts();
            foreach(var item in postsToDatabase.GetAwaiter().GetResult())
            {
                modelBuilder.Entity<Posts>().HasData(
                    new Posts
                    {
                        Id = item.Id,
                        UserId = item.UserId,
                        Title = item.Title,
                        Body = item.Body
                    });
            }

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 11,
                    Name = "Admin Admin",
                    Username = "Admin",
                    Password = "Admin123.",
                    Website="admin.ba"
                });
        }
    }
}

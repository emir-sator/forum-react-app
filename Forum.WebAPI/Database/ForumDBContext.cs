using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebAPI.Database
{
    public partial class ForumDBContext:DbContext
    {
        public ForumDBContext(DbContextOptions<ForumDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>(u => { u.HasIndex(u => u.Username).IsUnique(); });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

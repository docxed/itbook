using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itbook.Models;
using Microsoft.EntityFrameworkCore;

namespace itbook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; }
        public DbSet<LikeBook> LikeBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique(); // Unique username
            modelBuilder.Entity<LikeBook>().HasIndex(lb => new { lb.UserId, lb.BookId }).IsUnique(); // Unique user and book (prevent duplicate book likes)
        }
    }
}

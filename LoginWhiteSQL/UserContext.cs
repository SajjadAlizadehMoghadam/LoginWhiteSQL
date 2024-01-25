using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWhiteSQL
{
    internal class UserContext : DbContext
    {
        public UserContext(string name) : base(name) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(key => key.UserId);
            modelBuilder.Entity<User>().Property(t => t.UserFullname).IsRequired().HasMaxLength(30).HasColumnName("Username");
            modelBuilder.Entity<User>().Property(t => t.UserPassword).IsRequired().HasMaxLength(10).HasColumnName("Password");
            base.OnModelCreating(modelBuilder);
        }

    }


    internal class User
    {
        public int UserId { get; set; }
        public string UserFullname { get; set; }
        public string UserPassword { get; set; }
    }
}

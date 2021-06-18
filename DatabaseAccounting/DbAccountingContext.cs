using System;
using DatabaseAccounting.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccounting
{
    public class DbAccountingContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        public DbAccountingContext() { }
        public DbAccountingContext(DbContextOptions<DbAccountingContext> options)
            :base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }

}

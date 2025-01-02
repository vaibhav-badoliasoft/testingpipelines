using DataModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Model>(b => { b.ToTable("Data"); });
        }
    }
}

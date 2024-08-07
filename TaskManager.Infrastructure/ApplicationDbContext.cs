using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Domain.Entities;

namespace TaskManager.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet <Item> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().ToTable("Tasks");


            // Seed data
            modelBuilder.Entity<Item>().HasData(
                new Item() {Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1", Status = true},
                new Item() {Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2", Status = true},
                new Item() {Id = Guid.NewGuid(), Title = "Task 3", Description = "Description 3", Status = false}
            );     
        }   
    }
}

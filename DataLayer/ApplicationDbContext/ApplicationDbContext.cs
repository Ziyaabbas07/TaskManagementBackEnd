using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApplicationDbContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.AssignedUser)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.AssignedTo);

            // Other model configurations...
        }

    }

}

using BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace BackEnd.DAL
{
    public class BackEndContext : DbContext
    {

        public BackEndContext(DbContextOptions<BackEndContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<FieldOwner> FieldOwners { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<FarmStaff> FarmStaffs { get; set; }
        public DbSet<Boundary> Boundaries { get; set; }
        public DbSet<PhotoData> Photos { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<Permission>().ToTable("Permission");
            modelBuilder.Entity<Worker>().ToTable("Worker");
            modelBuilder.Entity<FieldOwner>().ToTable("FieldOwner");
            modelBuilder.Entity<Farm>().ToTable("Farm");
            modelBuilder.Entity<FarmStaff>().ToTable("FarmStaff")
                .HasKey( k => new { k.FarmID, k.WorkerID });
            modelBuilder.Entity<Field>().ToTable("Field");
            modelBuilder.Entity<Coordinate>().ToTable("Coordinate");
            modelBuilder.Entity<PhotoData>().ToTable("PhotoData");
            modelBuilder.Entity<Boundary>().ToTable("Boundary")
                .HasKey(k => new { k.CoordinateID, k.FieldID});
        }

    }
}

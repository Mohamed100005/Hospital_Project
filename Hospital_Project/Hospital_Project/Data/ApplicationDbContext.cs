﻿using Hospital_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Project.Data {
    public class ApplicationDbContext : DbContext {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-LDMHIRF\\SQLEXPRESS;Initial Catalog=HospetalDb;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>().Property(e => e.Name).HasMaxLength(70).IsUnicode(false);
            modelBuilder.Entity<Doctor>().Property(e => e.Specialization).HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. John Smith", Specialization = "Cardiology", Img = "doctor1.jpg" },
                new Doctor { Id = 2, Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Img = "doctor2.jpg" },
                new Doctor { Id = 3, Name = "Dr. Emily Davis", Specialization = "Dermatology", Img = "doctor4.jpg" },
                new Doctor { Id = 4, Name = "Dr. Michael Lee", Specialization = "Orthopedics", Img = "doctor3.jpg" },
                new Doctor { Id = 5, Name = "Dr. William Clark", Specialization = "Neurology", Img = "doctor5.jpg" }
             );
            modelBuilder.Entity<Appointments>().Property(e => e.PatientName).HasMaxLength(50).IsUnicode(false);
        }
    }
}
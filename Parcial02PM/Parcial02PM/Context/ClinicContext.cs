using Microsoft.EntityFrameworkCore;
using Parcial02PM.Entities.Questions;
using Parcial02PM.Entities.Reservations;
using Parcial02PM.Entities.Specialities;
using Parcial02PM.Entities.Users;

namespace Parcial02PM.Context
{
    public class ClinicContext : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet <Reservation> Reservations { get; set; }
        public DbSet <Question> Questions { get; set; }
        public DbSet <Speciality> Specialities { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("Server=LAPTOP-P2DP1NT1;Database=UCAdb;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.CardId)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Reservation>()
                .Property(r => r.IdR)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Question>()
                .Property(q =>q.Quest)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Speciality>()
                .Property(s => s.S)
                .ValueGeneratedOnAdd();
            
        }
    }
    
}
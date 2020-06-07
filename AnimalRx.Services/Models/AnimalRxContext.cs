using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalRx.Services.Models
{

    public class AnimalRxContext : DbContext
    {
        public AnimalRxContext(DbContextOptions<AnimalRxContext> options) : base (options)
        { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var reminderTypeToStringConverter = new EnumToStringConverter<ReminderType>();
            modelBuilder
                .Entity<Reminder>()
                .Property(p => p.Type)
                .HasConversion(reminderTypeToStringConverter);

            var vaccineConverter = new EnumToStringConverter<VaccineType>();
            modelBuilder
                .Entity<Vaccine>()
                .Property(v => v.Type)
                .HasConversion(vaccineConverter);
        }
    }
    
}

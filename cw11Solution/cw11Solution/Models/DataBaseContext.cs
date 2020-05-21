using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cw11Solution.Models
{
    public class DataBaseContext: DbContext 
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; } 
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(k => k.IdDoctor).HasName("Doctor_PK");
                e.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                e.Property(p => p.LastName).HasMaxLength(50).IsRequired();
                e.Property(p => p.Email).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Patient>(e =>
            {

                e.HasKey(p => p.IdPatient).HasName("Patient_PK");
                e.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                e.Property(p => p.LastName).HasMaxLength(50).IsRequired();
                e.Property(p => p.BirthDate).IsRequired();

            });
            
            modelBuilder.Entity<Prescription>(e =>
            {
                e.HasKey(k => k.IdPrescription).HasName("Prescription_PK");
                e.Property(p => p.DueDate).IsRequired();
                e.Property(p => p.Date).IsRequired();

                e.HasOne(d => d.Doctor)
                    .WithMany(d => d.Prescriptions)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Doctor_Prescription");

                e.HasOne(d => d.Patient)
                    .WithMany(d => d.Prescription)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Patient_Prescription");
                
            });

            modelBuilder.Entity<Medicament>(e =>
            {
                e.HasKey(k => k.IdMedicament);
                e.Property(p => p.Name).HasMaxLength(100).IsRequired();
                e.Property(p => p.Description).HasMaxLength(100).IsRequired();
                e.Property(p => p.Type).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Prescription_Medicament>(e =>
            {
                
                e.HasKey(k => k.IdMedicament).HasName("Medicament_FK");
                e.HasKey(k => k.IdPrescription).HasName("Prescription_FK");
                e.Property(p => p.Details).HasMaxLength(50).IsRequired();

                e.ToTable("Prescription_Medicament");

                e.HasOne(d =>d.Medicament).
                    WithMany(d => d.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Medicament_Prescription");

                e.HasOne(d => d.Prescription)
                    .WithMany(d => d.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Prescription_Medicaments");
            });



        }
    }
}

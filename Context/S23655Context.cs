using Microsoft.EntityFrameworkCore;
using WebApplication1.Configurations;
using WebApplication1.Models;

namespace WebApplication1.Context;

public partial class S23655Context : DbContext
{
    public S23655Context() {}

    public S23655Context(DbContextOptions<S23655Context> options) : base(options) {}

    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicamentConfiguration());
    }
}
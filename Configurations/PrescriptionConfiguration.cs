using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(e => e.IdPrescription).HasName("IdPrescription_PK");
        builder.Property(e => e.IdPrescription).UseIdentityColumn();

        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.DueDate).IsRequired();

        builder.HasOne(e => e.IdPatientNav)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdPatient)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Prescription_Patient_FK");

        builder.HasOne(e => e.IdDoctorNav)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdDoctor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Prescription_Doctor_FK");

        var prescriptions = new List<Prescription>();

        prescriptions.Add(new Prescription
        {
            IdPrescription = 1,
            Date = DateTime.Now,
            DueDate = DateTime.Now.AddDays(60),
            IdPatient = 1,
            IdDoctor = 1
        });

        prescriptions.Add(new Prescription
        {
            IdPrescription = 2,
            Date = DateTime.Now,
            DueDate = DateTime.Now.AddDays(180),
            IdPatient = 2,
            IdDoctor = 1
        });

        prescriptions.Add(new Prescription
        {
            IdPrescription = 3,
            Date = DateTime.Now,
            DueDate = DateTime.Now.AddDays(365),
            IdPatient = 3,
            IdDoctor = 2
        });

        builder.HasData(prescriptions);
    }
}
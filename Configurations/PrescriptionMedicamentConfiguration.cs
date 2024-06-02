using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(e => new
            {
                e.IdMedicament,
                e.IdPrescription
            }
        ).HasName("PrescriptionMedicament_PK");

        builder.ToTable("Prescription_Medicament");

        builder.Property(e => e.Dose);
        builder.Property(e => e.Details).HasMaxLength(100).IsRequired();

        builder.HasOne(e => e.IdMedicamentNav)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdMedicament)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Medicament_Prescription_FK");

        builder.HasOne(e => e.IdPrescriptionNav)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdPrescription)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Prescription_Medicament_FK");

        var prescriptionMedicament = new List<PrescriptionMedicament>();

        prescriptionMedicament.Add(new PrescriptionMedicament
        {
            IdMedicament = 1,
            IdPrescription = 1,
            Dose = 200,
            Details = "2 pills in am and pm"
        });

        prescriptionMedicament.Add(new PrescriptionMedicament
        {
            IdMedicament = 2,
            IdPrescription = 1,
            Dose = 250,
            Details = "2 pills in am and pm"
        });

        prescriptionMedicament.Add(new PrescriptionMedicament
        {
            IdMedicament = 2,
            IdPrescription = 2,
            Dose = 250,
            Details = "2 pills in am and pm"
        });

        prescriptionMedicament.Add(new PrescriptionMedicament
        {
            IdMedicament = 3,
            IdPrescription = 3,
            Dose = 250,
            Details = "2 pills in am and pm"
        });

        builder.HasData(prescriptionMedicament);
    }
}
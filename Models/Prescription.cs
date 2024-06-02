namespace WebApplication1.Models;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }

    public virtual Patient IdPatientNav { get; set; }
    public virtual Doctor IdDoctorNav { get; set; }

    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
}
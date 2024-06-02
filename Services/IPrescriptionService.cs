using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IPrescriptionService
{
    Task<Prescription> AddNewPrescription(Prescription prescription);
}
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PrescriptionService : IPrescriptionService
{
    private S23655Context _context;

    public PrescriptionService(S23655Context context)
    {
        _context = context;
    }

    public async Task<Prescription> AddNewPrescription(Prescription prescription)
    {
        var rescription = new Prescription
        {
        };

        _context.Prescriptions.Add(rescription);
        await _context.SaveChangesAsync();

        return rescription;
    }
}
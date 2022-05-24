using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IPatientRepo
    {
        int CreatePatient(Patient patient);
    }
}

using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IPatientRepo
    {
        int CreatePatient(Patient patient);
        Patient GetPatientByEmail(string email);
        Patient GetPatientByUID(string uid);
        bool PatientExists(string uid);
    }
}

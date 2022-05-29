using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IPatientRepo
    {
        int CreatePatient(Patient patient);
        Patient GetPatientByEmail(string email);
        Patient GetPatientByFirebaseKeyId(string firebaseKeyId);
        bool PatientExists(string firebaseKeyId);
    }
}

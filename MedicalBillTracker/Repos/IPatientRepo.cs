using MedicalBillTracker.Models;

namespace MedicalBillTracker.Repos
{
    public interface IPatientRepo
    {
        public void CreatePatient(Patient patient);
        Patient GetPatientByEmail(string email);
        Patient GetPatientByFirebaseKeyId(string firebaseKeyId);
        public bool CheckPatientExists(int Id);
        Patient GetPatientById(int patientId);
    }
}

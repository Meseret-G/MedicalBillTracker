namespace MedicalBillTracker.Models
{
    public class Archive
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public bool IsOpen { get; set; }
        public string FirebaseKeyId { get; set; }
    }
}


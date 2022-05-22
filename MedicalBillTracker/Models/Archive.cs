namespace MedicalBillTracker.Models
{
    public class Archive
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public bool IsOpen { get; set; }
        public string UID { get; set; }
    }
}


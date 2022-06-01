namespace MedicalBillTracker.Models
{
    public class ArchiveItem
    {
        public int Id { get; set; }
        public int ArchiveId { get; set; }
        public int BillId { get; set; }
        public int PatientId {  get; set; }
    }
}

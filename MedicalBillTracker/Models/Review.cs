namespace MedicalBillTracker.Models
{
    public class Review
    {
        public List<Bill>? ReviewItems { get; set; }
        public int ReviewId { get; set; }
    }
}
